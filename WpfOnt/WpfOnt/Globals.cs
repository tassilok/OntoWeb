using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WpfOnt.OntoWeb;
using WpfOnt.Data;
using System.IO;
using System.Windows;
using System.Reflection;
using System.Management;
using WpfOnt.View;

namespace WpfOnt
{
    public class Globals
    {
        public clsFields Fields  { get; private set; }

        public clsTypes Types { get; private set; }

        public clsDataTypes DataTypes { get; private set; }

        public clsClasses Classes { get; private set; }

        public clsBaseClassAttributes ClassAtts { get; private set; }

        public clsBaseClassRelation ClassRels { get; private set; }

        public clsRelationTypes RelationTypes { get; private set; }

        public clsAttributeTypes AttributeTypes { get; private set; }

        public clsLogStates LogStates { get; private set; }

        public clsDirections Directions { get; private set; }

        public clsVariables Variables { get; private set; }

        public clsMappingRules MappingRules { get; private set; }

        public clsOntologyRelationRules OntologyRelationRules { get; private set; }

        public clsClassTypes ClassTypes { get; private set; }

        public clsOntologyItem Class_Ontologies
        {
            get { return Classes.OItem_Class_Ontologies; }
        }

        public clsOntologyItem Class_OntologyItems
        {
            get { return Classes.OItem_Class_OntologyItems; }
        }

        private string strEL_Server;
        private int intPort;
        private string strEL_Index;
        private string strRep_Index;

        private string strRep_Server;
        private string strRep_Instance;
        private string strRep_Database;

        private int cintSearchRange = 20000;

        private string strSearchPath_Modules;


        private string strRegEx_GUID;

        private string GUID_Session;

        private clsOntologyItem objOItem_Server;
        private clsOntologyItem objOItem_WMI_ProcessorID;
        private clsOntologyItem objOItem_WMI_BaseBoardSerial;

        private DbWork objDBLevel1;
        private DbWork objDBLevel2;

        private clsTransaction objTransaction;

        private List<clsModuleConfig> objModuleList;

        public List<clsObjectRel> DbModuleList { get; private set; }

        public Globals(bool ModuleLoad = true)
        {
            initialize(ModuleLoad);
        }

        public string GUIDFormat1(string strGUIDFormat2)
        {
            string strGUIDFormat1;

            strGUIDFormat1 = strGUIDFormat2.Insert(8, "-");
            strGUIDFormat1 = strGUIDFormat1.Insert(13, "-");
            strGUIDFormat1 = strGUIDFormat1.Insert(18, "-");
            strGUIDFormat1 = strGUIDFormat1.Insert(23, "-");

            return strGUIDFormat1;
        }

        public string GUIDFormat2(string strGUIDFormat1) 
        {
            return (strGUIDFormat1.Replace("-", ""));
        }


        public List<clsModuleForCommandLine> get_ModuleExecutablesInSearchPath()
        {
            var executableList = new List<clsModuleForCommandLine>();
            if (strSearchPath_Modules !=null)
            {
                if (Directory.Exists(strSearchPath_Modules))
                {
                    foreach (var strFolder in Directory.GetDirectories(strSearchPath_Modules))
                    {
                        foreach (var strFile in Directory.GetFiles(strFolder))
                        {
                            if (Path.GetExtension(strFile).ToLower() == ".exe")
                            {
                                var strFileName = Path.GetFileName(strFile);


                                try
                                {
                                    var objAssembly = Assembly.LoadFile(strFile);
                                    if (objAssembly != null)
                                    {
                                        if (objAssembly.GetName().Name != "vshost32")
                                        {

                                            var objGuidAttributes = objAssembly.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true);
                                            var objVersionAttributes = objAssembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true);
                                            if (objGuidAttributes.Any() && objVersionAttributes.Any())
                                            {
                                                var strModuleGuid = ((System.Runtime.InteropServices.GuidAttribute)objGuidAttributes.First()).Value.ToString().Replace("-", "");
                                                var strVersionsAll = ((AssemblyFileVersionAttribute) (objVersionAttributes.First())).Version.ToString();
                                                var strVersions = strVersionsAll.Split('.');

                                                var intMajor = 0;
                                                var intMinor = 0;
                                                var intBuild = 0;
                                                var intRevision = 0;

                                                if (strVersions.Count() == 4)
                                                {
                                                    intMajor = int.Parse(strVersions[0]);
                                                    intMinor = int.Parse(strVersions[1]);
                                                    intBuild = int.Parse(strVersions[2]);
                                                    intRevision = int.Parse(strVersions[3]);
                                                }
                                                else if (strVersions.Count() == 3)
                                                {
                                                    intMajor = int.Parse(strVersions[0]);
                                                    intMajor = int.Parse(strVersions[1]);
                                                    intBuild = int.Parse(strVersions[2]);
                                                }
                                                else if (strVersions.Count() == 2)
                                                {
                                                    intMajor = int.Parse(strVersions[0]);
                                                    intMajor = int.Parse(strVersions[1]);
                                                }
                                                else if (strVersions.Count() == 1)
                                                {
                                                    intMajor = int.Parse(strVersions[0]);
                                                }

                                                var objModule = new clsModuleForCommandLine {ModuleName = objAssembly.GetName().Name,
                                                                                                  ModuleGuid = strModuleGuid,
                                                                                                  Major = intMajor,
                                                                                                  Minor = intMinor,
                                                                                                  Build = intBuild,
                                                                                                  Revision = intRevision,
                                                                            ModulePath = strFile};
                                                executableList.Add(objModule);
                                            }

                                        
                                        }

                                    }
                                    objAssembly = null;
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }
                    }
                }
                else
                {
                    executableList = null;

                }
            }

            return executableList;
        }

