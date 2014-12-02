using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsBaseClassAttributes
    {
        public clsClassAtt Server__ProcessorID { get; private set; }
        public clsClassAtt Server__BaseBoardSerial { get; private set; }
        public clsClassAtt OntologyMappingItem__OrderID { get; private set; }
        public clsClassAtt OntologyMappingItem__Navigation { get; private set; }

        public clsClasses objClasses = new clsClasses();
        public clsAttributeTypes objAttributeTypes = new clsAttributeTypes();

        public List<clsClassAtt> ClassAtts { get; private set; }

        public clsBaseClassAttributes()
        {
            Server__ProcessorID = new clsClassAtt
                {
                    ID_AttributeType =  objAttributeTypes.OItem_AttributeType_WMI_ProcessorID.GUID,
                    ID_Class =  objClasses.OItem_Class_Server.GUID,
                    ID_DataType = objAttributeTypes.OItem_AttributeType_WMI_ProcessorID.GUID_Parent,
                    Min = 0,
                    Max = 1
                };

            Server__BaseBoardSerial = new clsClassAtt
            {
                ID_AttributeType = objAttributeTypes.OITem_AttributeType_WMI_BaseBoardSerial.GUID,
                ID_Class = objClasses.OItem_Class_Server.GUID,
                ID_DataType = objAttributeTypes.OITem_AttributeType_WMI_BaseBoardSerial.GUID_Parent,
                Min = 0,
                Max = 1
            };

            OntologyMappingItem__OrderID = new clsClassAtt
            {
                ID_AttributeType = objAttributeTypes.OITem_AttributeType_OrderID.GUID,
                ID_Class = objClasses.OItem_Class_OntologyMappingItem.GUID,
                ID_DataType = objAttributeTypes.OITem_AttributeType_OrderID.GUID_Parent,
                Min = 1,
                Max = 1
            };

            OntologyMappingItem__Navigation = new clsClassAtt
            {
                ID_AttributeType = objAttributeTypes.OITem_AttributeType_Navigation.GUID,
                ID_Class = objClasses.OItem_Class_OntologyMappingItem.GUID,
                ID_DataType = objAttributeTypes.OITem_AttributeType_Navigation.GUID_Parent,
                Min = 1,
                Max = 1
            };

            ClassAtts = new List<clsClassAtt>
                {
                    Server__ProcessorID,
                    Server__BaseBoardSerial,
                    OntologyMappingItem__OrderID,
                    OntologyMappingItem__Navigation
                };
        }
    }
}
