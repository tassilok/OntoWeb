using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsLogStates
    {
        

        public clsOntologyItem LogState_Success { get; private set; }
        public clsOntologyItem LogState_Error { get; private set; }
        public clsOntologyItem LogState_Nothing { get; private set; }
        public clsOntologyItem LogState_Insert { get; private set; }
        public clsOntologyItem LogState_Update { get; private set; }
        public clsOntologyItem LogState_Delete { get; private set; }
        public clsOntologyItem LogState_Relation { get; private set; }
        public clsOntologyItem LogState_Exists { get; private set; }

        private clsClasses objClasses = new clsClasses();
        private clsTypes objTypes = new clsTypes();

        public List<clsOntologyItem> LogStates { get; private set; }

        public clsLogStates()
        {
            LogState_Delete = new clsOntologyItem
                {
                    GUID = "bb6a95553af640fc9fb0489d2678dff2",
                    Name = "Delete",
                    GUID_Parent = objClasses.OItem_Class_Logstate.GUID,
                    Type = objTypes.ObjectType
                };
            LogState_Error = new clsOntologyItem
                {
                    GUID = "cc71434176314b78b8f4385db073635f",
                    Name = "Error",
                    GUID_Parent = objClasses.OItem_Class_Logstate.GUID,
                    Type = objTypes.ObjectType
                };
            LogState_Exists = new clsOntologyItem
                {
                    GUID = "0b285306f64d4444bffe627a21687eff",
                    Name = "Exist",
                    GUID_Parent = objClasses.OItem_Class_Logstate.GUID,
                    Type = objTypes.ObjectType
                };
            LogState_Insert = new clsOntologyItem
                {
                    GUID = "a6df6ab2359045b1b32535334a2f574a",
                    Name = "Insert",
                    GUID_Parent = objClasses.OItem_Class_Logstate.GUID,
                    Type = objTypes.ObjectType
                };
            LogState_Nothing = new clsOntologyItem
                {
                    GUID = "95666887fb2a416e9624a48d48dc5446",
                    Name = "Nothing",
                    GUID_Parent = objClasses.OItem_Class_Logstate.GUID,
                    Type = objTypes.ObjectType
                };
            LogState_Relation = new clsOntologyItem
                {
                    GUID = "a46b74723c8e44a8b7853913b760db",
                    Name = "Relation",
                    GUID_Parent = objClasses.OItem_Class_Logstate.GUID,
                    Type = objTypes.ObjectType
                };
            LogState_Success = new clsOntologyItem
                {
                    GUID = "84251164265e4e0294b2ed7c40a02e56",
                    Name = "Success",
                    GUID_Parent = objClasses.OItem_Class_Logstate.GUID,
                    Type = objTypes.ObjectType
                };
            LogState_Update = new clsOntologyItem
                {
                    GUID = "2bf7e9d6fb9c40929b16ecc4fef7c072",
                    Name = "Update",
                    GUID_Parent = objClasses.OItem_Class_Logstate.GUID,
                    Type = objTypes.ObjectType
                };

            LogStates = new List<clsOntologyItem>
                {
                    LogState_Delete,
                    LogState_Error,
                    LogState_Exists,
                    LogState_Insert,
                    LogState_Nothing,
                    LogState_Relation,
                    LogState_Success,
                    LogState_Update
                };
        }
    }
}
