using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfOnt.OntoWeb;
using System.Reflection;
using WpfOnt.Data;
using System.Windows;
using WpfOnt.ImportExport;

namespace WpfOnt
{
    public class clsLocalConfig
    {
        private const string cstrID_Development = "fa13314314c34c0ebc85150daf512081";
        private clsImport objImport;

        public Globals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private DbWork objDBLevel_Config1;
        private DbWork objDBLevel_Config2;
	
	public clsOntologyItem OItem_attribute_attribute { get; set; }
public clsOntologyItem OItem_attribute_baseboardserial { get; set; }
public clsOntologyItem OItem_attribute_dbpostfix { get; set; }
public clsOntologyItem OItem_attribute_processorid { get; set; }
public clsOntologyItem OItem_attribute_relationtype { get; set; }
public clsOntologyItem OItem_attribute_token { get; set; }
public clsOntologyItem OItem_attribute_type { get; set; }
public clsOntologyItem OItem_attributetype_actor_finished { get; set; }
public clsOntologyItem OItem_attributetype_caption { get; set; }
public clsOntologyItem OItem_attributetype_initiator_finished { get; set; }
public clsOntologyItem OItem_attributetype_message { get; set; }
public clsOntologyItem OItem_attributetype_short { get; set; }
public clsOntologyItem OItem_attributetype_xml_text { get; set; }
public clsOntologyItem OItem_class_gui_caption { get; set; }
public clsOntologyItem OItem_class_gui_entires { get; set; }
public clsOntologyItem OItem_class_language { get; set; }
public clsOntologyItem OItem_class_localized_message { get; set; }
public clsOntologyItem OItem_class_messages { get; set; }
public clsOntologyItem OItem_class_module_function { get; set; }
public clsOntologyItem OItem_class_modulesession { get; set; }
public clsOntologyItem OItem_class_tooltip_messages { get; set; }
public clsOntologyItem OItem_object_ontology_module { get; set; }
public clsOntologyItem OItem_object_sem_manager { get; set; }
public clsOntologyItem OItem_relationtype_actoritems { get; set; }
public clsOntologyItem OItem_relationtype_belonging_attribute { get; set; }
public clsOntologyItem OItem_relationtype_belonging_resource { get; set; }
public clsOntologyItem OItem_relationtype_belonging_token { get; set; }
public clsOntologyItem OItem_relationtype_belonging_type { get; set; }
public clsOntologyItem OItem_relationtype_belongs_to { get; set; }
public clsOntologyItem OItem_relationtype_belongsto { get; set; }
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_errormessage { get; set; }
public clsOntologyItem OItem_relationtype_initiatoritems { get; set; }
public clsOntologyItem OItem_relationtype_inputmessage { get; set; }
public clsOntologyItem OItem_relationtype_is_defined_by { get; set; }
public clsOntologyItem OItem_relationtype_is_on { get; set; }
public clsOntologyItem OItem_relationtype_is_written_in { get; set; }
public clsOntologyItem OItem_relationtype_isinstate { get; set; }
public clsOntologyItem OItem_relationtype_offered_by { get; set; }
public clsOntologyItem OItem_relationtype_offers_for { get; set; }
public clsOntologyItem OItem_relationtype_relationtype { get; set; }
public clsOntologyItem OItem_relationtype_sourceslocatedin { get; set; }
public clsOntologyItem OItem_relationtype_superordinate { get; set; }
public clsOntologyItem OItem_relationtype_user_message { get; set; }
public clsOntologyItem OItem_token_filter_integration_level { get; set; }
public clsOntologyItem OItem_token_full_integration_level { get; set; }
public clsOntologyItem OItem_token_information_integration_level { get; set; }
public clsOntologyItem OItem_token_integration_level_menu { get; set; }
public clsOntologyItem OItem_token_type_integration_level { get; set; }
public clsOntologyItem OItem_type_developmentversion { get; set; }
public clsOntologyItem OItem_type_direction { get; set; }
public clsOntologyItem OItem_type_filesystem_management { get; set; }
public clsOntologyItem OItem_type_folder { get; set; }
public clsOntologyItem OItem_type_integration_level { get; set; }
public clsOntologyItem OItem_type_logstate { get; set; }
public clsOntologyItem OItem_type_module { get; set; }
public clsOntologyItem OItem_type_module_activator { get; set; }
public clsOntologyItem OItem_type_module_management { get; set; }
public clsOntologyItem OItem_type_sem_manager { get; set; }
public clsOntologyItem OItem_type_server { get; set; }
public clsOntologyItem OItem_type_softwaredevelopment { get; set; }
public clsOntologyItem OItem_type_system { get; set; }