        public string get_ConnectionStr(string strServer, string strInstance, string strDatabase)
        {
            string strConn;
            strConn = "Data Source=" + strServer;
            if (!string.IsNullOrEmpty(strInstance))
            {
                strConn = strConn + "\\" + strInstance;
            }
        
            strConn = strConn + ";Initial Catalog=" + strDatabase + ";Integrated Security=True";

            return strConn;
        }
       

        public clsOntologyItem RelationType_belongingResource 
        { get {
            return RelationTypes.OItem_RelationType_belongingResource;
        }
        }

        public  clsOntologyItem RelationType_isOfType 
            { get {
                return RelationTypes.OItem_RelationType_isOfType;
            }
        }

        public  clsOntologyItem RelationType_contains 
            { get {
                return RelationTypes.OItem_RelationType_Contains;
            }
        }

        public  clsOntologyItem RelationType_belongingAttribute 
            { get {
                return RelationTypes.OItem_RelationType_belongingAttribute;
            }
        }

        public  clsOntologyItem RelationType_belongingClass 
            { get {
                return RelationTypes.OItem_RelationType_belongingClass;
            }
        }

        public  clsOntologyItem RelationType_belongingObject 
            { get {
                return RelationTypes.OItem_RelationType_belongingObject;
            }
        }

        public  clsOntologyItem RelationType_belongingRelationType 
            { get {
                return RelationTypes.OItem_RelationType_belongingRelationType;
            }
        }

        public  clsOntologyItem RelationType_belongsTo 
            { get {
                return RelationTypes.OItem_RelationType_belongingsTo;
            }
        }

        public  clsOntologyItem RelationType_belonging 
            { get {
                return RelationTypes.OItem_RelationType_belonging;
            }
        }

        public  clsOntologyItem RelationType_Apply 
            { get {
                return RelationTypes.OItem_RelationType_Apply;
            }
        }

        public  clsOntologyItem RelationType_Dst 
            { get {
                return RelationTypes.OItem_RelationType_Dst;
            }
        }

        public  clsOntologyItem RelationType_Src 
            { get {
                return RelationTypes.OItem_RelationType_Src;
            }
        }

        public  string Rep_Server 
            { get {
                return strRep_Server;
            }
        }
        public  string Rep_Instance 
            { get {
                return strRep_Instance;
            }
        }
        public  string Rep_Database 
            { get {
                return strRep_Database;
            }
        }
        public  string Session 
            { get {
                return GUID_Session;
            }
        }
        public  int Port 
            { get {
                return intPort;
            }
        }

        public  int SearchRange 
            { get {
                return cintSearchRange;
            }
        }

        public  string Server 
            { get {
                return strEL_Server;
            }
        }

        public  string Index 
            { get {
                return strEL_Index;
            }
        }

        public  string Index_Rep 
            { get {
                return strRep_Index;
            }
        }

        public  string Type_AttributeType 
            { get {
                return Types.AttributeType;
            }
        }

