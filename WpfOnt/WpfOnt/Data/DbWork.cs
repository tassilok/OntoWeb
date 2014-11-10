using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.OServiceClassAtt;
using WpfOnt.OServiceObjectAtt;
using WpfOnt.OServiceOItems;
using clsClassItem = WpfOnt.OServiceOItems.clsOntologyItem;
using clsObjectItem = WpfOnt.OServiceOItems.clsOntologyItem;

namespace WpfOnt.Data
{
    public class DbWork
    {
        private readonly OServiceOItemsSoapClient oServiceOItemsSoapClient = new OServiceOItemsSoapClient();
        private readonly OServiceClassAttSoapClient oServiceClassAttSoapClient = new OServiceClassAttSoapClient();
        private readonly OServiceObjectAttSoapClient oServiceObjAttSoapClient = new OServiceObjectAttSoapClient();

        public List<clsClassItem> GetClassList()
        {
            return new List<clsClassItem>(oServiceOItemsSoapClient.Classes());
        }

        public List<clsObjectItem> GetObjectListByClassId(string idParent)
        {
            return new List<clsObjectItem>(oServiceOItemsSoapClient.ObjectsByGuidParent(idParent));
        }

        public List<clsObjectItem> GetObjectListByNameObjectAndClassId(string idParent, string nameObject)
        {
            return new List<clsObjectItem>(oServiceOItemsSoapClient.ObjectsByGuidParentAndName(idParent, nameObject, false));
        }

        public List<clsClassAtt> GetClassAttributesByClassId(string idClass)
        {
            return new List<clsClassAtt>(oServiceClassAttSoapClient.ClassAttributesByClassGuid(idClass, false));
        }

        public long CountObjectAttributesByClassIdAndAttributeTypeId(string idClass, string idAttributeType)
        {
            return oServiceObjAttSoapClient.CountObjectAttsByIdClassAndIdAttributeType(idClass, idAttributeType);
        }

        public clsOntologyItem GetOItem(string idItem, string type)
        {
            return oServiceOItemsSoapClient.GetOItem(idItem, type);
        }

        public string GetClassPath(string idClass)
        {
            return oServiceOItemsSoapClient.GetClassPath(idClass);
        }
    }
}

