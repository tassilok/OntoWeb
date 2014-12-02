using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace OntologyClasses.BaseClasses
{
    [ElasticType(Name = "clsClassRel")]
    public class clsClassRel
    {
        public string ID_Class_Left { get; set; }
        public string Name_Class_Left { get; set; }
        public string ID_Class_Right { get; set; }
        public string Name_Class_Right { get; set; }
        public string ID_RelationType { get; set; }
        public string Name_RelationType { get; set; }
        public string Ontology { get; set; }
        public long? Min_Forw { get; set; }
        public long? Max_Forw { get; set; }
        public long? Max_Backw { get; set; }


        public clsClassRel(string ID_Class_Left,
                           string ID_Class_Right,
                           string ID_RelationType,
                           string Ontology,
                           long? Min_forw,
                           long? Max_forw,
                           long? Max_backw)
        {
            this.ID_Class_Left = ID_Class_Left;
            this.ID_Class_Right = ID_Class_Right;
            this.ID_RelationType = ID_RelationType;
            this.Ontology = Ontology;
            this.Min_Forw = Min_forw;
            this.Max_Forw = Max_forw;
            this.Max_Backw = Max_backw;
        }

        public clsClassRel(string ID_Class_Left ,
                   string Name_Class_Left ,
                   string ID_Class_Right ,
                   string Name_Class_Right ,
                   string ID_RelationType ,
                   string Name_RelationType ,
                   string Ontology ,
                   long? Min_forw,
                   long? Max_forw,
                   long? Max_backw)
        {
            this.ID_Class_Left = ID_Class_Left;
            this.Name_Class_Left = Name_Class_Left;
            this.ID_Class_Right = ID_Class_Right;
            this.Name_Class_Right = Name_Class_Right;
            this.ID_RelationType = ID_RelationType;
            this.Name_RelationType = Name_RelationType;
            this.Ontology = Ontology;
            this.Min_Forw = Min_forw;
            this.Max_Forw = Max_forw;
            this.Max_Backw = Max_backw;
        }

        public clsClassRel()
        {
            
        }
    }
}