        public  string Type_Class 
            { get {
                return Types.ClassType;
            }
        }

        public string Type_DataType 
            { get {
                return Types.DataType;
            }
        }

        public string Type_Object 
            { get {
                return Types.ObjectType;
            }
        }

        public string Type_ObjectAtt 
            { get {
                return Types.ObjectAtt;
            }
        }

        public string Type_ObjectRel 
            { get {
                return Types.ObjectRel;
            }
        }

        public string Type_Other 
            { get {
                return Types.Other;
            }
        }

        public string Type_Other_AttType 
            { get {
                return Types.Other_AttType;
            }
        }

        public string Type_Other_Classes 
            { get {
                return Types.Other_Classes;
            }
        }

        public string Type_Other_RelType 
            { get {
                return Types.Other_RelType;
            }
        }

        public string Type_RelationType 
            { get {
                return Types.RelationType;
            }
        }


        public string Type_ClassRel 
            { get {
                return Types.ClassRel;
            }
        }

        public string Type_ClassAtt 
            { get {
                return Types.ClassAtt;
            }
        }

        public string Field_ID_Object 
            { get {
                return Fields.ID_Object;
            }
        }

        public string Field_ID_Item 
            { get {
                return Fields.ID_Item;
            }
        }

        public string Field_ID_Class_Left 
            { get {
                return Fields.ID_Class_Left;
            }
        }

        public string Field_ID_Class_Right 
            { get {
                return Fields.ID_Class_Right;
            }
        }

        public string Field_Max_forw 
            { get {
                return Fields.Max_Forw;
            }
        }

        public string Field_Min_forw 
            { get {
                return Fields.Min_Forw;
            }
        }

        public string Field_Min 
            { get {
                return Fields.Min;
            }
        }

        public string Field_Max 
            { get {
                return Fields.Max;
            }
        }

        public string Field_Max_backw 
            { get {
                return Fields.Max_Backw;
            }
        }

        public string Field_ID_AttributeType 
            { get {
                return Fields.ID_AttributeType;
            }
        }

        public string Field_ID_Class 
            { get {
                return Fields.ID_Class;
            }
        }

        public string Field_ID_DataType 
            { get {
                return Fields.ID_DataType;
            }
        }

        public string Field_Ontology 
            { get {
                return Fields.Ontology;
            }
        }

        public string Field_ID_Parent 
            { get {
                return Fields.ID_Parent;
            }
        }

        public string Field_ID_Parent_Object 
            { get {
                return Fields.ID_Parent_Object;
            }
        }

        public string Field_ID_Parent_Other 
            { get {
                return Fields.ID_Parent_Other;
            }
        }

        public string Field_ID_RelationType 
            { get {
                return Fields.ID_RelationType;
            }
        }

        public string Field_ID_Other 
            { get {
                return Fields.ID_Other;
            }
        }

        public string Field_Name_AttributeType 
            { get {
                return Fields.Name_AttributeType;
            }
        }

        public string Field_Name_Object 
            { get {
                return Fields.Name_Object;
            }
        }

        public string Field_Name_Other 
            { get {
                return Fields.Name_Other;
            }
        }

        public string Field_Name_Item 
            { get {
                return Fields.Name_Item;
            }
        }

        public string Field_Name_RelationType 
            { get {
                return Fields.Name_RelationType;
            }
        }

        public string Field_OrderID 
            { get {
                return Fields.OrderID;
            }
        }

        public string Field_Val_Bool 
            { get {
                return Fields.Val_Bool;
            }
        }

        public string Field_Val_Datetime 
            { get {
                return Fields.Val_Datetime;
            }
        }

        public string Field_Val_Int 
            { get {
                return Fields.Val_Int;
            }
        }

        public string Field_Val_Real 
            { get {
                return Fields.Val_Real;
            }
        }

        public string Field_Val_String 
            { get {
                return Fields.Val_String;
            }
        }

        public string Field_Val_Name 
            { get {
                return Fields.Val_Name;
            }
        }

        public string Field_ID_Attribute 
            { get {
                return Fields.ID_Attribute;
            }
        }

        public clsOntologyItem Root 
            { get {
                return Classes.OItem_Class_Root;
            }
        }

        public clsOntologyItem DType_Bool 
            { get {
                return DataTypes.DType_Bool;
            }
        }

        public clsOntologyItem  DType_DateTime 
            { get {
                return DataTypes.DType_DateTime;
            }
        }

