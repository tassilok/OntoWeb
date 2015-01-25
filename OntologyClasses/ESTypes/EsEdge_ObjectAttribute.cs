using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.ESTypes
{
    public class EsEdge_ObjectAttribute
    {
        public string ID_Attribute { get; set; }
        public string ID_AttributeType { get; set; }
        public string ID_DataType { get; set; }
        public string ID_Object { get; set; }
        public string ID_Class { get; set; }
        public bool? Val_Bool { get; set; }
        public DateTime? Val_Datetime { get; set; }
        public long? Val_Int { get; set; }
        public double? Val_Real { get; set; }
        public string Val_String { get; set; }
        public string Val_Name { get; set; }
        public long OrderID { get; set; }
    }
}
