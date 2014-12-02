using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsDirections
    {
        public clsOntologyItem Direction_LeftRight { get; private set; }
        public clsOntologyItem Direction_RightLeft { get; private set; }

        private clsClasses objClasses = new clsClasses();
        private clsTypes objTypes  = new clsTypes();

        public List<clsOntologyItem> Directions { get; private set; }

        public clsDirections()
        {
            Directions = new List<clsOntologyItem>();

            Direction_LeftRight = new clsOntologyItem
                {
                    GUID = "cc99d5365d564fd29d4f45b48af33029",
                    Name = "Left-Right",
                    GUID_Parent = objClasses.OItem_Class_Directions.GUID,
                    Type = objTypes.ObjectType
                };
            Direction_RightLeft = new clsOntologyItem
                {
                    GUID = "061243fc4c134bd5800c2c33b70e99b2",
                    Name = "Right-Left",
                    GUID_Parent = objClasses.OItem_Class_Directions.GUID,
                    Type = objTypes.ObjectType
                };

            Directions.Add(Direction_LeftRight);
            Directions.Add(Direction_RightLeft);
        }
    }
}
