﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace ATX_POS.test2010 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TestWS_Binding", Namespace="urn:microsoft-dynamics-schemas/codeunit/TestWS")]
    public partial class TestWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HolaOperationCompleted;
        
        private System.Threading.SendOrPostCallback Registrar2OperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteBadPostOperationCompleted;
        
        private System.Threading.SendOrPostCallback PostJournalOperationCompleted;
        
        private System.Threading.SendOrPostCallback ClearJournalOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetNoItemOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public TestWS() {
            this.Url = global::ATX_POS.Properties.Settings.Default.ATX_POS_test2010_TestWS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HolaCompletedEventHandler HolaCompleted;
        
        /// <remarks/>
        public event Registrar2CompletedEventHandler Registrar2Completed;
        
        /// <remarks/>
        public event DeleteBadPostCompletedEventHandler DeleteBadPostCompleted;
        
        /// <remarks/>
        public event PostJournalCompletedEventHandler PostJournalCompleted;
        
        /// <remarks/>
        public event ClearJournalCompletedEventHandler ClearJournalCompleted;
        
        /// <remarks/>
        public event GetNoItemCompletedEventHandler GetNoItemCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/TestWS:Hola", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", ResponseElementName="Hola_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string Hola() {
            object[] results = this.Invoke("Hola", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HolaAsync() {
            this.HolaAsync(null);
        }
        
        /// <remarks/>
        public void HolaAsync(object userState) {
            if ((this.HolaOperationCompleted == null)) {
                this.HolaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHolaOperationCompleted);
            }
            this.InvokeAsync("Hola", new object[0], this.HolaOperationCompleted, userState);
        }
        
        private void OnHolaOperationCompleted(object arg) {
            if ((this.HolaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HolaCompleted(this, new HolaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/TestWS:Registrar2", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", ResponseElementName="Registrar2_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public bool Registrar2(string code) {
            object[] results = this.Invoke("Registrar2", new object[] {
                        code});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void Registrar2Async(string code) {
            this.Registrar2Async(code, null);
        }
        
        /// <remarks/>
        public void Registrar2Async(string code, object userState) {
            if ((this.Registrar2OperationCompleted == null)) {
                this.Registrar2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegistrar2OperationCompleted);
            }
            this.InvokeAsync("Registrar2", new object[] {
                        code}, this.Registrar2OperationCompleted, userState);
        }
        
        private void OnRegistrar2OperationCompleted(object arg) {
            if ((this.Registrar2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Registrar2Completed(this, new Registrar2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/TestWS:DeleteBadPost", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", ResponseElementName="DeleteBadPost_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteBadPost(string code) {
            this.Invoke("DeleteBadPost", new object[] {
                        code});
        }
        
        /// <remarks/>
        public void DeleteBadPostAsync(string code) {
            this.DeleteBadPostAsync(code, null);
        }
        
        /// <remarks/>
        public void DeleteBadPostAsync(string code, object userState) {
            if ((this.DeleteBadPostOperationCompleted == null)) {
                this.DeleteBadPostOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteBadPostOperationCompleted);
            }
            this.InvokeAsync("DeleteBadPost", new object[] {
                        code}, this.DeleteBadPostOperationCompleted, userState);
        }
        
        private void OnDeleteBadPostOperationCompleted(object arg) {
            if ((this.DeleteBadPostCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteBadPostCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/TestWS:PostJournal", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", ResponseElementName="PostJournal_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public bool PostJournal(string code) {
            object[] results = this.Invoke("PostJournal", new object[] {
                        code});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void PostJournalAsync(string code) {
            this.PostJournalAsync(code, null);
        }
        
        /// <remarks/>
        public void PostJournalAsync(string code, object userState) {
            if ((this.PostJournalOperationCompleted == null)) {
                this.PostJournalOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPostJournalOperationCompleted);
            }
            this.InvokeAsync("PostJournal", new object[] {
                        code}, this.PostJournalOperationCompleted, userState);
        }
        
        private void OnPostJournalOperationCompleted(object arg) {
            if ((this.PostJournalCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PostJournalCompleted(this, new PostJournalCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/TestWS:ClearJournal", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", ResponseElementName="ClearJournal_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ClearJournal() {
            this.Invoke("ClearJournal", new object[0]);
        }
        
        /// <remarks/>
        public void ClearJournalAsync() {
            this.ClearJournalAsync(null);
        }
        
        /// <remarks/>
        public void ClearJournalAsync(object userState) {
            if ((this.ClearJournalOperationCompleted == null)) {
                this.ClearJournalOperationCompleted = new System.Threading.SendOrPostCallback(this.OnClearJournalOperationCompleted);
            }
            this.InvokeAsync("ClearJournal", new object[0], this.ClearJournalOperationCompleted, userState);
        }
        
        private void OnClearJournalOperationCompleted(object arg) {
            if ((this.ClearJournalCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ClearJournalCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/codeunit/TestWS:GetNoItem", RequestNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", ResponseElementName="GetNoItem_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/codeunit/TestWS", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return_value")]
        public string GetNoItem(string referenceCode) {
            object[] results = this.Invoke("GetNoItem", new object[] {
                        referenceCode});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetNoItemAsync(string referenceCode) {
            this.GetNoItemAsync(referenceCode, null);
        }
        
        /// <remarks/>
        public void GetNoItemAsync(string referenceCode, object userState) {
            if ((this.GetNoItemOperationCompleted == null)) {
                this.GetNoItemOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetNoItemOperationCompleted);
            }
            this.InvokeAsync("GetNoItem", new object[] {
                        referenceCode}, this.GetNoItemOperationCompleted, userState);
        }
        
        private void OnGetNoItemOperationCompleted(object arg) {
            if ((this.GetNoItemCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetNoItemCompleted(this, new GetNoItemCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void HolaCompletedEventHandler(object sender, HolaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HolaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HolaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void Registrar2CompletedEventHandler(object sender, Registrar2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Registrar2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Registrar2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void DeleteBadPostCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void PostJournalCompletedEventHandler(object sender, PostJournalCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PostJournalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PostJournalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void ClearJournalCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetNoItemCompletedEventHandler(object sender, GetNoItemCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetNoItemCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetNoItemCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591