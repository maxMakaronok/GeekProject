﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogServiceProxy.LogService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LogAddMessage", Namespace="http://schemas.datacontract.org/2004/07/ServiceModels")]
    [System.SerializableAttribute()]
    public partial class LogAddMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EventTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LogPathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ServiceIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EventType {
            get {
                return this.EventTypeField;
            }
            set {
                if ((this.EventTypeField.Equals(value) != true)) {
                    this.EventTypeField = value;
                    this.RaisePropertyChanged("EventType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LogPath {
            get {
                return this.LogPathField;
            }
            set {
                if ((object.ReferenceEquals(this.LogPathField, value) != true)) {
                    this.LogPathField = value;
                    this.RaisePropertyChanged("LogPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ServiceId {
            get {
                return this.ServiceIdField;
            }
            set {
                if ((this.ServiceIdField.Equals(value) != true)) {
                    this.ServiceIdField = value;
                    this.RaisePropertyChanged("ServiceId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LogFilter", Namespace="http://schemas.datacontract.org/2004/07/ServiceModels")]
    [System.SerializableAttribute()]
    public partial class LogFilter : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> EventDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> EventIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ServiceIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> SkipField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> TakeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> EventDate {
            get {
                return this.EventDateField;
            }
            set {
                if ((this.EventDateField.Equals(value) != true)) {
                    this.EventDateField = value;
                    this.RaisePropertyChanged("EventDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> EventId {
            get {
                return this.EventIdField;
            }
            set {
                if ((this.EventIdField.Equals(value) != true)) {
                    this.EventIdField = value;
                    this.RaisePropertyChanged("EventId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ServiceId {
            get {
                return this.ServiceIdField;
            }
            set {
                if ((this.ServiceIdField.Equals(value) != true)) {
                    this.ServiceIdField = value;
                    this.RaisePropertyChanged("ServiceId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Skip {
            get {
                return this.SkipField;
            }
            set {
                if ((this.SkipField.Equals(value) != true)) {
                    this.SkipField = value;
                    this.RaisePropertyChanged("Skip");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Take {
            get {
                return this.TakeField;
            }
            set {
                if ((this.TakeField.Equals(value) != true)) {
                    this.TakeField = value;
                    this.RaisePropertyChanged("Take");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LogGetMessage", Namespace="http://schemas.datacontract.org/2004/07/ServiceModels")]
    [System.SerializableAttribute()]
    public partial class LogGetMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EventDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EventNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ItemIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserLoginField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EventDate {
            get {
                return this.EventDateField;
            }
            set {
                if ((this.EventDateField.Equals(value) != true)) {
                    this.EventDateField = value;
                    this.RaisePropertyChanged("EventDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EventName {
            get {
                return this.EventNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EventNameField, value) != true)) {
                    this.EventNameField = value;
                    this.RaisePropertyChanged("EventName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ItemId {
            get {
                return this.ItemIdField;
            }
            set {
                if ((this.ItemIdField.Equals(value) != true)) {
                    this.ItemIdField = value;
                    this.RaisePropertyChanged("ItemId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceName {
            get {
                return this.ServiceNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceNameField, value) != true)) {
                    this.ServiceNameField = value;
                    this.RaisePropertyChanged("ServiceName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserLogin {
            get {
                return this.UserLoginField;
            }
            set {
                if ((object.ReferenceEquals(this.UserLoginField, value) != true)) {
                    this.UserLoginField = value;
                    this.RaisePropertyChanged("UserLogin");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LogEventsForUpdate", Namespace="http://schemas.datacontract.org/2004/07/ServiceModels")]
    [System.SerializableAttribute()]
    public partial class LogEventsForUpdate : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EventIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsEnableField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EventId {
            get {
                return this.EventIdField;
            }
            set {
                if ((this.EventIdField.Equals(value) != true)) {
                    this.EventIdField = value;
                    this.RaisePropertyChanged("EventId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsEnable {
            get {
                return this.IsEnableField;
            }
            set {
                if ((this.IsEnableField.Equals(value) != true)) {
                    this.IsEnableField = value;
                    this.RaisePropertyChanged("IsEnable");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Error", Namespace="http://schemas.datacontract.org/2004/07/ServiceModels")]
    [System.SerializableAttribute()]
    public partial class Error : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Code {
            get {
                return this.CodeField;
            }
            set {
                if ((this.CodeField.Equals(value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LogService.ILogService")]
    public interface ILogService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogService/WriteLogMessage", ReplyAction="http://tempuri.org/ILogService/WriteLogMessageResponse")]
        void WriteLogMessage(LogServiceProxy.LogService.LogAddMessage addMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogService/WriteLogMessage", ReplyAction="http://tempuri.org/ILogService/WriteLogMessageResponse")]
        System.Threading.Tasks.Task WriteLogMessageAsync(LogServiceProxy.LogService.LogAddMessage addMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogService/GetLogs", ReplyAction="http://tempuri.org/ILogService/GetLogsResponse")]
        LogServiceProxy.LogService.LogGetMessage[] GetLogs(LogServiceProxy.LogService.LogFilter filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogService/GetLogs", ReplyAction="http://tempuri.org/ILogService/GetLogsResponse")]
        System.Threading.Tasks.Task<LogServiceProxy.LogService.LogGetMessage[]> GetLogsAsync(LogServiceProxy.LogService.LogFilter filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogService/UpdateLogEvents", ReplyAction="http://tempuri.org/ILogService/UpdateLogEventsResponse")]
        LogServiceProxy.LogService.Error UpdateLogEvents(LogServiceProxy.LogService.LogEventsForUpdate[] events);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogService/UpdateLogEvents", ReplyAction="http://tempuri.org/ILogService/UpdateLogEventsResponse")]
        System.Threading.Tasks.Task<LogServiceProxy.LogService.Error> UpdateLogEventsAsync(LogServiceProxy.LogService.LogEventsForUpdate[] events);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogService/GetLogEvents", ReplyAction="http://tempuri.org/ILogService/GetLogEventsResponse")]
        LogServiceProxy.LogService.LogEventsForUpdate[] GetLogEvents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogService/GetLogEvents", ReplyAction="http://tempuri.org/ILogService/GetLogEventsResponse")]
        System.Threading.Tasks.Task<LogServiceProxy.LogService.LogEventsForUpdate[]> GetLogEventsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILogServiceChannel : LogServiceProxy.LogService.ILogService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LogServiceClient : System.ServiceModel.ClientBase<LogServiceProxy.LogService.ILogService>, LogServiceProxy.LogService.ILogService {
        
        public LogServiceClient() {
        }
        
        public LogServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LogServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void WriteLogMessage(LogServiceProxy.LogService.LogAddMessage addMessage) {
            base.Channel.WriteLogMessage(addMessage);
        }
        
        public System.Threading.Tasks.Task WriteLogMessageAsync(LogServiceProxy.LogService.LogAddMessage addMessage) {
            return base.Channel.WriteLogMessageAsync(addMessage);
        }
        
        public LogServiceProxy.LogService.LogGetMessage[] GetLogs(LogServiceProxy.LogService.LogFilter filter) {
            return base.Channel.GetLogs(filter);
        }
        
        public System.Threading.Tasks.Task<LogServiceProxy.LogService.LogGetMessage[]> GetLogsAsync(LogServiceProxy.LogService.LogFilter filter) {
            return base.Channel.GetLogsAsync(filter);
        }
        
        public LogServiceProxy.LogService.Error UpdateLogEvents(LogServiceProxy.LogService.LogEventsForUpdate[] events) {
            return base.Channel.UpdateLogEvents(events);
        }
        
        public System.Threading.Tasks.Task<LogServiceProxy.LogService.Error> UpdateLogEventsAsync(LogServiceProxy.LogService.LogEventsForUpdate[] events) {
            return base.Channel.UpdateLogEventsAsync(events);
        }
        
        public LogServiceProxy.LogService.LogEventsForUpdate[] GetLogEvents() {
            return base.Channel.GetLogEvents();
        }
        
        public System.Threading.Tasks.Task<LogServiceProxy.LogService.LogEventsForUpdate[]> GetLogEventsAsync() {
            return base.Channel.GetLogEventsAsync();
        }
    }
}
