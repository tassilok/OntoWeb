using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace OntologyClasses.BaseClasses
{
    /// <summary>
    /// 
    /// </summary>
    [ElasticType(Name = "clsAttribute")]
    public class clsAttribute
    {
        public bool? Val_Bit { get; set; }
        public long? Val_Long { get; set; }
        public double? Val_Double { get; set; }
        public DateTime? Val_Date { get; set; }
        public string Val_String { get; set; }
        public string Val_Name { get; set; }

        public string ID_Attribute { get; set; }
        public string ID_AttributeType { get; set; }
        public string ID_DataType { get; set; }
        
        public clsAttribute(string ID_Attribute,
                            string ID_AttributeType,
                            string ID_DataType, 
                            bool? Val_Bit,
                            long? Val_Long,
                            double? Val_Real,
                            DateTime? Val_Date,
                            string Val_String,
                            string Val_Name)
        {
            this.Val_Bit = Val_Bit;
            this.Val_Long = Val_Long;
            this.Val_Double = Val_Real;
            this.Val_Date = Val_Date;
            this.Val_String = Val_String;
            this.Val_Name = Val_Name;
            this.ID_Attribute = ID_Attribute;
            this.ID_AttributeType = ID_AttributeType;
            this.ID_DataType = ID_DataType;
        }

        public clsAttribute()
        {
            
        }
    }
}
