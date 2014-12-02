using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace OntologyClasses.BaseClasses
{
    [ElasticType(Name = "clsAppDocuments")]
    public class clsAppDocuments
    {
        public string Id { get; set; }
        public Dictionary<string, object> Dict { get; set; }
    }
}