        public clsOntologyItem  DType_Int 
            { get {
                return DataTypes.DType_Int;
            }
        }

        public clsOntologyItem  DType_Real 
            { get {
                return DataTypes.DType_Real;
            }
        }

        public clsOntologyItem  DType_String 
            { get {
                return DataTypes.DType_String;
            }
        }

        public clsOntologyItem  LState_Delete 
            { get {
                return LogStates.LogState_Delete;
            }
        }

        public clsOntologyItem  LState_Error 
            { get {
                return LogStates.LogState_Error;
            }
        }

        public clsOntologyItem  LState_Exists 
            { get {
                return LogStates.LogState_Exists;
            }
        }

        public clsOntologyItem  LState_Insert 
            { get {
                return LogStates.LogState_Insert;
            }
        }

        public clsOntologyItem  LState_Nothing 
            { get {
                return LogStates.LogState_Nothing;
            }
        }

        public clsOntologyItem  LState_Relation 
            { get {
                return LogStates.LogState_Relation;
            }
        }

        public clsOntologyItem  LState_Success 
            { get {
                return LogStates.LogState_Success;
            }
        }

        public clsOntologyItem  LState_Update 
            { get {
                return LogStates.LogState_Update;
            }
        }

        public clsOntologyItem  Direction_LeftRight 
            { get {
                return Directions.Direction_LeftRight;
            }
        }

        public clsOntologyItem  Direction_RightLeft 
            { get {
                return Directions.Direction_RightLeft;
            }
        }


        public clsOntologyItem  MappingRule_NewItem
            { get {
                return MappingRules.MappingRule_NewItem;
            }
        }

        public clsOntologyItem  MappingRule_RemoveSrc
            { get {
                return MappingRules.MappingRule_RemoveSrc;
            }
        }

        public clsOntologyItem  MappingRule_SrcItemIsDstItem
            { get {
                return MappingRules.MappingRule_SrcItemIsDstItem;
            }
        }

