using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnt
{
    public class clsModuleForCommandLine
    {
        public string ModuleGuid { get; set; }
        public string ModuleName { get; set; }
        public string ModulePath { get; set; }
        public string MainModuleFunction { get; set; }

        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public int Revision { get; set; }

        public string Version { 
            get { return Major.ToString() + "." + Minor.ToString() + "." + Build.ToString() + "." + Revision.ToString(); }
        }
        

        public clsModuleForCommandLine Clone()
        {
            var objModule = new clsModuleForCommandLine
            {
                Build = Build,
                MainModuleFunction = MainModuleFunction,
                Major = Major,
                Minor = Minor,
                ModuleGuid = ModuleGuid,
                ModuleName = ModuleName,
                ModulePath = ModulePath,
                Revision = Revision
            };

            return objModule;
        }
    }
}
