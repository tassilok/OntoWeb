using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.ESTypes
{
    public class EsEdge_ObjectRelation
    {
        public string Ontology { get; set; }
        public string ID_Other { get; set; }
        public string ID_Parent_Object { get; set; }
        public string ID_Parent_Other { get; set; }
        public string ID_RelationType { get; set; }
        public string ID_Object { get; set; }
        public long OrderID { get; set; }
    }
}
