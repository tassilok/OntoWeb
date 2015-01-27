using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OntologyClasses.BaseClasses;

namespace OntWeb
{
    public class WebServiceResult
    {
        public clsOntologyItem Result { get; set;  }
        public List<string> IndexList { get; set; }
        public List<clsOntologyItem> OntologyItems { get; set; }
        public List<clsOntologyItem> OntologyItems1 { get; set; }
        public List<clsOntologyItem> OntologyItems2 { get; set; }
        public List<clsClassAtt> ClassAttributes { get; set; }
        public List<clsClassRel> ClassRelations { get; set;  }
        public List<clsObjectAtt> ObjectAttributes { get; set; }
        public List<clsObjectRel> ObjectRelations { get; set; }
        public List<clsObjectTree> ObjectTrees { get; set; }
        public long Count { get; set; }
        public long OrderId { get; set; }
    }
}
