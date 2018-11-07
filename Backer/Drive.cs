using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer
{
    public class Drive
    {
        public string Letter        { get; set; }
        public string RootDirectory { get; set; }
        public string Label         { get; set; }
        public bool   Connected       { get; set; }
        public bool   Ignore          { get; set; }

        public Drive(string Letter, 
                     string RootDirectory, 
                     string Label, 
                     bool   Connected, 
                     bool   Ignore)
        {
            this.Letter = Letter;
            this.RootDirectory = RootDirectory;
            this.Label = Label;
            this.Connected = Connected;
            this.Ignore = Ignore;
        }

    }
}
