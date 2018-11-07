using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Backer
{
    public partial class Form1 : Form
    {
        private string AppName { get  { return Text; } }
        public bool monitoring = false;
        List<string> knownDrivesLabels;
        List<string> drivesToIgnoreList = new List<string>();
        private UsbManager manager;
        public List<Drive> drivesList = new List<Drive>();

        string appDataPath;
        string myDataLocation;
        string knownDrivesFile;
        string extensionsFile;
        public bool onLogin = false;
        private static readonly string NL = Environment.NewLine;
        public Form1(string[] args)
        {
            UsbManager.TheParent = this;
            onLogin = (args.Length > 0);
            //previousDrivesRoots = GetDrivesList();
            InitializeComponent();
            manager = new UsbManager();
            UsbDiskCollection disks = manager.GetAvailableDisks();
            // Datagrids
            myDevicesGrid.AllowUserToAddRows = false;
            // Drives list management
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            myDataLocation = Path.Combine(appDataPath, AppName + " data");
            if (!Directory.Exists(myDataLocation)) Directory.CreateDirectory(myDataLocation);
            knownDrivesFile = Path.Combine(myDataLocation, "knownDrives.txt");
            extensionsFile = Path.Combine(myDataLocation, "extensions.txt");
            FillExtensionsList();
            if (System.IO.File.Exists(knownDrivesFile))
            {
                knownDrivesLabels = new List<string>(System.IO.File.ReadAllLines(knownDrivesFile));
                for (int i = 0; i < knownDrivesLabels.Count; i++)
                {

                    string lbl = knownDrivesLabels[i].Substring(1);
                    bool ignore = knownDrivesLabels[i][0] == '1';
                    myDevicesGrid.Rows.Add(!ignore, lbl);
                    drivesList.Add(new Drive(lbl[0].ToString(), lbl[0].ToString() + ":\\", lbl, false, !ignore));
                    knownDrivesLabels[i] = lbl;
                }
            }
            foreach (UsbDisk disk in disks)
            {
                // Datagrids
                if (!knownDrivesLabels.Contains(disk.ToString()))
                {
                    myDevicesGrid.Rows.Add(false, disk.ToString());
                    drivesList.Add(new Drive(disk.Name[0].ToString(), disk.Name + "\\", disk.ToString(), true, true));
                    //
                }
                else
                {
                    foreach (Drive d in drivesList)
                    {
                        if (d.Label == disk.ToString()) d.Connected = true;
                    }

                }
            }
            AddRemovebleDrives(false);
            manager.StateChanged += new UsbStateChangedEventHandler(DoStateChanged);
            startOnLoginCheckBox.Checked = Properties.Settings.Default.startOnLogin;
            // Copying files
            allTypesCheckBox.Checked = Properties.Settings.Default.allTypesBool;
            fileSizeLimitCheckBox.Checked = Properties.Settings.Default.fileSizeLimitBool;
            totalSizeLimitCheckBox.Checked = Properties.Settings.Default.totalSizeLimitBool;
            // Copying files
            fileSizeNum.Value = Properties.Settings.Default.fileSizeLimitInt;
            totalSizeNum.Value = Properties.Settings.Default.totalSizeLimitInt;
            if (Properties.Settings.Default.onlyBool)
                onlyTypesRadio.Checked = true;
            else
                exceptionsRadio.Checked = true;

            // Output location
            if (Properties.Settings.Default.outputLocation.Length < 2)
            {
                Properties.Settings.Default.outputLocation = outputLocationTxt.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + Text +" data\\";
                Properties.Settings.Default.Save(); // Saves settings in application configuration file

            }
            else
                outputLocationTxt.Text = Properties.Settings.Default.outputLocation;
            //Hide();

        }
        public void AddRemovebleDrives(bool process)
        {
            var drives = DriveInfo.GetDrives().Where(drive => (drive.IsReady && !drive.Name.Equals("A:\\") && (drive.DriveType != DriveType.Fixed)));

            foreach (DriveInfo drive in drives)
            {
                string infoLabel = GetDriveInfo(drive.RootDirectory.ToString());
                var driveInList = drivesList.Where(p => String.Equals(p.Letter, drive.Name[0].ToString(), StringComparison.CurrentCulture));
                if (driveInList.Count() == 0) // isnt in the list
                {

                    myDevicesGrid.Rows.Add(false, infoLabel);
                    Drive addedDrive = new Drive(drive.Name[0].ToString(), drive.RootDirectory.ToString(), infoLabel, true, false);
                    drivesList.Add(addedDrive);
                    if (process) ProcessDrive(addedDrive);
                    //System.IO.File.AppendAllText(knownDrivesFile, infoLabel + NL);
                }
                else // is in the list
                {
                    /*foreach (Drive d in drivesList)
                    {
                        System.IO.File.AppendAllText(coutFile, NL + d.RootDirectory + " is in the list, its label: " + d.Label);
                        drivesList.ElementAt(drivesList.IndexOf(d)).Connected = true;
                    }*/
                    foreach (Drive d in driveInList)
                    {
                        Drive addedDrive = drivesList.ElementAt(drivesList.IndexOf(d));
                        if (!addedDrive.Connected)
                        {
                            addedDrive.Connected = true;
                            if (process) ProcessDrive(addedDrive);

                        }
                    }
                }
            }
            //DumpDrivesInfo();
        }
        public string GetDriveInfo(string rootDirectory)
        {
            //System.IO.File.AppendAllText(coutFile, NL + "rootDirectory: " + rootDirectory);
            var drives = DriveInfo.GetDrives().Where(drive => (drive.IsReady && !drive.Name.Equals("A:\\") && drive.Name.Equals(rootDirectory)));
            foreach (DriveInfo drive in drives)
            {
                return FormatDriveLabel(drive.RootDirectory.ToString(), drive.DriveFormat, drive.DriveType.ToString(), (ulong)drive.TotalSize, drive.VolumeLabel);
            }
            return "Unknown drive";
        }
        public string FormatDriveLabel(string name, string format, string type, ulong size, string volumeLbl)
        {
            string label = name[0].ToString() + " " + volumeLbl + " " + format + " " + type + " " + FormatByteCount(size);
            return label;
        }
        public string currentRecordingStr;
        public List<string> GetRemovableDrivesRoots()
        {
            List<string> roots = new List<string>();
            var drives = DriveInfo.GetDrives().Where(drive => (drive.IsReady && !drive.Name.Equals("A:\\") && drive.DriveType != DriveType.Fixed));
            foreach (DriveInfo drive in drives)
            {
                roots.Add(drive.RootDirectory.ToString()); // Root dir
            }
            return roots;
        }

        public List<string> GetFixedDrivesRoots()
        {
            List<string> roots = new List<string>();
            var drives = DriveInfo.GetDrives().Where(drive => (drive.IsReady && !drive.Name.Equals("A:\\") && drive.DriveType == DriveType.Fixed));
            foreach (DriveInfo drive in drives)
            {

                roots.Add(drive.RootDirectory.ToString()); // Root dir
            }
            return roots;
        }

        public void FillExtensionsList()
        {
            if (!System.IO.File.Exists(extensionsFile))
            {
                System.IO.File.Create(extensionsFile).Close();
                return;
            }
            string[] extensions = System.IO.File.ReadAllLines(extensionsFile);
            foreach (string e in extensions)
            {
                extensionsDataGrid.Rows.Add(e);
            }
        }
        private void DoStateChanged(UsbStateChangedEventArgs e)
        {

            if (e.State == UsbStateChange.Added)
            {
                Drive addedDrive = new Drive("?", "", "Unknown drive", true, false);
                // Managing lists and naming
                string infoLabel = GetDriveInfo(e.Disk.Name + "\\");
                var drive = drivesList.Where(p => (String.Equals(p.Label, e.Disk.ToString(), StringComparison.CurrentCulture) || String.Equals(p.Label, infoLabel, StringComparison.CurrentCulture)));

                if (drive.Count() > 0) // if it is in the list
                {

                    foreach (Drive d in drive)
                    {
                        d.Connected = true;
                        addedDrive = d;
                    }
                    //drivesList.ElementAt(drivesList.IndexOf(drive.ToList().First())).Connected = true;
                    //addedDrive = drivesList.ElementAt(drivesList.IndexOf(drive.ToList().First()));
                }
                else // if it isn't in the list
                {
                    string label;
                    if (e.Disk.ToString().Length > infoLabel.Length) label = e.Disk.ToString();
                    else label = infoLabel;
                    addedDrive = new Drive(e.Disk.Name[0].ToString(), e.Disk.Name + "\\", label, true, false);
                    drivesList.Add(addedDrive);
                    myDevicesGrid.Rows.Add(false, label);
                    //System.IO.File.AppendAllText(knownDrivesFile, label + NL);

                }
                if (monitoring)
                    ProcessDrive(addedDrive);
                // check for any additional drives that might have came with this one
                AddRemovebleDrives(monitoring);
                //DumpDrivesInfo();
            }
            else if (e.State == UsbStateChange.Removed)
            {
                //DumpDrivesInfo();

                //System.IO.File.AppendAllText(coutFile, NL + rec.ToString()); // check if null
                // Check by notification
                var connectedDrives = drivesList.Where(p => p.Connected);
                var existantDrivesRoots = GetRemovableDrivesRoots();
                foreach (Drive drive in connectedDrives)
                {
                    if (!existantDrivesRoots.Contains(drive.RootDirectory))
                    {
                        drivesList.ElementAt(drivesList.IndexOf(drive)).Connected = false;
                    }
                }
                //DumpDrivesInfo();

            }

        }
        public void ProcessDrive(Drive addedDrive)
        {
            if (drivesToIgnoreList.Contains(addedDrive.Label)) return;
            string infoLocation = outputLocationTxt.Text + DateTime.Now.ToString("yyyy-MM-dd HH-mm");
            infoLocation = Path.Combine(infoLocation, addedDrive.Label);
            Directory.CreateDirectory(infoLocation);

            string directoryName = Path.Combine(infoLocation, addedDrive.Letter);
            Directory.CreateDirectory(directoryName);
            if (!allTypesCheckBox.Checked)
            {
                string specifiedExtensions = "";
                string comma = ", ";
                string asterisk = "*";
                string dot = ".";
                for (int rows = 0; rows < extensionsDataGrid.Rows.Count; rows++)
                {
                    if (extensionsDataGrid.Rows[rows].Cells["columnExtension"].Value != null)
                    {
                        string extension = extensionsDataGrid.Rows[rows].Cells["columnExtension"].Value.ToString();

                        if (extension[0] == asterisk[0])
                        {
                            specifiedExtensions += extension;
                        }
                        else if (extension[0] == dot[0])
                        {
                            specifiedExtensions += asterisk + extension;
                        }
                        else
                        {
                            specifiedExtensions += asterisk + dot + extension;
                        }
                        if (rows != extensionsDataGrid.Rows.Count - 2)
                        {
                            specifiedExtensions += comma;
                        }
                    }
                }
                if (onlyTypesRadio.Checked)
                {
                    Task.Run(() => CopyDirectoriesAndFiles(addedDrive, directoryName, specifiedExtensions, true));

                    //.Where(s => specifiedExtensions.Contains(Path.GetExtension(s).ToLower())))

                }
                else
                {
                    Task.Run(() => CopyDirectoriesAndFiles(addedDrive, directoryName, specifiedExtensions, false));


                    //.Where(s => !specifiedExtensions.Contains(Path.GetExtension(s).ToLower())))
                }
            }
            else
            {
                Task.Run(() => CopyDirectoriesAndFiles(addedDrive, directoryName, String.Empty, false));
            }
        }

        public void ShowBalloon(Drive addedDrive)
        {
            notifyIcon.ShowBalloonTip(1000, "Copying...", "Backing up files from drive " + addedDrive.Letter, ToolTipIcon.None);
        }

        public void ShowBalloon(string title, string text)
        {
            notifyIcon.ShowBalloonTip(1000, title, text, ToolTipIcon.None);
        }

        public void CopyDirectoriesAndFiles(Drive addedDrive, string directoryName, string specifiedExtensions, bool onlyTypes)
        {
            ShowBalloon(addedDrive);
            double totalSizeMb = 0;
            foreach (string dir in Directory.GetDirectories(addedDrive.RootDirectory, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(Path.Combine(directoryName, dir.Substring(dir.IndexOf("\\") + 1)));
            }
            if (specifiedExtensions == String.Empty)
            {
                try
                {
                    foreach (string file in Directory.EnumerateFiles(addedDrive.RootDirectory, "*", SearchOption.AllDirectories))
                    {
                        long length = new System.IO.FileInfo(file).Length;
                        double fileSizeInMb = ConvertBytesToMegabytes(length);

                        if (fileSizeInMb < (double)fileSizeNum.Value || !fileSizeLimitCheckBox.Checked)
                        {
                            try
                            {
                                if (!System.IO.File.Exists(Path.Combine(directoryName, file.Substring(file.IndexOf("\\") + 1))))
                                    System.IO.File.Copy(file, Path.Combine(directoryName, file.Substring(file.IndexOf("\\") + 1)), true);
                            }
                            catch (ArgumentNullException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "ArgumentNullException: " + ex.Message);
                            }
                            catch (UnauthorizedAccessException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "UnauthorizedAccessException: " + ex.Message);
                            }
                            catch (FileNotFoundException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "FileNotFoundException: " + ex.Message);
                            }
                            catch (System.IO.DirectoryNotFoundException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "DirectoryNotFoundException: " + ex.Message);
                            }
                            totalSizeMb += fileSizeInMb;
                            if (totalSizeLimitCheckBox.Checked)
                                if (totalSizeMb > (double)totalSizeNum.Value)
                                {
                                    return;
                                }
                        }
                        //else System.IO.File.AppendAllText(coutFile, NL + file + " is bigger: " + fileSizeInMb);
                        // copy file to output location/files/
                    }
                }
                catch (FileNotFoundException)
                {
                    return;
                }
                catch (DirectoryNotFoundException)
                {
                    return;
                }
            }
            else if (onlyTypes)
            {
                try
                {
                    foreach (string file in Directory.EnumerateFiles(addedDrive.RootDirectory, "*", SearchOption.AllDirectories).Where(s => specifiedExtensions.Contains(Path.GetExtension(s).ToLower())))
                    {
                        long length = new System.IO.FileInfo(file).Length;
                        double fileSizeInMb = ConvertBytesToMegabytes(length);

                        if (fileSizeInMb < (double)fileSizeNum.Value || !fileSizeLimitCheckBox.Checked)
                        {
                            try
                            {
                                if (!System.IO.File.Exists(Path.Combine(directoryName, file.Substring(file.IndexOf("\\") + 1))))
                                    System.IO.File.Copy(file, Path.Combine(directoryName, file.Substring(file.IndexOf("\\") + 1)));
                            }
                            catch (ArgumentNullException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "ArgumentNullException: " + ex.Message);
                            }
                            catch (UnauthorizedAccessException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "UnauthorizedAccessException: " + ex.Message);
                            }
                            catch (FileNotFoundException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "FileNotFoundException: " + ex.Message);
                            }
                            catch (System.IO.DirectoryNotFoundException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "DirectoryNotFoundException: " + ex.Message);
                            }
                            totalSizeMb += fileSizeInMb;
                            if (totalSizeLimitCheckBox.Checked)
                                if (totalSizeMb > (double)totalSizeNum.Value)
                                {
                                    //System.IO.File.AppendAllText(coutFile, NL + "File size limit reached, returning");
                                    return;
                                }
                        }
                        //else System.IO.File.AppendAllText(coutFile, NL + file + " is bigger: " + fileSizeInMb);
                        // copy file to output location/files/
                    }
                }
                catch (FileNotFoundException)
                {
                    return;
                }
                catch (DirectoryNotFoundException)
                {
                    return;
                }
            }
            else
            {
                try
                {
                    foreach (string file in Directory.EnumerateFiles(addedDrive.RootDirectory, "*", SearchOption.AllDirectories).Where(s => !specifiedExtensions.Contains(Path.GetExtension(s).ToLower())))
                    {
                        long length = new System.IO.FileInfo(file).Length;
                        double fileSizeInMb = ConvertBytesToMegabytes(length);

                        if (fileSizeInMb < (double)fileSizeNum.Value || !fileSizeLimitCheckBox.Checked)
                        {
                            try
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "c");
                                if (!System.IO.File.Exists(Path.Combine(directoryName, file.Substring(file.IndexOf("\\") + 1))))
                                    System.IO.File.Copy(file, Path.Combine(directoryName, file.Substring(file.IndexOf("\\") + 1)));
                            }
                            catch (ArgumentNullException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "ArgumentNullException: " + ex.Message);
                            }
                            catch (UnauthorizedAccessException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "UnauthorizedAccessException: " + ex.Message);
                            }
                            catch (FileNotFoundException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "FileNotFoundException: " + ex.Message);
                            }
                            catch (System.IO.DirectoryNotFoundException)
                            {
                                //System.IO.File.AppendAllText(coutFile, NL + "DirectoryNotFoundException: " + ex.Message);
                            }
                            totalSizeMb += fileSizeInMb;
                            if (totalSizeLimitCheckBox.Checked)
                                if (totalSizeMb > (double)totalSizeNum.Value)
                                {
                                    //System.IO.File.AppendAllText(coutFile, NL + "File size limit reached, returning");
                                    return;
                                }
                        }
                        //else System.IO.File.AppendAllText(coutFile, NL + file + " is bigger: " + fileSizeInMb);
                        // copy file to output location/files/
                    }
                }
                catch (FileNotFoundException)
                {
                    return;
                }
                catch (DirectoryNotFoundException)
                {
                    return;
                }
                catch (System.IO.IOException)
                {
                    return;
                }
            }
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        private const int KB = 1024;
        private const double MB = KB * 1024;
        private const double GB = MB * 1024;
        private string FormatByteCount(ulong bytes)
        {
            string format = null;

            if (bytes < KB)
            {
                format = String.Format("{0} Bytes", bytes);
            }
            else if (bytes < MB)
            {
                bytes = bytes / KB;
                format = String.Format("{0} KB", bytes.ToString("N"));
            }
            else if (bytes < GB)
            {
                double dree = bytes / MB;
                format = String.Format("{0} MB", dree.ToString("N1"));
            }
            else
            {
                double gree = bytes / GB;
                format = String.Format("{0} GB", gree.ToString("N1"));
            }

            return format;
        }
        /*
        public void PrintDrive(Drive d)
        {
            System.IO.File.AppendAllText(coutFile, NL + "Printing drive");
            System.IO.File.AppendAllText(coutFile, NL + d.Label);
            System.IO.File.AppendAllText(coutFile, NL + d.Letter);
            System.IO.File.AppendAllText(coutFile, NL + d.RootDirectory);
            System.IO.File.AppendAllText(coutFile, NL + d.Connected);
        }
        
        public void DumpDrivesInfo()
        {
            foreach (Drive drive in drivesList)
            {
                System.IO.File.AppendAllText(coutFile, NL + drive.Label + " Letter: ");
                System.IO.File.AppendAllText(coutFile, NL  + drive.Letter + " ");
                System.IO.File.AppendAllText(coutFile, NL + "Connected: " + drive.Connected);
                System.IO.File.AppendAllText(coutFile, NL);
            }
        }*/

        public void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }
        private void startBtn_Click(object sender, EventArgs e)
        {
            var checkedRows = from DataGridViewRow r in myDevicesGrid.Rows
                              where Convert.ToBoolean(r.Cells[0].Value) == true
                              select r;
            if (checkedRows.Count() == 0)
            {
                MessageBox.Show("Please select at least one USB!", AppName);
                return;
            }
            if (!monitoring)
            {
                startBtn.Text = "Stop";
                notifyIcon.Icon = Properties.Resources.usbIconYellow;
                notifyIcon.Text = AppName + " - on. Double click to show";
                notifyIcon.Visible = true;
                Properties.Settings.Default.outputLocation = outputLocationTxt.Text;
                Properties.Settings.Default.Save();
                if (!Directory.Exists(outputLocationTxt.Text)) Directory.CreateDirectory(outputLocationTxt.Text);

                monitoring = true;
                // Fill drives to ignore list

                drivesToIgnoreList.Clear();
                if (System.IO.File.Exists(knownDrivesFile))
                {
                    System.IO.File.Delete(knownDrivesFile);
                    System.IO.File.Create(knownDrivesFile).Close();
                }
                for (int rows = 0; rows < myDevicesGrid.Rows.Count; rows++)
                {
                    string label = myDevicesGrid.Rows[rows].Cells[1].Value.ToString();
                    bool ignore = !Convert.ToBoolean(myDevicesGrid.Rows[rows].Cells[0].Value.ToString());
                    if (ignore)
                    {
                        drivesToIgnoreList.Add(myDevicesGrid.Rows[rows].Cells[1].Value.ToString());

                    }
                    System.IO.File.AppendAllText(knownDrivesFile, Convert.ToInt16(ignore).ToString() + label + NL);

                }
                //drivesExceptionsGrid.Enabled = false;
                //exceptionsDataGrid.Enabled = false;
                // Clean the extensions datagrid
                for (int i = extensionsDataGrid.Rows.Count - 1; i > -1; i--)
                {
                    DataGridViewRow row = extensionsDataGrid.Rows[i];
                    if (!row.IsNewRow && row.Cells[0].Value == null)
                    {
                        extensionsDataGrid.Rows.RemoveAt(i);
                    }

                }

                if (!onLogin)
                {
                    HideWithTransition();
                }
                // save the extensions
                List<string> savedExtensions = new List<string>(System.IO.File.ReadAllLines(extensionsFile));
                for (int i = extensionsDataGrid.Rows.Count - 2; i > -1; i--)
                {
                    DataGridViewRow row = extensionsDataGrid.Rows[i];
                    if (!savedExtensions.Contains(row.Cells[0].Value))
                        System.IO.File.AppendAllText(extensionsFile, row.Cells[0].Value + NL);
                }
                ShowBalloon(AppName + " minimized", "Waiting for the next drive to back up...");
            }
            else
            {
                notifyIcon.Icon = Properties.Resources.usbIconScaled;
                notifyIcon.Text = AppName + " - off";
                monitoring = false;
                //exceptionsDataGrid.Enabled = true;
                //drivesExceptionsGrid.Enabled = true;
                startBtn.Text = "Start";

            }
            // add itself's data location to exceptions

        }

        public void HideWithTransition()
        {
            double opacity = 1.00;
            while (opacity > 0)
            {
                Opacity = opacity; // update main form opacity - transparency
                opacity -= 0.01; // this can be changed
                System.Threading.Thread.Sleep(10);
            }
            Hide();
            Opacity = 1.00; // make sure Opacity is 100% at the end
        }


        private void allTypesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onlyTypesRadio.Enabled = exceptionsRadio.Enabled = extensionsDataGrid.Enabled = !allTypesCheckBox.Checked;
            Properties.Settings.Default.allTypesBool = allTypesCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void fileSizeLimitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.fileSizeLimitBool = fileSizeNum.Enabled = mbLabel.Enabled = fileSizeLimitCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void totalSizeLimitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.totalSizeLimitBool = totalSizeNum.Enabled = mbLabel2.Enabled = totalSizeLimitCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!allTypesCheckBox.Checked) onlyTypesRadio.Enabled = exceptionsRadio.Enabled = extensionsDataGrid.Enabled = true;
            else onlyTypesRadio.Enabled = exceptionsRadio.Enabled = extensionsDataGrid.Enabled = false;
            if (fileSizeLimitCheckBox.Checked) fileSizeNum.Enabled = mbLabel.Enabled = true;
            else fileSizeNum.Enabled = mbLabel.Enabled = false;
            if (totalSizeLimitCheckBox.Checked) totalSizeNum.Enabled = mbLabel2.Enabled = true;
            else totalSizeNum.Enabled = mbLabel2.Enabled = false;

            if (onLogin)
            {
                startBtn_Click(null, null); // Simulate a keypress
            }
        }

        private void DataGridView_EnabledChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (!dgv.Enabled)
            {
                dgv.DefaultCellStyle.BackColor = SystemColors.Control;
                dgv.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
                dgv.CurrentCell = null;
                dgv.ReadOnly = true;
                dgv.EnableHeadersVisualStyles = false;
            }
            else
            {
                dgv.DefaultCellStyle.BackColor = SystemColors.Window;
                dgv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
                dgv.ReadOnly = false;
                dgv.EnableHeadersVisualStyles = true;
            }
        }

        private void outputLocationBrowseBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                outputLocationTxt.Text = folderBrowserDialog.SelectedPath + "\\";
            }
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            About aboutWnd = new About();
            aboutWnd.ShowDialog();
        }

        private void fileSizeNum_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.fileSizeLimitInt = (int)fileSizeNum.Value;
            Properties.Settings.Default.Save();
        }

        private void totalSizeNum_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.totalSizeLimitInt = (int)totalSizeNum.Value;
            Properties.Settings.Default.Save();
        }

        public bool enteringPassword = false;
        

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Visible)
            {
                Show();
                
            }
        }

        private void onlyTypesRadio_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.onlyBool = onlyTypesRadio.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (onLogin)
            {
                Visible = false;
            }
        }

        private void startOnLoginCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup();
            Properties.Settings.Default.startOnLogin = startOnLoginCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void SetStartup()
        {
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (startOnLoginCheckBox.Checked)
                rk.SetValue(Text, "\"" + Application.ExecutablePath.ToString() + "\"" + " /regrun");
            else
                rk.DeleteValue(Text, false);

        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            Process.Start(outputLocationTxt.Text);
        }

        private void myDevicesGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                int rowIndex = myDevicesGrid.CurrentCell.RowIndex;
                myDevicesGrid.Rows.RemoveAt(rowIndex);
                e.Handled = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && monitoring)
            {
                Hide();
            }
        }
    }
}