        public bool is_GUID(string strText )
        {
            var objRegExp = new Regex(strRegEx_GUID);
            if (objRegExp.IsMatch(strText) && strText != "00000000000000000000000000000000")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void get_ConfigData()
        {
            strEL_Index = Properties.Settings.Default.Properties["Index"].DefaultValue.ToString();
            if (string.IsNullOrEmpty(strEL_Index))
            {
                throw new Exception("Config");
            }

            strEL_Server = Properties.Settings.Default.Properties["Server"].DefaultValue.ToString();
            if (string.IsNullOrEmpty(strEL_Server))
            {
                throw new Exception("Config");
            }

            var strEL_Port = Properties.Settings.Default.Properties["Port"].DefaultValue.ToString();
            if (!int.TryParse(strEL_Port, out intPort))
            {
                throw new Exception("Config");
            }


            strRep_Server = Properties.Settings.Default.Properties["server_report"].DefaultValue.ToString();
            if (string.IsNullOrEmpty(strRep_Server))
            {
                throw new Exception("Config");
            }

            strRep_Instance = Properties.Settings.Default.Properties["server_instance"].DefaultValue.ToString();
            if (string.IsNullOrEmpty(strRep_Instance))
            {
                throw new Exception("Config");
            }

            strRep_Database = Properties.Settings.Default.Properties["database"].DefaultValue.ToString();
            if (string.IsNullOrEmpty(strRep_Database))
            {
                throw new Exception("Config");
            }

            strRep_Index = Properties.Settings.Default.Properties["ReportIndex"].DefaultValue.ToString();
            if (string.IsNullOrEmpty(strRep_Index))
            {
                throw new Exception("Config");
            }

            strSearchPath_Modules = Properties.Settings.Default.Properties["ModuleSearchPath"].DefaultValue.ToString();
            if (string.IsNullOrEmpty(strSearchPath_Modules))
            {
                throw new Exception("Config");
            }
            else
            {
                strSearchPath_Modules = Environment.ExpandEnvironmentVariables(Properties.Settings.Default.Properties["ModuleSearchPath"].DefaultValue.ToString());
            }

        }

        private void LoadModules()
        {
            objModuleList = new List<clsModuleConfig>();


            foreach (var strFile in Directory.GetFiles(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)))
            {

                if (strFile.ToLower().EndsWith(".exe"))
                {
                    try
                    {
                        var objAssembly = Assembly.LoadFile(strFile);
                        var objTypes = objAssembly.GetTypes();
                        var intModuleCount = objModuleList.Count;
                        var objModuleConfig = new clsModuleConfig {Assembly = objAssembly};

                        if (objModuleConfig.Instance != null)
                        {
                            objModuleList.Add(objModuleConfig);
                        }

                        if (objModuleList.Count - intModuleCount > 0)
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

            }

        }

        
        private void initialize(bool ModuleLoad)
        {
            set_Session();
            get_ConfigData();

            Types = new clsTypes();
            LogStates = new clsLogStates();
            Fields = new clsFields();
            DataTypes = new clsDataTypes();
            Classes = new clsClasses();
            ClassAtts = new clsBaseClassAttributes();
            ClassRels = new clsBaseClassRelation();
            RelationTypes = new clsRelationTypes();
            AttributeTypes = new clsAttributeTypes();
            LogStates = new clsLogStates();
            Directions = new clsDirections();
            Variables = new clsVariables();
            MappingRules = new clsMappingRules();
            OntologyRelationRules = new clsOntologyRelationRules();
            ClassTypes = new clsClassTypes();

            var objOItem_Result = LogStates.LogState_Success.Clone();

            try
            {
                objDBLevel1 = new DbWork(Server, Port, Index, Index_Rep, SearchRange, Session);
                objDBLevel2 = new DbWork(Server, Port, Index, Index_Rep, SearchRange, Session);

                

                try
                {
                    objOItem_Result = test_Existance_OntologyDB();
                }
                catch (Exception ex)
                {
                    objOItem_Result = LogStates.LogState_Nothing.Clone();
                }
            }
            catch (Exception ex)
            {

            }

            try
            {
            


            if (objOItem_Result.GUID == LogStates.LogState_Nothing.GUID)
            {
                if (MessageBox.Show("Die Datenbank " + strEL_Index + "@" + strEL_Server + " existiert nicht. Soll sie erzeugt werden?", "Keine Datenbank", MessageBoxButton.YesNo) == MessageBoxResult.Yes) 
                {
                    if (create_Index().GUID == LogStates.LogState_Error.GUID)
                    {
                        MessageBox.Show("Die Datenbank konnte nicht erzeugt werden!", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Environment.Exit(0);
                    }
                    else
                    {
                        objOItem_Result = LogStates.LogState_Success.Clone();
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
                

            if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
            {
                objOItem_Result = test_Existance_BaseData();
                if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
                {
                    objTransaction = new clsTransaction(Server, Port, Index, Index_Rep, SearchRange, Session);

                    set_Computer();
                }
                else
                {
                    MessageBox.Show("Die Datenbank ist nicht konsistent! Die Anwendung wird beendet!","Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(1);
                }


                if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
                {
                    if (ModuleLoad)
                    {
                        LoadModules();
                    }

                }

            }
            }
            catch (Exception ex)
            {
                var objFrmConfig = new OConfig("Config-Error");
                objFrmConfig.ShowDialog();
                if (objFrmConfig.DialogResult == true)
                {
                    initialize(ModuleLoad);
                }
                else
                {
                    Environment.Exit(0);
                }

            }
        }
        


    private clsOntologyItem test_Existance_BaseData()
    {
        var objOItem_Result = LogStates.LogState_Success.Clone();

        //DataTypes
        objOItem_Result = objDBLevel1.get_Data_DataTyps();
        if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
        {
            var objOList_DType_NotExistant = (from objDataTypeShould in DataTypes.DataTypes
                                              join objDataTypeExist in objDBLevel1.OList_DataTypes on objDataTypeShould.GUID equals objDataTypeExist.GUID into objDataTypesExist
                                              from objDataTypeExist in objDataTypesExist.DefaultIfEmpty()
                                              where objDataTypeExist == null
                               select objDataTypeShould).ToList();

            if (objOList_DType_NotExistant.Any())
            {
                objOItem_Result = objDBLevel1.save_DataTypes(objOList_DType_NotExistant);
            }
        }

        //AttributeTypes
        if (objOItem_Result.GUID != LogStates.LogState_Error.GUID)
        {
            objOItem_Result = objDBLevel1.get_Data_AttributeType(AttributeTypes.AttributeTypes);
            if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
            {
                var objOList_AttTypes_NotExistant = (from objAttTypeShould in AttributeTypes.AttributeTypes
                                                     join objAttTypeExist in objDBLevel1.OList_AttributeTypes on objAttTypeShould.GUID equals objAttTypeExist.GUID into objAttTypesExist
                                                     from objAttTypeExist in objAttTypesExist.DefaultIfEmpty()
                                                     where objAttTypeExist == null
                                                     select objAttTypeShould).ToList();

                if (objOList_AttTypes_NotExistant.Any())
                {
                    foreach (clsOntologyItem objOItem_AttType in objOList_AttTypes_NotExistant)
                    {
                        objOItem_Result = objDBLevel1.save_AttributeType(objOItem_AttType);
                        if (objOItem_Result.GUID == LogStates.LogState_Error.GUID)
                        {
                            break;
                        }
                    }

                }
            }
        }

        //RelationTypes
        if (objOItem_Result.GUID != LogStates.LogState_Error.GUID)
        {
            objOItem_Result = objDBLevel1.get_Data_RelationTypes(RelationTypes.RelationTypes);
            if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
            {
                var objOList_RelTypes_NotExistant = (from objRelTypeShould in RelationTypes.RelationTypes
                                                     join objRelTypeExist in objDBLevel1.OList_RelationTypes on objRelTypeShould.GUID equals objRelTypeExist.GUID into objRelTypesExist 
                                                     from objRelTypeExist in objRelTypesExist.DefaultIfEmpty()
                                                     where objRelTypeExist == null
                                                     select objRelTypeShould).ToList();

                if (objOList_RelTypes_NotExistant.Any())
                {
                    foreach (clsOntologyItem objOItem_RelType in objOList_RelTypes_NotExistant)
                    {
                        objOItem_Result = objDBLevel1.save_RelationType(objOItem_RelType);
                        if (objOItem_Result.GUID == LogStates.LogState_Error.GUID)
                        {
                            break;
                        }

                    }

                }
            }
        }

        //Classes
        if (objOItem_Result.GUID != LogStates.LogState_Error.GUID)
        {
            objOItem_Result = objDBLevel1.get_Data_Classes(Classes.OList_Classes);
            if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
            {
                var objOList_Classes_NotExistant = (from objClassShould in Classes.OList_Classes
                                                    join objClassExist in objDBLevel1.OList_Classes on objClassShould.GUID equals objClassExist.GUID into objClassesExist
                                                    from objClassExist in objClassesExist.DefaultIfEmpty()
                                                    where objClassExist == null
                                                    select objClassShould).ToList();
                if (objOList_Classes_NotExistant.Any())
                {
                    foreach (clsOntologyItem objClass in objOList_Classes_NotExistant)
                    {
                        if (string.IsNullOrEmpty(objClass.GUID_Parent))
                        {
                            objOItem_Result = objDBLevel1.save_Class(objClass, true);
                        }
                        else
                        {
                            objOItem_Result = objDBLevel1.save_Class(objClass);
                        }

                        if (objOItem_Result.GUID == LogStates.LogState_Error.GUID)
                        {
                            break;
                        }
                    }

                }
            }
        }

        //Objects
        if (objOItem_Result.GUID != LogStates.LogState_Error.GUID)
        {
            var objOList_Objects = Directions.Directions.ToList();
            objOList_Objects.AddRange(LogStates.LogStates);
            objOList_Objects.AddRange(OntologyRelationRules.OntologyRelationRules);
            objOList_Objects.AddRange(Variables.Variables);
            objOList_Objects.AddRange(MappingRules.MappingRules);
            objOItem_Result = objDBLevel1.get_Data_Objects(objOList_Objects);
            if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
            {
                var objOList_Objects_NotExistant = (from objObjectShould in objOList_Objects
                                                    join objObjectExist in objDBLevel1.OList_Objects on objObjectShould.GUID equals objObjectExist.GUID into objObjectsExists
                                                    from objObjectExist in objObjectsExists.DefaultIfEmpty()
                                                    where objObjectExist == null
                                                    select objObjectShould).ToList();
                if (objOList_Objects_NotExistant.Any())
                {
                    objOItem_Result = objDBLevel1.save_Objects(objOList_Objects_NotExistant);

                }
            }
        }
        //ClassAttributes
        if (objOItem_Result.GUID != LogStates.LogState_Error.GUID)
        {
            var objOList_Classes = ClassAtts.ClassAtts.GroupBy(p => p.ID_Class).ToList().Join(Classes.OList_Classes, l => l.Key, r => r.GUID, (l, r) => r).ToList();

            var objOList_AttributeTypes = ClassAtts.ClassAtts.GroupBy(p => p.ID_AttributeType).ToList().Join(AttributeTypes.AttributeTypes, l => l.Key, r => r.GUID, (l, r) => r).ToList();


            objOItem_Result = objDBLevel1.get_Data_ClassAtt(objOList_Classes, objOList_AttributeTypes);
            if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
            {

                var objOList_ClassAtts_NotExistant = (from objClassAttShould in ClassAtts.ClassAtts
                                          join objClassAttExist in objDBLevel1.OList_ClassAtt_ID on 
                                            new { ID_Class = objClassAttShould.ID_Class, ID_AttributeType = objClassAttShould.ID_AttributeType} equals new { ID_Class = objClassAttExist.ID_Class, ID_AttributeType = objClassAttExist.ID_AttributeType} into objClassAttsExist
                                          from objClassAttExist in objClassAttsExist.DefaultIfEmpty()
                                          where objClassAttExist == null
                                          select objClassAttShould).ToList();

                
                if (objOList_ClassAtts_NotExistant.Any())
                {
                    objOItem_Result = objDBLevel1.save_ClassAttType(objOList_ClassAtts_NotExistant);
                }
            }

            


        }
        //ClassRelations
        if (objOItem_Result.GUID != LogStates.LogState_Error.GUID)
        {

            objOItem_Result = objDBLevel1.get_Data_ClassRel(ClassRels.ClassRelations, boolIDs:false);
            if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
            {

                var objOList_ClassRels_NotExistant = (from objClassRelShould in ClassRels.ClassRelations
                                          join objClassRelExist in objDBLevel1.OList_ClassRel on
                                          new { ID_Class_Left = objClassRelShould.ID_Class_Left, 
                                                ID_Class_Right = objClassRelShould.ID_Class_Right, 
                                                ID_RelationType = objClassRelShould.ID_RelationType } equals 
                                          new { ID_Class_Left = objClassRelExist.ID_Class_Left, 
                                                ID_Class_Right = objClassRelExist.ID_Class_Right,
                                                ID_RelationType = objClassRelExist.ID_RelationType } into objClassRelsExist 
                                          from objClassRelExist in objClassRelsExist.DefaultIfEmpty()
                                          where objClassRelExist == null
                                          select objClassRelShould).ToList();

         
                if (objOList_ClassRels_NotExistant.Any())
                {
                    objOItem_Result = objDBLevel1.save_ClassRel(ClassRels.ClassRelations);
                }

            }
        }
        return objOItem_Result;

    }

    private clsOntologyItem test_Existance_OntologyDB()
    {
        if (objDBLevel1.test_Index_Es())
        {
            return LogStates.LogState_Success.Clone();
        }
        else
        {
            return LogStates.LogState_Nothing.Clone();
        }
    }

    private clsOntologyItem create_Index()
    {
        if (objDBLevel1.create_Index_Es())
        {
            return LogStates.LogState_Success.Clone();
        }
        else
        {
            return LogStates.LogState_Error.Clone();
        }
    }
    private Globals()
    {
        strRegEx_GUID = "[A-Za-z0-9]{8}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{12}";

        initialize(false);
    }

        private void set_Session()
        {
            GUID_Session = Guid.NewGuid().ToString().Replace("-", "");
        }
    
        private void set_Computer()
        {
            ManagementObjectSearcher objWMI;
            string strProcessorID;
            string strBaseBoardSerial;
            clsOntologyItem objOItem_Result;

            clsObjectAtt objOAItem_ProcessorID;
            clsObjectAtt objOAItem_BaseBoardSerial;

            strProcessorID = "";
            objWMI = new ManagementObjectSearcher("Select ProcessorID FROM Win32_Processor");
            foreach (ManagementObject objWMIManagementObject in objWMI.Get())
            {
                strProcessorID = objWMIManagementObject["ProcessorID"].ToString();
                break;
            }

            strBaseBoardSerial = "";
            objWMI = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_Baseboard");
            foreach (ManagementObject objWMIManagementObject in objWMI.Get())
            {
                strBaseBoardSerial = objWMIManagementObject["SerialNumber"].ToString();
                break;
            }

            objOItem_Server = get_Computer_ByWMI(strProcessorID, strBaseBoardSerial);

            if (objOItem_Server == null)
            {
                objOItem_Server = new clsOntologyItem();
                objOItem_Server.GUID = Guid.NewGuid().ToString();
                objOItem_Server.Name = Environment.MachineName;
                objOItem_Server.GUID_Parent = Classes.OItem_Class_Server.GUID;
                objOItem_Server.Type = Type_Object;



                objOItem_Result = objTransaction.do_Transaction(objOItem_Server);

                if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
                {
                    objOAItem_BaseBoardSerial = new clsObjectAtt() {ID_AttributeType = AttributeTypes.OITem_AttributeType_WMI_BaseBoardSerial.GUID,
                                                                    ID_Object = objOItem_Server.GUID,
                                                                    ID_Class = objOItem_Server.GUID_Parent,
                                                                    ID_DataType = DataTypes.DType_String.GUID, 
                                                                    OrderID = 1,
                                                                    Val_String = strBaseBoardSerial,
                                                                    Val_Named = strBaseBoardSerial};

                    objOItem_Result = objTransaction.do_Transaction(objOAItem_BaseBoardSerial);

                    if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
                    {
                        objOAItem_ProcessorID = new clsObjectAtt() {ID_AttributeType = AttributeTypes.OItem_AttributeType_WMI_ProcessorID.GUID, 
                                                                           ID_Object = objOItem_Server.GUID,
                                                                           ID_Class = objOItem_Server.GUID_Parent,
                                                                           ID_DataType = DataTypes.DType_String.GUID,
                                                                           OrderID = 1,
                                                                           Val_String = strProcessorID,
                                                                           Val_Named = strProcessorID};

                        objOItem_Result = objTransaction.do_Transaction(objOAItem_ProcessorID);
                        if (objOItem_Result.GUID == LogStates.LogState_Error.GUID)
                        {
                            objTransaction.rollback();
                            throw new Exception("Config");
                        }
                    }
                    else
                    {
                        objTransaction.rollback();
                        throw new Exception("Config");
                    }
                }
                else
                {
                    throw new Exception("Config");
                }
            }
        }

        public clsOntologyItem get_Computer_ByWMI(string strProcessorID, string strBaseBoardSerial)
        {
            var objOAL_ProcessorID = new List< clsObjectAtt>();
            var objOAL_BaseBoardSerial = new List<clsObjectAtt>();
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_Computer = null;

            objOAL_ProcessorID.Add(new clsObjectAtt {ID_Class = Classes.OItem_Class_Server.GUID,
                                                         ID_AttributeType = AttributeTypes.OItem_AttributeType_WMI_ProcessorID.GUID,
                                                         Val_String = strProcessorID});


            objOItem_Result = objDBLevel1.get_Data_ObjectAtt(objOAL_ProcessorID, boolIDs:false);

            if (objOItem_Result.GUID == LogStates.LogState_Success.GUID)
            {
                objOAL_BaseBoardSerial.Add(new clsObjectAtt {ID_Class = Classes.OItem_Class_Server.GUID,
                                                                    ID_AttributeType = AttributeTypes.OITem_AttributeType_WMI_BaseBoardSerial.GUID,
                                                                    Val_String = strBaseBoardSerial});

                objOItem_Result = objDBLevel2.get_Data_ObjectAtt(objOAL_BaseBoardSerial);

                var objOList_Server = (from objServer in objDBLevel1.OList_ObjAtt
                                       join objServer2 in objDBLevel2.OList_ObjAtt_ID on objServer.ID_Object equals objServer2.ID_Object
                                       select new clsOntologyItem(objServer.ID_Object, objServer.Name_Object, objServer.ID_Class, Types.ObjectType)).ToList();

                if (objOList_Server.Any())
                {
                    objOItem_Computer = objOList_Server.First();
                }
                else
                {
                    objOItem_Computer = null;
                }
            }
            else
            {
                throw new Exception("Config");
            }

            return objOItem_Computer;
        }
    
        public string GetConfigName1(string strName)
        {
            string strResult = "";
            for (var i = 0;i<= strName.Length - 1;i++)
            {
                if (Char.IsLetterOrDigit(strName,i))
                {
                    strResult = strResult + strName.Substring(i, 1);
                }
                else
                {
                    strResult = strResult + "_";
                }
                
                    
            }

            return strResult;
        }
    
    }
}
