using WpfOnt.OntoWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnt
{
    public class clsModuleConfig
    {
        private Assembly objAssembly;

        public IModule Instance { get; set; }

        public Assembly Assembly
        {
            get { return objAssembly; }
            set 
            {
                objAssembly = value;
                var objTypes = objAssembly.GetTypes().Where(a => a.Name == "clsModule").ToList();
                if (objTypes.Any())
                {
                    Instance = (IModule) objAssembly.CreateInstance(objTypes.First().FullName, false);
                }
                else
                {
                    Instance = null;
                }
            
            }
        }

        public List<clsOntologyItem> GetMenuItems(clsOntologyItem OItem) 
        {
            return Instance.GetMenuEntries(OItem);
        }
        

        private void Initialize_Module()
        {
            if (!Instance.IsInitialized)
            {
                Instance.Initialize();
            }
            
        }
    
        public bool HasListEditor(clsOntologyItem OItem)
        {
            try
            {
                return Instance.HasListEditor(OItem);
            }
            catch (Exception ex)
            {
                return false;
            }
        }    
    }
}
