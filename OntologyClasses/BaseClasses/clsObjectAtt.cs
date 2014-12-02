using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace OntologyClasses.BaseClasses
{
    [ElasticType(Name = "clsObjectAtt")]
    public class clsObjectAtt
    {
        public string ID_Attribute { get; set; }
        public string ID_AttributeType { get; set; }
        public string Name_AttributeType { get; set; }
        public string ID_Object { get; set; }
        public string Name_Object { get; set; }
        public string ID_Class { get; set; }
        public string Name_Class { get; set; }
        public string Val_Named { get; set; }
        public string Val_Name
        {
            get { return Val_Named; }
            set { Val_Named = value; }
        }
        public string ID_DataType { get; set; }
        public string Name_DataType { get; set; }
        public bool? Val_Bool 
        {
            get { return Val_Bit; }
            set { Val_Bit = value; }
        }

        public bool? Val_Bit { get; set; }
        public long? Val_Int
        {
            get { return Val_Lng; }
            set { Val_Lng = value; }
        }
        public long? Val_Lng { get; set; }
        public DateTime? Val_Datetime
        {
            get { return Val_Date; }
            set { Val_Date = value; }
        }
        public double? Val_Real
        {
            get { return Val_Double; }
            set { Val_Double = value; }
        }
        public double? Val_Double { get; set; }
        public DateTime? Val_Date { get; set; }
        public string Val_String { get; set; }
        public long? OrderID { get; set; }

        public clsObjectAtt(string ID_Attribute,
                            string ID_Object,
                            string ID_Class,
                            string ID_AttributeType,
                            long? OrderID)
        {
            this.ID_Attribute = ID_Attribute;
            this.ID_Object = ID_Object;
            this.ID_Class = ID_Class;
            this.ID_AttributeType = ID_AttributeType;
            this.OrderID = OrderID;
        }

        public clsObjectAtt(string ID_Attribute,
                            string ID_Object,
                            string Name_Object,
                            string ID_Class,
                            string Name_Class,
                            string ID_AttributeType,
                            string Name_AttributeType,
                            long? OrderID,
                            string val_Named,
                            bool? val_Bit,
                            DateTime? val_Datetime,
                            long? val_Int,
                            double? val_Real,
                            string val_String,
                            string ID_DataType)
        {
            this.ID_Attribute = ID_Attribute;
            this.ID_Object = ID_Object;
            this.Name_Object = Name_Object;
            this.ID_Class = ID_Class;
            this.Name_Class = Name_Class;
            this.ID_AttributeType = ID_AttributeType;
            this.Name_AttributeType = Name_AttributeType;
            this.OrderID = OrderID;
            this.Val_Named = val_Named;
            this.Val_Bit = val_Bit;
            this.Val_Date = val_Datetime;
            this.Val_Lng = val_Int;
            this.Val_Double = val_Real;
            this.Val_String = val_String;
            this.ID_DataType = ID_DataType;

        }

        public clsObjectAtt(string ID_Attribute,
                            string ID_Object,
                            string Name_Object,
                            string ID_Class,
                            string Name_Class,
                            string ID_AttributeType,
                            string Name_AttributeType,
                            long? OrderID,
                            string val_Named,
                            bool? val_Bit,
                            DateTime? val_Datetime,
                            long? val_Int,
                            double? val_Real,
                            string val_String,
                            string ID_DataType,
                            string Name_DataType)
        {
            this.ID_Attribute = ID_Attribute;
            this.ID_Object = ID_Object;
            this.Name_Object = Name_Object;
            this.ID_Class = ID_Class;
            this.Name_Class = Name_Class;
            this.ID_AttributeType = ID_AttributeType;
            this.Name_AttributeType = Name_AttributeType;
            this.OrderID = OrderID;
            this.Val_Named = val_Named;
            this.Val_Bit = val_Bit;
            this.Val_Date = val_Datetime;
            this.Val_Lng = val_Int;
            this.Val_Double = val_Real;
            this.Val_String = val_String;
            this.ID_DataType = ID_DataType;
            this.Name_DataType = Name_DataType;
        }

        public clsObjectAtt()
        {
            
        }
    }
}
