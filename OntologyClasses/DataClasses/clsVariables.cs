using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsVariables
    {
        public clsOntologyItem Variable_ID_ITEM { get; private set; }
        public clsOntologyItem Variable_NAME_ITEM { get; private set; }
        public clsOntologyItem Variable_ID_PARENT { get; private set; }
        public clsOntologyItem Variable_ITEMLIST { get; private set; }
        public clsOntologyItem Variable_ID_CLASS { get; private set; }
        public clsOntologyItem Variable_ID_ATTRIBUTETYPE { get; private set; }
        public clsOntologyItem Variable_ID_DATATYPE { get; private set; }
        public clsOntologyItem Variable_MIN { get; private set; }
        public clsOntologyItem Variable_MAX { get; private set; }
        public clsOntologyItem Variable_ID_CLASS_LEFT { get; private set; }
        public clsOntologyItem Variable_ID_CLASS_RIGHT { get; private set; }
        public clsOntologyItem Variable_ID_RELATIONTYPE { get; private set; }
        public clsOntologyItem Variable_ONTOLOGY { get; private set; }
        public clsOntologyItem Variable_MIN_FORW { get; private set; }
        public clsOntologyItem Variable_MAX_FORW { get; private set; }
        public clsOntologyItem Variable_MAX_BACKW { get; private set; }
        public clsOntologyItem Variable_ID_ATTRIBUTE { get; private set; }
        public clsOntologyItem Variable_ID_OBJECT { get; private set; }
        public clsOntologyItem Variable_ORDERID { get; private set; }
        public clsOntologyItem Variable_VAL_NAMED { get; private set; }
        public clsOntologyItem Variable_VAL_BIT { get; private set; }
        public clsOntologyItem Variable_VAL_DATE { get; private set; }
        public clsOntologyItem Variable_VAL_DOUBLE { get; private set; }
        public clsOntologyItem Variable_VAL_LNG { get; private set; }
        public clsOntologyItem Variable_VAL_STRING { get; private set; }
        public clsOntologyItem Variable_ID_PARENT_OBJECT { get; private set; }
        public clsOntologyItem Variable_ID_OTHER { get; private set; }
        public clsOntologyItem Variable_ID_PARENT_OTHER { get; private set; }
        public clsOntologyItem Variable_ITEMTYPE { get; private set; }

        private clsClasses objClasses = new clsClasses();
        private clsTypes objTypes = new clsTypes();

        public List<clsOntologyItem> Variables { get; private set; }

        public clsVariables()
        {
            Variable_ID_ITEM = new clsOntologyItem
            {
                GUID = "0e616fd70a224f239e1abab12c58b49e",
                Name = "ID_ITEM",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_NAME_ITEM = new clsOntologyItem
            {
                GUID = "32f0d8d214f04a40b2f09f62bab83217",
                Name = "NAME_ITEM",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_PARENT = new clsOntologyItem
            {
                GUID = "2ba43444526547e293f81beb79683b27",
                Name = "ID_PARENT",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ITEMLIST = new clsOntologyItem
            {
                GUID = "4729ce1926a545e78071ef8a97b5a1b1",
                Name = "ITEMLIST",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_CLASS = new clsOntologyItem
            {
                GUID = "4a779bdfa1ec4f628a60b67409b2d9e3",
                Name = "ID_CLASS",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_ATTRIBUTETYPE = new clsOntologyItem
            {
                GUID = "338a0499726f4e749ccc89476db921c8",
                Name = "ID_ATTRIBUTETYPE",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_DATATYPE = new clsOntologyItem
            {
                GUID = "e47423602790422b9d296a6c8ee76c26",
                Name = "ID_DATATYPE",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_MIN = new clsOntologyItem
            {
                GUID = "73aaf96433cf4f188f868e4eb7ad7807",
                Name = "MIN",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_MAX = new clsOntologyItem
            {
                GUID = "44207891e2c148c5932917b3da73453a",
                Name = "MAX",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_CLASS_LEFT = new clsOntologyItem
            {
                GUID = "910131d61e2645039cf34ec644d0ed20",
                Name = "ID_CLASS_LEFT",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_CLASS_RIGHT = new clsOntologyItem
            {
                GUID = "ba4c1d597e164b47b07d5816e10d7f3b",
                Name = "ID_CLASS_RIGHT",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_RELATIONTYPE = new clsOntologyItem
            {
                GUID = "9bbafcb8725f44c2a78d5d479ccdd7e5",
                Name = "ID_RELATIONTYPE",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ONTOLOGY = new clsOntologyItem
            {
                GUID = "c71c87b6c336494186d6f83f06de7708",
                Name = "ONTOLOGY",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_MIN_FORW = new clsOntologyItem
            {
                GUID = "482ead68e4d34f898e48509deceb1089",
                Name = "MIN_FORW",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_MAX_FORW = new clsOntologyItem
            {
                GUID = "17d86bfb92c3416a841f69b47fefd305",
                Name = "MAX_FORW",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_MAX_BACKW = new clsOntologyItem
            {
                GUID = "8c20f1686e60424b8916e38fcf0cc74c",
                Name = "MAX_BACKW",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_ATTRIBUTE = new clsOntologyItem
            {
                GUID = "7a3a926992b84e83a81e8da061540c87",
                Name = "ID_ATTRIBUTE",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_OBJECT = new clsOntologyItem
            {
                GUID = "20ea20e0e6bd467c87f6b92a6f48b873",
                Name = "ID_OBJECT",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ORDERID = new clsOntologyItem
            {
                GUID = "1f31f8cf9e8d4d39a246356c37eb61a7",
                Name = "ORDERID",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_VAL_NAMED = new clsOntologyItem
            {
                GUID = "fd3e815dc31b4ab99deb83b37b0279c9",
                Name = "VAL_NAMED",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_VAL_BIT = new clsOntologyItem
            {
                GUID = "3d0c31cc2b1244f5b04c8a39a849d0fc",
                Name = "VAL_BIT",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_VAL_DATE = new clsOntologyItem
            {
                GUID = "56590716b42343f8b727a9f471990d70",
                Name = "VAL_DATE",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_VAL_DOUBLE = new clsOntologyItem
            {
                GUID = "1cde5cbdb67b4a2c9912cf5410359f03",
                Name = "VAL_DOUBLE",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_VAL_LNG = new clsOntologyItem
            {
                GUID = "cbab64c4745443d3a29793d008ee980c",
                Name = "VAL_LNG",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_VAL_STRING = new clsOntologyItem
            {
                GUID = "5ff48b2883984a179cba4e2d7f863b94",
                Name = "VAL_STRING",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_PARENT_OBJECT = new clsOntologyItem
            {
                GUID = "b914b702a3fb4ddc95a558cdf2c82cd8",
                Name = "ID_PARENT_OBJECT",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_OTHER = new clsOntologyItem
            {
                GUID = "4925a6f2d89f4ca39cb4fa9c2ed17e77",
                Name = "ID_OTHER",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_PARENT_OTHER = new clsOntologyItem
            {
                GUID = "f8ebef33eaaa4db793c5138dcb15bf64",
                Name = "ID_PARENT_OTHER",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ID_RELATIONTYPE = new clsOntologyItem
            {
                GUID = "9bbafcb8725f44c2a78d5d479ccdd7e5",
                Name = "ID_RELATIONTYPE",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };

            Variable_ITEMTYPE = new clsOntologyItem
            {
                GUID = "b665409bc31b4abcb0dde472b376bd45",
                Name = "ITEMTYPE",
                GUID_Parent = objClasses.OItem_Class_Variable.GUID,
                Type = objTypes.ObjectType
            };


            Variables = new List<clsOntologyItem>
                {
                    Variable_ID_ATTRIBUTE,
                    Variable_ID_ATTRIBUTETYPE,
                    Variable_ID_CLASS,
                    Variable_ID_CLASS_LEFT,
                    Variable_ID_CLASS_RIGHT,
                    Variable_ID_DATATYPE,
                    Variable_ID_ITEM,
                    Variable_ID_OBJECT,
                    Variable_ID_OTHER,
                    Variable_ID_PARENT,
                    Variable_ID_PARENT_OBJECT,
                    Variable_ID_PARENT_OTHER,
                    Variable_ID_RELATIONTYPE,
                    Variable_ITEMLIST,
                    Variable_MAX,
                    Variable_MAX_BACKW,
                    Variable_MAX_FORW,
                    Variable_MIN,
                    Variable_MIN_FORW,
                    Variable_NAME_ITEM,
                    Variable_ONTOLOGY,
                    Variable_ORDERID,
                    Variable_VAL_BIT,
                    Variable_VAL_DATE,
                    Variable_VAL_DOUBLE,
                    Variable_VAL_LNG,
                    Variable_VAL_NAMED,
                    Variable_VAL_STRING,
                    Variable_ITEMTYPE
                };
        }
        
    }
}



