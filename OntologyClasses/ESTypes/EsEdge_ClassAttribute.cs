using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.ESTypes
{
    public class EsEdge_ClassAttribute
    {
        public string ID_Class { get; set; }
        public string ID_AttributeType { get; set; }
        public string ID_DataType { get; set; }
        public long Min { get; set; }
        public long Max { get; set; }
    }
}
