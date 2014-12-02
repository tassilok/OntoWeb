using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace OntologyClasses.BaseClasses
{
    [ElasticType(Name = "clsObjectTree")]
    public class clsObjectTree
    {
        public string ID_Object { get; set; }
        public string Name_Object { get; set; }
        public string ID_Parent { get; set; }
        public string ID_Object_Parent { get; set; }
        public string Name_Object_Parent { get; set; }
        public long? OrderID { get; set; }
        public long? Level { get; set; }

        public clsObjectTree()
        {
            
        }

        public clsObjectTree(string ID_Object ,
                             string Name_Object ,
                             string ID_Parent ,
                             string ID_Object_Parent ,
                             string Name_Object_Parent ,
                             long? OrderID)
        {
            this.ID_Object = ID_Object;
            this.Name_Object = Name_Object;
            this.ID_Parent = ID_Parent;
            this.ID_Object_Parent = ID_Object_Parent;
            this.Name_Object_Parent = Name_Object_Parent;
            this.OrderID = OrderID;
        }
    }
}
