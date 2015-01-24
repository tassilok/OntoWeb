using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace OntologyClasses.BaseClasses
{
    [ElasticType(Name = "clsObjectRel")]
    public class clsObjectRel
    {

        private long? orderID;

        public string ID_Object { get; set; }
        public string Name_Object { get; set; }
        public string ID_Parent_Object { get; set; }
        public string Name_Parent_Object { get; set; }
        public string ID_Other { get; set; }
        public string Name_Other { get; set; }
        public string ID_Parent_Other { get; set; }
        public string Name_Parent_Other { get; set; }
        public string ID_RelationType { get; set; }
        public string Name_RelationType { get; set; }
        public string Ontology { get; set; }
        public string ID_Direction { get; set; }
        public string Name_Direction { get; set; }
        public long? OrderID 
        {
            get { return orderID; }
            set 
            { 
                orderID = value;
            } 
        }
        public long OrderIDNotNull { get { return orderID ?? 0; } }
     
        public clsObjectRel()
        {
            
        }

        public clsObjectRel(string ID_Object,
                             string Name_Object,
                             string ID_Parent_Object,
                             string Name_Parent_Object,
                             string ID_Other,
                             string Name_Other,
                             string ID_Parent_Other,
                             string Name_Parent_Other,
                             string ID_RelationType,
                             string Name_RelationType,
                             string Ontology,
                             string ID_Direction,
                             string Name_Direction,
                             long? OrderID)
        {
            this.ID_Object = ID_Object;
            this.Name_Object = Name_Object;
            this.ID_Parent_Object = ID_Parent_Object;
            this.Name_Parent_Object = Name_Parent_Object;
            this.ID_Other = ID_Other;
            this.Name_Other = Name_Other;
            this.ID_Parent_Other = ID_Parent_Other;
            this.Name_Parent_Other = Name_Parent_Other;
            this.ID_RelationType = ID_RelationType;
            this.Name_RelationType = Name_RelationType;
            this.Ontology = Ontology;
            this.ID_Direction = ID_Direction;
            this.Name_Direction = Name_Direction;
            this.OrderID = OrderID;
        }

        public clsObjectRel(string ID_Object ,
                            string ID_Parent_Object ,
                            string ID_Other ,
                            string ID_Parent_Other ,
                            string ID_RelationType ,
                            string Ontology ,
                            string ID_Direction ,
                            long OrderID)
        {
            this.ID_Object = ID_Object;
            this.ID_Parent_Object = ID_Parent_Object;
            this.ID_Other = ID_Other;
            this.ID_Parent_Other = ID_Parent_Other;
            this.ID_RelationType = ID_RelationType;
            this.Ontology = Ontology;
            this.ID_Direction = ID_Direction;
            this.OrderID = OrderID;
        }

        
    }
}