  public List<clsOntologyItem> OList_Ontologies;
	
private void get_Data_DevelopmentConfig()
        {
            var searchOntologiesOfDevelopment = new List<clsObjectRel> {new clsObjectRel {ID_Other = cstrID_Development, 
                                                                                             ID_RelationType = Globals.RelationType_belongingResource.GUID, 
                                                                                             ID_Parent_Object = Globals.Class_Ontologies.GUID}};

            var objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(searchOntologiesOfDevelopment, boolIDs: false);
            if (objOItem_Result.GUID == Globals.LState_Success.GUID)
            {
                OList_Ontologies = objDBLevel_Config1.OList_ObjectRel.OrderBy(o => o.OrderID).Select(o => new clsOntologyItem {GUID = o.ID_Object,
                                                                                                                                              Name = o.Name_Object,
                                                                                                                                              GUID_Parent = o.ID_Parent_Object,
                                                                                                                                              Type = Globals.Type_Object}).ToList();
                if (OList_Ontologies.Any())
                {
                    var objORL_Ontology_To_OntolgyItems = OList_Ontologies.Select(o => new clsObjectRel {ID_Object = o.GUID,
                                                                                                                     ID_RelationType = Globals.RelationType_contains.GUID,
                                                                                                                     ID_Parent_Other = Globals.Class_OntologyItems.GUID}).ToList();

                    objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:false);
                    if (objOItem_Result.GUID == Globals.LState_Success.GUID)
                    {
                        if (objDBLevel_Config1.OList_ObjectRel.Any())
                        {

                            objORL_Ontology_To_OntolgyItems = objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel {ID_Object = oi.ID_Other,
                                                                                                                                            ID_RelationType = Globals.RelationType_belongingAttribute.GUID}).ToList();

                            objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel {ID_Object = oi.ID_Other,
                                                                                                                                            ID_RelationType = Globals.RelationType_belongingClass.GUID}));

                            objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel {ID_Object = oi.ID_Other,
                                                                                                                                            ID_RelationType = Globals.RelationType_belongingObject.GUID}));

