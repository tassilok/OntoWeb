﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18051
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 11.0.50727.1
// 
namespace Windows8Ont.OServiceClassRel {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OServiceClassRel.OServiceClassRelSoap")]
    public interface OServiceClassRelSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Config", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.Config[]> ConfigAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassesByGuidParent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsOntologyItem[]> ClassesByGuidParentAsync(string GuidParent, bool allChildren);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassesChildsByGuidParentAndName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsOntologyItem[]> ClassesChildsByGuidParentAndNameAsync(string GuidParent, string name, bool allChildren, bool caseSensitive);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelations", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsAsync(bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelationsByLeftGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByLeftGuidAsync(string guidClass, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelationsByRightGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByRightGuidAsync(string guidClass, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelationsByRelationTypeGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByRelationTypeGuidAsync(string guidRelationType, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelationsByLeftGuid_RightGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByLeftGuid_RightGuidAsync(string guidLeft, string guidRight, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelationsByLeftGuid_RelationTypeGuid_RightGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByLeftGuid_RelationTypeGuid_RightGuidAsync(string guidLeft, string guidRelationType, string guidRight, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelationsByLeftGuid_RelationTypeGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByLeftGuid_RelationTypeGuidAsync(string guidLeft, string guidRelationType, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelationsByRelationTypeGuid_RightGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByRelationTypeGuid_RightGuidAsync(string guidRelationType, string guidRight, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelationsByMinForw", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByMinForwAsync(long minForw, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelationsByMaxForw", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByMaxForwAsync(long maxForw, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassRelationsByMaxBackw", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByMaxBackwAsync(long maxBackw, bool onlyIds);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Config : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string configItemField;
        
        private string configValueStringField;
        
        private int configValueIntField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ConfigItem {
            get {
                return this.configItemField;
            }
            set {
                this.configItemField = value;
                this.RaisePropertyChanged("ConfigItem");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ConfigValueString {
            get {
                return this.configValueStringField;
            }
            set {
                this.configValueStringField = value;
                this.RaisePropertyChanged("ConfigValueString");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int ConfigValueInt {
            get {
                return this.configValueIntField;
            }
            set {
                this.configValueIntField = value;
                this.RaisePropertyChanged("ConfigValueInt");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsClassRel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string iD_Class_LeftField;
        
        private string name_Class_LeftField;
        
        private string iD_Class_RightField;
        
        private string name_Class_RightField;
        
        private string iD_RelationTypeField;
        
        private string name_RelationTypeField;
        
        private string ontologyField;
        
        private System.Nullable<long> min_ForwField;
        
        private System.Nullable<long> max_ForwField;
        
        private System.Nullable<long> max_BackwField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ID_Class_Left {
            get {
                return this.iD_Class_LeftField;
            }
            set {
                this.iD_Class_LeftField = value;
                this.RaisePropertyChanged("ID_Class_Left");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Name_Class_Left {
            get {
                return this.name_Class_LeftField;
            }
            set {
                this.name_Class_LeftField = value;
                this.RaisePropertyChanged("Name_Class_Left");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ID_Class_Right {
            get {
                return this.iD_Class_RightField;
            }
            set {
                this.iD_Class_RightField = value;
                this.RaisePropertyChanged("ID_Class_Right");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Name_Class_Right {
            get {
                return this.name_Class_RightField;
            }
            set {
                this.name_Class_RightField = value;
                this.RaisePropertyChanged("Name_Class_Right");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string ID_RelationType {
            get {
                return this.iD_RelationTypeField;
            }
            set {
                this.iD_RelationTypeField = value;
                this.RaisePropertyChanged("ID_RelationType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Name_RelationType {
            get {
                return this.name_RelationTypeField;
            }
            set {
                this.name_RelationTypeField = value;
                this.RaisePropertyChanged("Name_RelationType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Ontology {
            get {
                return this.ontologyField;
            }
            set {
                this.ontologyField = value;
                this.RaisePropertyChanged("Ontology");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=7)]
        public System.Nullable<long> Min_Forw {
            get {
                return this.min_ForwField;
            }
            set {
                this.min_ForwField = value;
                this.RaisePropertyChanged("Min_Forw");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=8)]
        public System.Nullable<long> Max_Forw {
            get {
                return this.max_ForwField;
            }
            set {
                this.max_ForwField = value;
                this.RaisePropertyChanged("Max_Forw");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=9)]
        public System.Nullable<long> Max_Backw {
            get {
                return this.max_BackwField;
            }
            set {
                this.max_BackwField = value;
                this.RaisePropertyChanged("Max_Backw");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18058")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsOntologyItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private clsOntologyItem[] oList_RelField;
        
        private string gUIDField;
        
        private string gUID_ParentField;
        
        private string gUID_RelatedField;
        
        private string gUID_RelationField;
        
        private string nameField;
        
        private string captionField;
        
        private string additional1Field;
        
        private string additional2Field;
        
        private string typeField;
        
        private string filterField;
        
        private System.Nullable<int> imageIDField;
        
        private System.Nullable<int> versionField;
        
        private System.Nullable<long> levelField;
        
        private System.Nullable<bool> new_ItemField;
        
        private System.Nullable<bool> deletedField;
        
        private System.Nullable<bool> markField;
        
        private System.Nullable<bool> objectReferenceField;
        
        private System.Nullable<int> directionField;
        
        private System.Nullable<long> minField;
        
        private System.Nullable<long> max1Field;
        
        private System.Nullable<long> max2Field;
        
        private System.Nullable<long> val_LongField;
        
        private System.Nullable<bool> val_BoolField;
        
        private System.Nullable<System.DateTime> val_DateField;
        
        private System.Nullable<double> val_RealField;
        
        private string val_StringField;
        
        private System.Nullable<long> countField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public clsOntologyItem[] OList_Rel {
            get {
                return this.oList_RelField;
            }
            set {
                this.oList_RelField = value;
                this.RaisePropertyChanged("OList_Rel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string GUID {
            get {
                return this.gUIDField;
            }
            set {
                this.gUIDField = value;
                this.RaisePropertyChanged("GUID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string GUID_Parent {
            get {
                return this.gUID_ParentField;
            }
            set {
                this.gUID_ParentField = value;
                this.RaisePropertyChanged("GUID_Parent");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string GUID_Related {
            get {
                return this.gUID_RelatedField;
            }
            set {
                this.gUID_RelatedField = value;
                this.RaisePropertyChanged("GUID_Related");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string GUID_Relation {
            get {
                return this.gUID_RelationField;
            }
            set {
                this.gUID_RelationField = value;
                this.RaisePropertyChanged("GUID_Relation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Caption {
            get {
                return this.captionField;
            }
            set {
                this.captionField = value;
                this.RaisePropertyChanged("Caption");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Additional1 {
            get {
                return this.additional1Field;
            }
            set {
                this.additional1Field = value;
                this.RaisePropertyChanged("Additional1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Additional2 {
            get {
                return this.additional2Field;
            }
            set {
                this.additional2Field = value;
                this.RaisePropertyChanged("Additional2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Filter {
            get {
                return this.filterField;
            }
            set {
                this.filterField = value;
                this.RaisePropertyChanged("Filter");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=11)]
        public System.Nullable<int> ImageID {
            get {
                return this.imageIDField;
            }
            set {
                this.imageIDField = value;
                this.RaisePropertyChanged("ImageID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=12)]
        public System.Nullable<int> Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
                this.RaisePropertyChanged("Version");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=13)]
        public System.Nullable<long> Level {
            get {
                return this.levelField;
            }
            set {
                this.levelField = value;
                this.RaisePropertyChanged("Level");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=14)]
        public System.Nullable<bool> New_Item {
            get {
                return this.new_ItemField;
            }
            set {
                this.new_ItemField = value;
                this.RaisePropertyChanged("New_Item");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=15)]
        public System.Nullable<bool> Deleted {
            get {
                return this.deletedField;
            }
            set {
                this.deletedField = value;
                this.RaisePropertyChanged("Deleted");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=16)]
        public System.Nullable<bool> Mark {
            get {
                return this.markField;
            }
            set {
                this.markField = value;
                this.RaisePropertyChanged("Mark");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=17)]
        public System.Nullable<bool> ObjectReference {
            get {
                return this.objectReferenceField;
            }
            set {
                this.objectReferenceField = value;
                this.RaisePropertyChanged("ObjectReference");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=18)]
        public System.Nullable<int> Direction {
            get {
                return this.directionField;
            }
            set {
                this.directionField = value;
                this.RaisePropertyChanged("Direction");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=19)]
        public System.Nullable<long> Min {
            get {
                return this.minField;
            }
            set {
                this.minField = value;
                this.RaisePropertyChanged("Min");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=20)]
        public System.Nullable<long> Max1 {
            get {
                return this.max1Field;
            }
            set {
                this.max1Field = value;
                this.RaisePropertyChanged("Max1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=21)]
        public System.Nullable<long> Max2 {
            get {
                return this.max2Field;
            }
            set {
                this.max2Field = value;
                this.RaisePropertyChanged("Max2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=22)]
        public System.Nullable<long> Val_Long {
            get {
                return this.val_LongField;
            }
            set {
                this.val_LongField = value;
                this.RaisePropertyChanged("Val_Long");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=23)]
        public System.Nullable<bool> Val_Bool {
            get {
                return this.val_BoolField;
            }
            set {
                this.val_BoolField = value;
                this.RaisePropertyChanged("Val_Bool");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=24)]
        public System.Nullable<System.DateTime> Val_Date {
            get {
                return this.val_DateField;
            }
            set {
                this.val_DateField = value;
                this.RaisePropertyChanged("Val_Date");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=25)]
        public System.Nullable<double> Val_Real {
            get {
                return this.val_RealField;
            }
            set {
                this.val_RealField = value;
                this.RaisePropertyChanged("Val_Real");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string Val_String {
            get {
                return this.val_StringField;
            }
            set {
                this.val_StringField = value;
                this.RaisePropertyChanged("Val_String");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=27)]
        public System.Nullable<long> Count {
            get {
                return this.countField;
            }
            set {
                this.countField = value;
                this.RaisePropertyChanged("Count");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OServiceClassRelSoapChannel : Windows8Ont.OServiceClassRel.OServiceClassRelSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OServiceClassRelSoapClient : System.ServiceModel.ClientBase<Windows8Ont.OServiceClassRel.OServiceClassRelSoap>, Windows8Ont.OServiceClassRel.OServiceClassRelSoap {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public OServiceClassRelSoapClient() : 
                base(OServiceClassRelSoapClient.GetDefaultBinding(), OServiceClassRelSoapClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.OServiceClassRelSoap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OServiceClassRelSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(OServiceClassRelSoapClient.GetBindingForEndpoint(endpointConfiguration), OServiceClassRelSoapClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OServiceClassRelSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(OServiceClassRelSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OServiceClassRelSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(OServiceClassRelSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OServiceClassRelSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.Config[]> ConfigAsync() {
            return base.Channel.ConfigAsync();
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsOntologyItem[]> ClassesByGuidParentAsync(string GuidParent, bool allChildren) {
            return base.Channel.ClassesByGuidParentAsync(GuidParent, allChildren);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsOntologyItem[]> ClassesChildsByGuidParentAndNameAsync(string GuidParent, string name, bool allChildren, bool caseSensitive) {
            return base.Channel.ClassesChildsByGuidParentAndNameAsync(GuidParent, name, allChildren, caseSensitive);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsAsync(bool onlyIds) {
            return base.Channel.ClassRelationsAsync(onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByLeftGuidAsync(string guidClass, bool onlyIds) {
            return base.Channel.ClassRelationsByLeftGuidAsync(guidClass, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByRightGuidAsync(string guidClass, bool onlyIds) {
            return base.Channel.ClassRelationsByRightGuidAsync(guidClass, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByRelationTypeGuidAsync(string guidRelationType, bool onlyIds) {
            return base.Channel.ClassRelationsByRelationTypeGuidAsync(guidRelationType, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByLeftGuid_RightGuidAsync(string guidLeft, string guidRight, bool onlyIds) {
            return base.Channel.ClassRelationsByLeftGuid_RightGuidAsync(guidLeft, guidRight, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByLeftGuid_RelationTypeGuid_RightGuidAsync(string guidLeft, string guidRelationType, string guidRight, bool onlyIds) {
            return base.Channel.ClassRelationsByLeftGuid_RelationTypeGuid_RightGuidAsync(guidLeft, guidRelationType, guidRight, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByLeftGuid_RelationTypeGuidAsync(string guidLeft, string guidRelationType, bool onlyIds) {
            return base.Channel.ClassRelationsByLeftGuid_RelationTypeGuidAsync(guidLeft, guidRelationType, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByRelationTypeGuid_RightGuidAsync(string guidRelationType, string guidRight, bool onlyIds) {
            return base.Channel.ClassRelationsByRelationTypeGuid_RightGuidAsync(guidRelationType, guidRight, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByMinForwAsync(long minForw, bool onlyIds) {
            return base.Channel.ClassRelationsByMinForwAsync(minForw, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByMaxForwAsync(long maxForw, bool onlyIds) {
            return base.Channel.ClassRelationsByMaxForwAsync(maxForw, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassRel.clsClassRel[]> ClassRelationsByMaxBackwAsync(long maxBackw, bool onlyIds) {
            return base.Channel.ClassRelationsByMaxBackwAsync(maxBackw, onlyIds);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.OServiceClassRelSoap)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.OServiceClassRelSoap)) {
                return new System.ServiceModel.EndpointAddress("http://localhost/OntWeb/OServiceClassRel.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return OServiceClassRelSoapClient.GetBindingForEndpoint(EndpointConfiguration.OServiceClassRelSoap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return OServiceClassRelSoapClient.GetEndpointAddress(EndpointConfiguration.OServiceClassRelSoap);
        }
        
        public enum EndpointConfiguration {
            
            OServiceClassRelSoap,
        }
    }
}
