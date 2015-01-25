using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.ESTypes
{
    public class EsEdge_ClassRelation
    {
        public string ID_Class_Left { get; set; }
        public string ID_Class_Right { get; set; }
        public string Ontology { get; set; }
        public string ID_RelationType { get; set; }
        public long Min_forw { get; set; }
        public long Max_forw { get; set; }
        public long Max_backw { get; set; }
    }
}