                            objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel {ID_Object = oi.ID_Other,
                                                                                                                                            ID_RelationType = Globals.RelationType_belongingRelationType.GUID}));
                            
                            objOItem_Result = objDBLevel_Config2.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:false);
                            if (objOItem_Result.GUID == Globals.LState_Success.GUID)
                            {
                                if (!objDBLevel_Config2.OList_ObjectRel.Any())
                                {
                                    throw new Exception("Config-Error");
                                }
                            }
                            else
                            {
                                throw new Exception("Config-Error");
                            }
                        }
                        else
                        {
                            throw new Exception("Config-Error");
                        }

                    }
                }
                else
                {
                    throw new Exception("Config-Error");
                }

            }

        }
  
	public clsLocalConfig()
        {
            Globals = new Globals();
            set_DBConnection();
            get_Config();
        }

    public clsLocalConfig(Globals Globals)
        {
            this.Globals = Globals;
            set_DBConnection();
            get_Config();
        }
  
	private void set_DBConnection()
        {
            objDBLevel_Config1 = new DbWork(Globals);
            objDBLevel_Config2 = new DbWork(Globals);
			objImport = new clsImport(Globals);
        }
  
	private void get_Config()
        {
            try
            {
                get_Data_DevelopmentConfig();
                get_Config_AttributeTypes();
                get_Config_RelationTypes();
                get_Config_Classes();
                get_Config_Objects();
            }
            catch(Exception ex)
            {
                var objAssembly = Assembly.GetExecutingAssembly();
                AssemblyTitleAttribute[] objCustomAttributes = (AssemblyTitleAttribute[]) objAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                var strTitle = "Unbekannt";
                if (objCustomAttributes.Length == 1) 
                {
                    strTitle = objCustomAttributes.First().Title;
                }
                if (MessageBox.Show(strTitle + ": Die notwendigen Basisdaten konnten nicht geladen werden! Soll versucht werden, sie in der Datenbank " +
                          Globals.Index + "@" + Globals.Server + " zu erzeugen?", "Datenstrukturen",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var objOItem_Result = objImport.ImportTemplates(objAssembly);
                    if (objOItem_Result.GUID != Globals.LState_Error.GUID)
                    {
                        get_Data_DevelopmentConfig();
                        get_Config_AttributeTypes();
                        get_Config_RelationTypes();
                        get_Config_Classes();
                        get_Config_Objects();
                    }
                    else
                    {
                        throw new Exception("Config not importable");
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
  
	private void get_Config_AttributeTypes()
        {

		var objOList_attribute_attribute = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                            join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_attribute".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_attribute.Any())
            {
                OItem_attribute_attribute = new clsOntologyItem()
                {
                    GUID = objOList_attribute_attribute.First().ID_Other,
                    Name = objOList_attribute_attribute.First().Name_Other,
                    GUID_Parent = objOList_attribute_attribute.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attribute_baseboardserial = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_baseboardserial".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_baseboardserial.Any())
            {
                OItem_attribute_baseboardserial = new clsOntologyItem()
                {
                    GUID = objOList_attribute_baseboardserial.First().ID_Other,
                    Name = objOList_attribute_baseboardserial.First().Name_Other,
                    GUID_Parent = objOList_attribute_baseboardserial.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attribute_dbpostfix = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_dbpostfix".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_dbpostfix.Any())
            {
                OItem_attribute_dbpostfix = new clsOntologyItem()
                {
                    GUID = objOList_attribute_dbpostfix.First().ID_Other,
                    Name = objOList_attribute_dbpostfix.First().Name_Other,
                    GUID_Parent = objOList_attribute_dbpostfix.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attribute_processorid = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_processorid".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_processorid.Any())
            {
                OItem_attribute_processorid = new clsOntologyItem()
                {
                    GUID = objOList_attribute_processorid.First().ID_Other,
                    Name = objOList_attribute_processorid.First().Name_Other,
                    GUID_Parent = objOList_attribute_processorid.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attribute_relationtype = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_relationtype".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_relationtype.Any())
            {
                OItem_attribute_relationtype = new clsOntologyItem()
                {
                    GUID = objOList_attribute_relationtype.First().ID_Other,
                    Name = objOList_attribute_relationtype.First().Name_Other,
                    GUID_Parent = objOList_attribute_relationtype.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attribute_token = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                            join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_token".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_token.Any())
            {
                OItem_attribute_token = new clsOntologyItem()
                {
                    GUID = objOList_attribute_token.First().ID_Other,
                    Name = objOList_attribute_token.First().Name_Other,
                    GUID_Parent = objOList_attribute_token.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attribute_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_type".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_type.Any())
            {
                OItem_attribute_type = new clsOntologyItem()
                {
                    GUID = objOList_attribute_type.First().ID_Other,
                    Name = objOList_attribute_type.First().Name_Other,
                    GUID_Parent = objOList_attribute_type.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_actor_finished = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_actor_finished".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_actor_finished.Any())
            {
                OItem_attributetype_actor_finished = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_actor_finished.First().ID_Other,
                    Name = objOList_attributetype_actor_finished.First().Name_Other,
                    GUID_Parent = objOList_attributetype_actor_finished.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_caption = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_caption".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_caption.Any())
            {
                OItem_attributetype_caption = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_caption.First().ID_Other,
                    Name = objOList_attributetype_caption.First().Name_Other,
                    GUID_Parent = objOList_attributetype_caption.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_initiator_finished = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                             join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_initiator_finished".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_initiator_finished.Any())
            {
                OItem_attributetype_initiator_finished = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_initiator_finished.First().ID_Other,
                    Name = objOList_attributetype_initiator_finished.First().Name_Other,
                    GUID_Parent = objOList_attributetype_initiator_finished.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_message = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_message".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_message.Any())
            {
                OItem_attributetype_message = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_message.First().ID_Other,
                    Name = objOList_attributetype_message.First().Name_Other,
                    GUID_Parent = objOList_attributetype_message.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_short = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_short".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_short.Any())
            {
                OItem_attributetype_short = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_short.First().ID_Other,
                    Name = objOList_attributetype_short.First().Name_Other,
                    GUID_Parent = objOList_attributetype_short.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_xml_text = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_xml_text".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_xml_text.Any())
            {
                OItem_attributetype_xml_text = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_xml_text.First().ID_Other,
                    Name = objOList_attributetype_xml_text.First().Name_Other,
                    GUID_Parent = objOList_attributetype_xml_text.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
  
	private void get_Config_RelationTypes()
        {
            var objOList_relationtype_actoritems = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_actoritems".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_actoritems.Any())
            {
                OItem_relationtype_actoritems = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_actoritems.First().ID_Other,
                    Name = objOList_relationtype_actoritems.First().Name_Other,
                    GUID_Parent = objOList_relationtype_actoritems.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belonging_attribute = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                             join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belonging_attribute".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_attribute.Any())
            {
                OItem_relationtype_belonging_attribute = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_attribute.First().ID_Other,
                    Name = objOList_relationtype_belonging_attribute.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_attribute.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belonging_resource = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                            join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belonging_resource".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_resource.Any())
            {
                OItem_relationtype_belonging_resource = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_resource.First().ID_Other,
                    Name = objOList_relationtype_belonging_resource.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_resource.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belonging_token = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belonging_token".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_token.Any())
            {
                OItem_relationtype_belonging_token = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_token.First().ID_Other,
                    Name = objOList_relationtype_belonging_token.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_token.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belonging_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belonging_type".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_type.Any())
            {
                OItem_relationtype_belonging_type = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_type.First().ID_Other,
                    Name = objOList_relationtype_belonging_type.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_type.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belongs_to = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belongs_to".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belongs_to.Any())
            {
                OItem_relationtype_belongs_to = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belongs_to.First().ID_Other,
                    Name = objOList_relationtype_belongs_to.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belongs_to.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belongsto = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belongsto".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belongsto.Any())
            {
                OItem_relationtype_belongsto = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belongsto.First().ID_Other,
                    Name = objOList_relationtype_belongsto.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belongsto.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_contains = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_contains".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_contains.Any())
            {
                OItem_relationtype_contains = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_contains.First().ID_Other,
                    Name = objOList_relationtype_contains.First().Name_Other,
                    GUID_Parent = objOList_relationtype_contains.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_errormessage = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_errormessage".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_errormessage.Any())
            {
                OItem_relationtype_errormessage = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_errormessage.First().ID_Other,
                    Name = objOList_relationtype_errormessage.First().Name_Other,
                    GUID_Parent = objOList_relationtype_errormessage.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_initiatoritems = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_initiatoritems".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_initiatoritems.Any())
            {
                OItem_relationtype_initiatoritems = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_initiatoritems.First().ID_Other,
                    Name = objOList_relationtype_initiatoritems.First().Name_Other,
                    GUID_Parent = objOList_relationtype_initiatoritems.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_inputmessage = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_inputmessage".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_inputmessage.Any())
            {
                OItem_relationtype_inputmessage = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_inputmessage.First().ID_Other,
                    Name = objOList_relationtype_inputmessage.First().Name_Other,
                    GUID_Parent = objOList_relationtype_inputmessage.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_is_defined_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_is_defined_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_is_defined_by.Any())
            {
                OItem_relationtype_is_defined_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_defined_by.First().ID_Other,
                    Name = objOList_relationtype_is_defined_by.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is_defined_by.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_is_on = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_is_on".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_is_on.Any())
            {
                OItem_relationtype_is_on = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_on.First().ID_Other,
                    Name = objOList_relationtype_is_on.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is_on.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_is_written_in = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_is_written_in".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_is_written_in.Any())
            {
                OItem_relationtype_is_written_in = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_written_in.First().ID_Other,
                    Name = objOList_relationtype_is_written_in.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is_written_in.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_isinstate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_isinstate".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_isinstate.Any())
            {
                OItem_relationtype_isinstate = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_isinstate.First().ID_Other,
                    Name = objOList_relationtype_isinstate.First().Name_Other,
                    GUID_Parent = objOList_relationtype_isinstate.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_offered_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_offered_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_offered_by.Any())
            {
                OItem_relationtype_offered_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_offered_by.First().ID_Other,
                    Name = objOList_relationtype_offered_by.First().Name_Other,
                    GUID_Parent = objOList_relationtype_offered_by.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_offers_for = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_offers_for".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_offers_for.Any())
            {
                OItem_relationtype_offers_for = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_offers_for.First().ID_Other,
                    Name = objOList_relationtype_offers_for.First().Name_Other,
                    GUID_Parent = objOList_relationtype_offers_for.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_relationtype = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_relationtype".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_relationtype.Any())
            {
                OItem_relationtype_relationtype = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_relationtype.First().ID_Other,
                    Name = objOList_relationtype_relationtype.First().Name_Other,
                    GUID_Parent = objOList_relationtype_relationtype.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_sourceslocatedin = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                          join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_sourceslocatedin".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_sourceslocatedin.Any())
            {
                OItem_relationtype_sourceslocatedin = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_sourceslocatedin.First().ID_Other,
                    Name = objOList_relationtype_sourceslocatedin.First().Name_Other,
                    GUID_Parent = objOList_relationtype_sourceslocatedin.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_superordinate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_superordinate".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_superordinate.Any())
            {
                OItem_relationtype_superordinate = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_superordinate.First().ID_Other,
                    Name = objOList_relationtype_superordinate.First().Name_Other,
                    GUID_Parent = objOList_relationtype_superordinate.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_user_message = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_user_message".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_user_message.Any())
            {
                OItem_relationtype_user_message = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_user_message.First().ID_Other,
                    Name = objOList_relationtype_user_message.First().Name_Other,
                    GUID_Parent = objOList_relationtype_user_message.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
  
	private void get_Config_Objects()
        {
            var objOList_object_ontology_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_ontology_module".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_ontology_module.Any())
            {
                OItem_object_ontology_module = new clsOntologyItem()
                {
                    GUID = objOList_object_ontology_module.First().ID_Other,
                    Name = objOList_object_ontology_module.First().Name_Other,
                    GUID_Parent = objOList_object_ontology_module.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_sem_manager = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_sem_manager".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_sem_manager.Any())
            {
                OItem_object_sem_manager = new clsOntologyItem()
                {
                    GUID = objOList_object_sem_manager.First().ID_Other,
                    Name = objOList_object_sem_manager.First().Name_Other,
                    GUID_Parent = objOList_object_sem_manager.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_token_filter_integration_level = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_filter_integration_level".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_filter_integration_level.Any())
            {
                OItem_token_filter_integration_level = new clsOntologyItem()
                {
                    GUID = objOList_token_filter_integration_level.First().ID_Other,
                    Name = objOList_token_filter_integration_level.First().Name_Other,
                    GUID_Parent = objOList_token_filter_integration_level.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_token_full_integration_level = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_full_integration_level".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_full_integration_level.Any())
            {
                OItem_token_full_integration_level = new clsOntologyItem()
                {
                    GUID = objOList_token_full_integration_level.First().ID_Other,
                    Name = objOList_token_full_integration_level.First().Name_Other,
                    GUID_Parent = objOList_token_full_integration_level.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_token_information_integration_level = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                                join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_information_integration_level".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_information_integration_level.Any())
            {
                OItem_token_information_integration_level = new clsOntologyItem()
                {
                    GUID = objOList_token_information_integration_level.First().ID_Other,
                    Name = objOList_token_information_integration_level.First().Name_Other,
                    GUID_Parent = objOList_token_information_integration_level.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_token_integration_level_menu = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_integration_level_menu".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_integration_level_menu.Any())
            {
                OItem_token_integration_level_menu = new clsOntologyItem()
                {
                    GUID = objOList_token_integration_level_menu.First().ID_Other,
                    Name = objOList_token_integration_level_menu.First().Name_Other,
                    GUID_Parent = objOList_token_integration_level_menu.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_token_type_integration_level = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_type_integration_level".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_type_integration_level.Any())
            {
                OItem_token_type_integration_level = new clsOntologyItem()
                {
                    GUID = objOList_token_type_integration_level.First().ID_Other,
                    Name = objOList_token_type_integration_level.First().Name_Other,
                    GUID_Parent = objOList_token_type_integration_level.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
  
	private void get_Config_Classes()
        {
            var objOList_class_gui_caption = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_gui_caption".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_gui_caption.Any())
            {
                OItem_class_gui_caption = new clsOntologyItem()
                {
                    GUID = objOList_class_gui_caption.First().ID_Other,
                    Name = objOList_class_gui_caption.First().Name_Other,
                    GUID_Parent = objOList_class_gui_caption.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_gui_entires = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_gui_entires".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_gui_entires.Any())
            {
                OItem_class_gui_entires = new clsOntologyItem()
                {
                    GUID = objOList_class_gui_entires.First().ID_Other,
                    Name = objOList_class_gui_entires.First().Name_Other,
                    GUID_Parent = objOList_class_gui_entires.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_language = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_language".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_language.Any())
            {
                OItem_class_language = new clsOntologyItem()
                {
                    GUID = objOList_class_language.First().ID_Other,
                    Name = objOList_class_language.First().Name_Other,
                    GUID_Parent = objOList_class_language.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_localized_message = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_localized_message".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_localized_message.Any())
            {
                OItem_class_localized_message = new clsOntologyItem()
                {
                    GUID = objOList_class_localized_message.First().ID_Other,
                    Name = objOList_class_localized_message.First().Name_Other,
                    GUID_Parent = objOList_class_localized_message.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_messages = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_messages".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_messages.Any())
            {
                OItem_class_messages = new clsOntologyItem()
                {
                    GUID = objOList_class_messages.First().ID_Other,
                    Name = objOList_class_messages.First().Name_Other,
                    GUID_Parent = objOList_class_messages.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_module_function = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_module_function".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_module_function.Any())
            {
                OItem_class_module_function = new clsOntologyItem()
                {
                    GUID = objOList_class_module_function.First().ID_Other,
                    Name = objOList_class_module_function.First().Name_Other,
                    GUID_Parent = objOList_class_module_function.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_modulesession = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_modulesession".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_modulesession.Any())
            {
                OItem_class_modulesession = new clsOntologyItem()
                {
                    GUID = objOList_class_modulesession.First().ID_Other,
                    Name = objOList_class_modulesession.First().Name_Other,
                    GUID_Parent = objOList_class_modulesession.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_tooltip_messages = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_tooltip_messages".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_tooltip_messages.Any())
            {
                OItem_class_tooltip_messages = new clsOntologyItem()
                {
                    GUID = objOList_class_tooltip_messages.First().ID_Other,
                    Name = objOList_class_tooltip_messages.First().Name_Other,
                    GUID_Parent = objOList_class_tooltip_messages.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_developmentversion = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_developmentversion".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_developmentversion.Any())
            {
                OItem_type_developmentversion = new clsOntologyItem()
                {
                    GUID = objOList_type_developmentversion.First().ID_Other,
                    Name = objOList_type_developmentversion.First().Name_Other,
                    GUID_Parent = objOList_type_developmentversion.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_direction = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_direction".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_direction.Any())
            {
                OItem_type_direction = new clsOntologyItem()
                {
                    GUID = objOList_type_direction.First().ID_Other,
                    Name = objOList_type_direction.First().Name_Other,
                    GUID_Parent = objOList_type_direction.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_filesystem_management = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_filesystem_management".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_filesystem_management.Any())
            {
                OItem_type_filesystem_management = new clsOntologyItem()
                {
                    GUID = objOList_type_filesystem_management.First().ID_Other,
                    Name = objOList_type_filesystem_management.First().Name_Other,
                    GUID_Parent = objOList_type_filesystem_management.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_folder = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_folder".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_folder.Any())
            {
                OItem_type_folder = new clsOntologyItem()
                {
                    GUID = objOList_type_folder.First().ID_Other,
                    Name = objOList_type_folder.First().Name_Other,
                    GUID_Parent = objOList_type_folder.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_integration_level = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_integration_level".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_integration_level.Any())
            {
                OItem_type_integration_level = new clsOntologyItem()
                {
                    GUID = objOList_type_integration_level.First().ID_Other,
                    Name = objOList_type_integration_level.First().Name_Other,
                    GUID_Parent = objOList_type_integration_level.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_logstate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_logstate".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_logstate.Any())
            {
                OItem_type_logstate = new clsOntologyItem()
                {
                    GUID = objOList_type_logstate.First().ID_Other,
                    Name = objOList_type_logstate.First().Name_Other,
                    GUID_Parent = objOList_type_logstate.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_module".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_module.Any())
            {
                OItem_type_module = new clsOntologyItem()
                {
                    GUID = objOList_type_module.First().ID_Other,
                    Name = objOList_type_module.First().Name_Other,
                    GUID_Parent = objOList_type_module.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_module_activator = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_module_activator".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_module_activator.Any())
            {
                OItem_type_module_activator = new clsOntologyItem()
                {
                    GUID = objOList_type_module_activator.First().ID_Other,
                    Name = objOList_type_module_activator.First().Name_Other,
                    GUID_Parent = objOList_type_module_activator.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_module_management = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_module_management".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_module_management.Any())
            {
                OItem_type_module_management = new clsOntologyItem()
                {
                    GUID = objOList_type_module_management.First().ID_Other,
                    Name = objOList_type_module_management.First().Name_Other,
                    GUID_Parent = objOList_type_module_management.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_sem_manager = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                             join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_sem_manager".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_sem_manager.Any())
            {
                OItem_type_sem_manager = new clsOntologyItem()
                {
                    GUID = objOList_type_sem_manager.First().ID_Other,
                    Name = objOList_type_sem_manager.First().Name_Other,
                    GUID_Parent = objOList_type_sem_manager.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_server = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_server".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_server.Any())
            {
                OItem_type_server = new clsOntologyItem()
                {
                    GUID = objOList_type_server.First().ID_Other,
                    Name = objOList_type_server.First().Name_Other,
                    GUID_Parent = objOList_type_server.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_softwaredevelopment = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                     join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                     join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_softwaredevelopment".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_softwaredevelopment.Any())
            {
                OItem_type_softwaredevelopment = new clsOntologyItem()
                {
                    GUID = objOList_type_softwaredevelopment.First().ID_Other,
                    Name = objOList_type_softwaredevelopment.First().Name_Other,
                    GUID_Parent = objOList_type_softwaredevelopment.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_type_system = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_system".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_system.Any())
            {
                OItem_type_system = new clsOntologyItem()
                {
                    GUID = objOList_type_system.First().ID_Other,
                    Name = objOList_type_system.First().Name_Other,
                    GUID_Parent = objOList_type_system.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
    }

}