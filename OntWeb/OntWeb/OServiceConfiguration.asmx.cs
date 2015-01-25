using OntologyClasses.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace OntWeb
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für OServiceConfiguration
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Wenn der Aufruf dieses Webdiensts aus einem Skript zulässig sein soll, heben Sie mithilfe von ASP.NET AJAX die Kommentarmarkierung für die folgende Zeile auf. 
    // [System.Web.Script.Services.ScriptService]
    public class OServiceConfiguration : System.Web.Services.WebService
    {
        clsTypes types = new clsTypes();

        [WebMethod]
        public string Type_Object()
        {
            return types.ObjectType;
        }

        [WebMethod]
        public string Type_Class()
        {
            return types.ClassType;


        }

        [WebMethod]
        public string Type_AttributeType()
        {
            return types.AttributeType;
        }

        [WebMethod]
        public string Type_RelationType()
        {
            return types.RelationType;
        }

        [WebMethod]
        public clsLogStates OLogStates()
        {
            return new clsLogStates();
        }

        [WebMethod]
        public clsMappingRules OMappingRules()
        {
            return new clsMappingRules();
        }

        [WebMethod]
        public clsOntologyRelationRules ORelationRules()
        {
            return new clsOntologyRelationRules();
        }

        [WebMethod]
        public clsVariables OVariables()
        {
            return new clsVariables();
        }

        [WebMethod]
        public clsDirections ODirections()
        {
            return new clsDirections();
        }

        [WebMethod]
        public clsFields OFields()
        {
            return new clsFields();
        }

        [WebMethod]
        public List<Config> Config()
        {

            return Globals.Config;
        }

        [WebMethod]
        public string RegExGuid()
        {
            return Globals.RegEx_Guid;
        }
    }
}
