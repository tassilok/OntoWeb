using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnt.Data
{
    [Flags]
    public enum NodeType
    {
        ParentNode = 1,
        AttributeNode = 2,
        LeftRightNode = 4,
        RightLeftNode = 8
    }
    public class ObjectRefParentNode
    {
        public string IdNode { get; set; }
        public string NameNode { get; set; }
        public NodeType TypeOfNode { get; set; }
        public List<ObjectRefChildNode> ChildNodes { get; set; }

    }
}
