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
namespace Windows8Ont.OServiceClassAtt {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OServiceClassAtt.OServiceClassAttSoap")]
    public interface OServiceClassAttSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Config", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.Config[]> ConfigAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObjectAtts", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.clsObjectAtt[]> ObjectAttsAsync(bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassAttributes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.clsClassAtt[]> ClassAttributesAsync(bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassAttributesByClassGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.clsClassAtt[]> ClassAttributesByClassGuidAsync(string guidClass, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassAttributesByAttributeTypeGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.clsClassAtt[]> ClassAttributesByAttributeTypeGuidAsync(string guidAttributeType, bool onlyIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ClassAttributesByClassGuid_ttributeTypeGuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.clsClassAtt[]> ClassAttributesByClassGuid_ttributeTypeGuidAsync(string guidAttributeType, string guidClass, bool onlyIds);
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
    public partial class clsClassAtt : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string iD_ClassField;
        
        private string name_ClassField;
        
        private string iD_AttributeTypeField;
        
        private string name_AttributeTypeField;
        
        private string iD_DataTypeField;
        
        private string name_DataTypeField;
        
        private System.Nullable<long> minField;
        
        private System.Nullable<long> maxField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ID_Class {
            get {
                return this.iD_ClassField;
            }
            set {
                this.iD_ClassField = value;
                this.RaisePropertyChanged("ID_Class");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Name_Class {
            get {
                return this.name_ClassField;
            }
            set {
                this.name_ClassField = value;
                this.RaisePropertyChanged("Name_Class");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ID_AttributeType {
            get {
                return this.iD_AttributeTypeField;
            }
            set {
                this.iD_AttributeTypeField = value;
                this.RaisePropertyChanged("ID_AttributeType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Name_AttributeType {
            get {
                return this.name_AttributeTypeField;
            }
            set {
                this.name_AttributeTypeField = value;
                this.RaisePropertyChanged("Name_AttributeType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string ID_DataType {
            get {
                return this.iD_DataTypeField;
            }
            set {
                this.iD_DataTypeField = value;
                this.RaisePropertyChanged("ID_DataType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Name_DataType {
            get {
                return this.name_DataTypeField;
            }
            set {
                this.name_DataTypeField = value;
                this.RaisePropertyChanged("Name_DataType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=6)]
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=7)]
        public System.Nullable<long> Max {
            get {
                return this.maxField;
            }
            set {
                this.maxField = value;
                this.RaisePropertyChanged("Max");
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
    public partial class clsObjectAtt : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string iD_AttributeField;
        
        private string iD_AttributeTypeField;
        
        private string name_AttributeTypeField;
        
        private string iD_ObjectField;
        
        private string name_ObjectField;
        
        private string iD_ClassField;
        
        private string name_ClassField;
        
        private string val_NamedField;
        
        private string iD_DataTypeField;
        
        private string name_DataTypeField;
        
        private System.Nullable<bool> val_BitField;
        
        private System.Nullable<long> val_LngField;
        
        private System.Nullable<double> val_DoubleField;
        
        private System.Nullable<System.DateTime> val_DateField;
        
        private string val_StringField;
        
        private System.Nullable<long> orderIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ID_Attribute {
            get {
                return this.iD_AttributeField;
            }
            set {
                this.iD_AttributeField = value;
                this.RaisePropertyChanged("ID_Attribute");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ID_AttributeType {
            get {
                return this.iD_AttributeTypeField;
            }
            set {
                this.iD_AttributeTypeField = value;
                this.RaisePropertyChanged("ID_AttributeType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Name_AttributeType {
            get {
                return this.name_AttributeTypeField;
            }
            set {
                this.name_AttributeTypeField = value;
                this.RaisePropertyChanged("Name_AttributeType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ID_Object {
            get {
                return this.iD_ObjectField;
            }
            set {
                this.iD_ObjectField = value;
                this.RaisePropertyChanged("ID_Object");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Name_Object {
            get {
                return this.name_ObjectField;
            }
            set {
                this.name_ObjectField = value;
                this.RaisePropertyChanged("Name_Object");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string ID_Class {
            get {
                return this.iD_ClassField;
            }
            set {
                this.iD_ClassField = value;
                this.RaisePropertyChanged("ID_Class");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Name_Class {
            get {
                return this.name_ClassField;
            }
            set {
                this.name_ClassField = value;
                this.RaisePropertyChanged("Name_Class");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Val_Named {
            get {
                return this.val_NamedField;
            }
            set {
                this.val_NamedField = value;
                this.RaisePropertyChanged("Val_Named");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string ID_DataType {
            get {
                return this.iD_DataTypeField;
            }
            set {
                this.iD_DataTypeField = value;
                this.RaisePropertyChanged("ID_DataType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Name_DataType {
            get {
                return this.name_DataTypeField;
            }
            set {
                this.name_DataTypeField = value;
                this.RaisePropertyChanged("Name_DataType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=10)]
        public System.Nullable<bool> Val_Bit {
            get {
                return this.val_BitField;
            }
            set {
                this.val_BitField = value;
                this.RaisePropertyChanged("Val_Bit");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=11)]
        public System.Nullable<long> Val_Lng {
            get {
                return this.val_LngField;
            }
            set {
                this.val_LngField = value;
                this.RaisePropertyChanged("Val_Lng");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=12)]
        public System.Nullable<double> Val_Double {
            get {
                return this.val_DoubleField;
            }
            set {
                this.val_DoubleField = value;
                this.RaisePropertyChanged("Val_Double");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=13)]
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
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=15)]
        public System.Nullable<long> OrderID {
            get {
                return this.orderIDField;
            }
            set {
                this.orderIDField = value;
                this.RaisePropertyChanged("OrderID");
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
    public interface OServiceClassAttSoapChannel : Windows8Ont.OServiceClassAtt.OServiceClassAttSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OServiceClassAttSoapClient : System.ServiceModel.ClientBase<Windows8Ont.OServiceClassAtt.OServiceClassAttSoap>, Windows8Ont.OServiceClassAtt.OServiceClassAttSoap {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public OServiceClassAttSoapClient() : 
                base(OServiceClassAttSoapClient.GetDefaultBinding(), OServiceClassAttSoapClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.OServiceClassAttSoap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OServiceClassAttSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(OServiceClassAttSoapClient.GetBindingForEndpoint(endpointConfiguration), OServiceClassAttSoapClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OServiceClassAttSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(OServiceClassAttSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OServiceClassAttSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(OServiceClassAttSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OServiceClassAttSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.Config[]> ConfigAsync() {
            return base.Channel.ConfigAsync();
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.clsObjectAtt[]> ObjectAttsAsync(bool onlyIds) {
            return base.Channel.ObjectAttsAsync(onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.clsClassAtt[]> ClassAttributesAsync(bool onlyIds) {
            return base.Channel.ClassAttributesAsync(onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.clsClassAtt[]> ClassAttributesByClassGuidAsync(string guidClass, bool onlyIds) {
            return base.Channel.ClassAttributesByClassGuidAsync(guidClass, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.clsClassAtt[]> ClassAttributesByAttributeTypeGuidAsync(string guidAttributeType, bool onlyIds) {
            return base.Channel.ClassAttributesByAttributeTypeGuidAsync(guidAttributeType, onlyIds);
        }
        
        public System.Threading.Tasks.Task<Windows8Ont.OServiceClassAtt.clsClassAtt[]> ClassAttributesByClassGuid_ttributeTypeGuidAsync(string guidAttributeType, string guidClass, bool onlyIds) {
            return base.Channel.ClassAttributesByClassGuid_ttributeTypeGuidAsync(guidAttributeType, guidClass, onlyIds);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.OServiceClassAttSoap)) {
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
            if ((endpointConfiguration == EndpointConfiguration.OServiceClassAttSoap)) {
                return new System.ServiceModel.EndpointAddress("http://localhost/OntWeb/OServiceClassAtt.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return OServiceClassAttSoapClient.GetBindingForEndpoint(EndpointConfiguration.OServiceClassAttSoap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return OServiceClassAttSoapClient.GetEndpointAddress(EndpointConfiguration.OServiceClassAttSoap);
        }
        
        public enum EndpointConfiguration {
            
            OServiceClassAttSoap,
        }
    }
}
