using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;


namespace OntologyClasses.DataClasses
{
    public class clsAttributeTypes
    {
        private clsTypes objTypes = new clsTypes();
        public clsOntologyItem OItem_AttributeType_WMI_ProcessorID { get; private set; }
        public clsOntologyItem OITem_AttributeType_WMI_BaseBoardSerial { get; private set; }
        public clsOntologyItem OITem_AttributeType_OrderID { get; private set; }
        public clsOntologyItem OITem_AttributeType_Navigation { get; private set; }

        public List<clsOntologyItem> AttributeTypes { get; private set; }

        private clsDataTypes objDataTypes = new clsDataTypes();

        public clsAttributeTypes()
        {
            
            AttributeTypes = new List<clsOntologyItem>();
            OItem_AttributeType_WMI_ProcessorID = new clsOntologyItem
                {
                    GUID = "a1b4945219dc4eaea000ef3802de35a9",
                    Name = "ProcessorID",
                    GUID_Parent = objDataTypes.DType_String.GUID,
                    Type = objTypes.AttributeType
                };

            AttributeTypes.Add(OItem_AttributeType_WMI_ProcessorID);

            OITem_AttributeType_WMI_BaseBoardSerial = new clsOntologyItem
                {
                    GUID = "30b76a621b224f17b9a5ff665e08f35a",
                    Name = "BaseboardSerial",
                    GUID_Parent = objDataTypes.DType_String.GUID,
                    Type = objTypes.AttributeType
                };

            AttributeTypes.Add(OITem_AttributeType_WMI_BaseBoardSerial);

            OITem_AttributeType_Navigation = new clsOntologyItem
            {
                GUID = "644d4b88443d4eec95d2ee62fa6cec90",
                Name = "Navigation",
                GUID_Parent =  objDataTypes.DType_Bool.GUID,
                Type = objTypes.AttributeType
            };

            AttributeTypes.Add(OITem_AttributeType_Navigation);

            OITem_AttributeType_OrderID = new clsOntologyItem
            {
                GUID = "f209eb0da51749a9bb6bc7cb5884f8f2",
                Name = "OrderID",
                GUID_Parent = objDataTypes.DType_Int.GUID,
                Type = objTypes.AttributeType
            };

            AttributeTypes.Add(OITem_AttributeType_OrderID);
            
        }
    }
}
