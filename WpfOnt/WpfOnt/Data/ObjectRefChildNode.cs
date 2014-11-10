using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnt.Data
{
    public class ObjectRefChildNode
    {
        public string IdNode
        {
            get { return IdLeft + "_" + IdRight + "_" + IdRight; }
        }

        public string NameNode
        {
            get
            {
                if (IdDirection == LocalConfig.Directions.Direction_LeftRight.GUID)
                {
                    return NameRel + " / " + NameRight + " (" + Min + " / " + Count + " / " + Max + ")";
                }
                else
                {
                    return NameRel + " / " + NameLeft + " (" + Min + " / " + Count + " / " + Max + ")";
                }
            }
        }
        public string IdLeft { get; set; }
        public string NameLeft { get; set; }
        public string IdRel { get; set; }
        public string NameRel { get; set; }
        public string IdRight { get; set; }
        public string NameRight { get; set; }
        public string IdDirection { get; set; }
        public long Min { get; set; }
        public long Count { get; set; }
        public long Max { get; set; }
        
    }
}
