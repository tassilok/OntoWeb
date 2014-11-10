using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;
using System.Text.RegularExpressions;
using System.IO;

namespace OntWeb
{
    public static class Globals
    {

        private static readonly DataSetConfig.dtbl_BaseConfigDataTable dtblTConfig = new DataSetConfig.dtbl_BaseConfigDataTable();

        private static readonly clsTypes oTypes = new clsTypes();
        private static readonly clsAttributeTypes oAttributeTypes = new clsAttributeTypes();
        private static readonly clsClasses oClasses = new clsClasses();
        private static readonly clsRelationTypes oRelationTypes = new clsRelationTypes();
        private static readonly clsLogStates logStates = new clsLogStates();
        private static readonly clsMappingRules mappingRules = new clsMappingRules();
        private static readonly clsOntologyRelationRules ontologyRelationRules = new clsOntologyRelationRules();
        private static readonly clsVariables variables = new clsVariables();
        private static readonly clsDirections directions = new clsDirections();
        private static readonly clsFields fields = new clsFields();

        public static string ElIndex { get; private set; }
        public static string ElServer { get; private set; }
        public static int ElPort { get; private set; }
        public static int ElSearchRange { get; private set; }
        public static string RepServer { get; private set; }
        public static string RepInstance { get; private set; }
        public static string RepDatabase { get; private set; }
        public static string RepIndex { get; private set; }

        public static List<Config> Config = new List<Config>();

        public static clsTypes OTypes
        {
            get { return oTypes; }
        }

        public static clsAttributeTypes OAttributeTypes
        {
            get { return oAttributeTypes; }
        }

        
        public static clsClasses OClasses
        {
            get { return oClasses; }
        }

        public static clsRelationTypes ORelationTypes
        {
            get { return oRelationTypes; }
        }

        public static clsLogStates LogStates
        {
            get { return logStates; }
        }

        public static clsMappingRules MappingRules
        {
            get { return mappingRules; }
        }

        public static clsOntologyRelationRules OntologyRelationRules
        {
            get { return ontologyRelationRules; }
        }

        public static clsVariables Variables
        {
            get { return variables; }
        }

        public static clsDirections Directions
        {
            get { return directions; }
        }

        public static clsFields Fields
        {
            get { return fields; }
        }

        public static bool IsGuid(string guid)
        {
            var objRegExp = new Regex(RegEx_Guid);
            if (objRegExp.IsMatch(guid) && guid != "00000000000000000000000000000000")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string RegEx_Guid 
        {
            get { return "[A-Za-z0-9]{8}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{12}"; }
        }

        public static clsOntologyItem LoadConfig(string pathConfig = null)
        {
            var OItem_Result = LogStates.LogState_Success.Clone();
            var path = HttpContext.Current.Server.MapPath("~/");
            dtblTConfig.Clear();
            dtblTConfig.ReadXml(pathConfig +  (pathConfig == null ? path + "\\Config\\" : (pathConfig.EndsWith("\\") ? "" : "\\")) + "Config_ont.xml");
            if (dtblTConfig.Rows.Count > 0)
            {
                var dataRows = dtblTConfig.Select("ConfigItem_Name='Index'");
                if (dataRows.Any())
                {
                    ElIndex = dataRows.First()["ConfigItem_Value"].ToString();
                    Config.Add(new Config{ConfigItem = "ElIndex", ConfigValueString = ElIndex});
                }
                else
                {
                    OItem_Result = LogStates.LogState_Error;
                }

                dataRows = dtblTConfig.Select("ConfigItem_Name='Server'");
                if (dataRows.Any())
                {
                    ElServer = dataRows.First()["ConfigItem_Value"].ToString();
                    Config.Add(new Config { ConfigItem = "ElServer", ConfigValueString = ElServer });
                    
                }
                else
                {
                    OItem_Result = LogStates.LogState_Error;
                }

                
                dataRows = dtblTConfig.Select("ConfigItem_Name='Port'");
                if (dataRows.Any())
                {
                    var port = dataRows.First()["ConfigItem_Value"].ToString();
                    int lPort;
                    if (int.TryParse(port, out lPort))
                    {
                        ElPort = lPort;
                        Config.Add(new Config { ConfigItem = "ElPort", ConfigValueInt = ElPort });
                    }
                    else
                    {
                        OItem_Result = LogStates.LogState_Error;
                    }
                    
                }
                else
                {
                    OItem_Result = LogStates.LogState_Error;
                }

                dataRows = dtblTConfig.Select("ConfigItem_Name='server_report'");
                if (dataRows.Any())
                {
                    RepServer = dataRows.First()["ConfigItem_Value"].ToString();
                    Config.Add(new Config { ConfigItem = "RepServer", ConfigValueString = RepServer });
                    
                }
                else
                {
                    OItem_Result = LogStates.LogState_Error;
                }

                dataRows = dtblTConfig.Select("ConfigItem_Name='server_instance'");
                if (dataRows.Any())
                {
                    RepInstance = dataRows.First()["ConfigItem_Value"].ToString();
                    Config.Add(new Config { ConfigItem = "RepInstance", ConfigValueString = RepInstance });
                    
                }
                else
                {
                    OItem_Result = LogStates.LogState_Error;
                }

                dataRows = dtblTConfig.Select("ConfigItem_Name='database'");
                if (dataRows.Any())
                {
                    RepDatabase = dataRows.First()["ConfigItem_Value"].ToString();
                    Config.Add(new Config { ConfigItem = "RepDatabase", ConfigValueString = RepDatabase });
                }
                else
                {
                    OItem_Result = LogStates.LogState_Error;
                }

                dataRows = dtblTConfig.Select("ConfigItem_Name='ReportIndex'");
                if (dataRows.Any())
                {
                    RepIndex = dataRows.First()["ConfigItem_Value"].ToString();
                    Config.Add(new Config { ConfigItem = "RepIndex", ConfigValueString = RepIndex });
                }
                else
                {
                    OItem_Result = LogStates.LogState_Error;
                }
                dataRows = dtblTConfig.Select("ConfigItem_Name='SearchRange'");
                if (dataRows.Any())
                {
                    var searchRange = dataRows.First()["ConfigItem_Value"].ToString();
                    int iSearchRange;
                    if (int.TryParse(searchRange, out iSearchRange))
                    {
                        ElSearchRange = iSearchRange;
                        Config.Add(new Config { ConfigItem = "ElSearchRange", ConfigValueInt = ElSearchRange });
                        
                    }
                    else
                    {
                        OItem_Result = LogStates.LogState_Error;
                    }

                }
                else
                {
                    OItem_Result = LogStates.LogState_Error;
                }
            }

            return OItem_Result;
        }
    }
}