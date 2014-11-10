using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WpfOnt.OServiceOItems;
using WpfOnt.OServiceConfiguration;

namespace WpfOnt
{
    public static class LocalConfig
    {
        public static clsLogStates LogStates;
        public static string Type_AttributeType;
        public static string Type_Class;
        public static string Type_Object;
        public static string Type_RelationType;
        public static clsDirections Directions;
        public static List<Config> Config;

        private static string RegEx_GUID;

        public static bool IsGuid(string guid)
        {
            var objRegExp = new Regex(RegEx_GUID);
            if (objRegExp.IsMatch(guid) && guid != "00000000000000000000000000000000")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Initialize()
        {
            var oserviceConfiguration = new OServiceConfigurationSoapClient();

            LogStates = oserviceConfiguration.OLogStates();
            Directions = oserviceConfiguration.ODirections();
            Type_AttributeType = oserviceConfiguration.Type_AttributeType();
            Type_Class = oserviceConfiguration.Type_Class();
            Type_RelationType = oserviceConfiguration.Type_RelationType();
            Type_Object = oserviceConfiguration.Type_Object();
            Config = new List<Config>(oserviceConfiguration.Config());
            RegEx_GUID = oserviceConfiguration.RegExGuid();

        }
    }
}
