using WpfOnt.OntoWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnt
{
    public class clsTransactionItem
    {
        private clsOntologyItem objOItem_OntologyItem;
        private clsObjectAtt objOItem_ObjectAtt;
        private clsObjectRel objOItem_ObjectRel;
        private clsClassAtt objOItem_ClassAtt; 
        private clsClassRel objOItem_ClassRel;
        public clsOntologyItem TransactionResult { get; set; }
        public bool Removed { get; set; }
        public string savedType { get; private set; }
        public bool All { get; set; }

        public clsOntologyItem OItem_OntologyItem
        {
            get { return objOItem_OntologyItem; }
            set 
            {
                objOItem_OntologyItem = value;
                savedType = WebServiceConnector.OntologyWebSoapClient.ClassType_OntologyItem();
            }
        }

        public clsObjectAtt OItem_ObjectAtt
        {
            get { return objOItem_ObjectAtt; }
            set 
            {
                objOItem_ObjectAtt = value;
                savedType = WebServiceConnector.OntologyWebSoapClient.ClassType_OntologyItem();
            }

        }

        public clsObjectRel OItem_ObjectRel
        {
            get { return objOItem_ObjectRel; }
            set 
            {
                objOItem_ObjectRel = value;
                savedType = WebServiceConnector.OntologyWebSoapClient.ClassType_ObjectRel();
            }
        }
    
        public clsClassAtt OItem_ClassAtt
        {
            get { return objOItem_ClassAtt; }
            set 
            {
                objOItem_ClassAtt = value;
                savedType = WebServiceConnector.OntologyWebSoapClient.ClassType_ClassAtt();
            }
        }
    
        public clsClassRel OItem_ClassRel
        {
            get { return objOItem_ClassRel; }
            set
            {
                objOItem_ClassRel = value;
                savedType = WebServiceConnector.OntologyWebSoapClient.ClassType_ClassRel();
            }
        }
    
        
        public clsTransactionItem()
        {
            All = false;
        }
    }
}
