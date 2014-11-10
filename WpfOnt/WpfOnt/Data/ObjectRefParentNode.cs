using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnt.Data
{
    public class ObjectRefParentNode
    {
        public string IdNode { get; set; }
        public string NameNode { get; set; }
        public List<ObjectRefChildNode> ChildNodes { get; set; }

    }
}
