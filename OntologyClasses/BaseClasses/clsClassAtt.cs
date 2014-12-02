using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace OntologyClasses.BaseClasses
{
    [ElasticType(Name = "clsClassAtt")]
    public class clsClassAtt
    {
        public string ID_Class { get; set; }
        public string Name_Class { get; set; }
        public string ID_AttributeType { get; set; }
        public string Name_AttributeType { get; set; }
        public string ID_DataType { get; set; }
        public string Name_DataType { get; set; }
        public long? Min { get; set; }
        public long? Max { get; set; }

        public clsClassAtt()
        {
            
        }

        public clsClassAtt(string ID_AttributeType, string ID_DataType, string ID_Class, long? Min, long? Max)
        {
            this.ID_Class = ID_Class;
            this.ID_AttributeType = ID_AttributeType;
            this.ID_DataType = ID_DataType;

            this.Min = Min;
            this.Max = Max;
        }
    }
}
