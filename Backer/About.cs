using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backer
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void websiteUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            websiteUrl.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start(websiteUrl.Text);
        }
    }
}
