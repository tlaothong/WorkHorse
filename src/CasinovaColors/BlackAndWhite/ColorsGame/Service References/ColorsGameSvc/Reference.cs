﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.50826.0
// 
namespace ColorsGame.ColorsGameSvc {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GamePlayInformation", Namespace="http://tempuri.org/")]
    public partial class GamePlayInformation : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string UserNameField;
        
        private int TableIDField;
        
        private int RoundIDField;
        
        private System.Guid TrackingIDField;
        
        private System.Guid OnGoingTrackingIDField;
        
        private double TotalBetAmounfOfBlackField;
        
        private double TotalBetAmountOfWhiteField;
        
        private string WinnerField;
        
        private System.DateTime LastUpdateField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int TableID {
            get {
                return this.TableIDField;
            }
            set {
                if ((this.TableIDField.Equals(value) != true)) {
                    this.TableIDField = value;
                    this.RaisePropertyChanged("TableID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public int RoundID {
            get {
                return this.RoundIDField;
            }
            set {
                if ((this.RoundIDField.Equals(value) != true)) {
                    this.RoundIDField = value;
                    this.RaisePropertyChanged("RoundID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public System.Guid TrackingID {
            get {
                return this.TrackingIDField;
            }
            set {
                if ((this.TrackingIDField.Equals(value) != true)) {
                    this.TrackingIDField = value;
                    this.RaisePropertyChanged("TrackingID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.Guid OnGoingTrackingID {
            get {
                return this.OnGoingTrackingIDField;
            }
            set {
                if ((this.OnGoingTrackingIDField.Equals(value) != true)) {
                    this.OnGoingTrackingIDField = value;
                    this.RaisePropertyChanged("OnGoingTrackingID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public double TotalBetAmounfOfBlack {
            get {
                return this.TotalBetAmounfOfBlackField;
            }
            set {
                if ((this.TotalBetAmounfOfBlackField.Equals(value) != true)) {
                    this.TotalBetAmounfOfBlackField = value;
                    this.RaisePropertyChanged("TotalBetAmounfOfBlack");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public double TotalBetAmountOfWhite {
            get {
                return this.TotalBetAmountOfWhiteField;
            }
            set {
                if ((this.TotalBetAmountOfWhiteField.Equals(value) != true)) {
                    this.TotalBetAmountOfWhiteField = value;
                    this.RaisePropertyChanged("TotalBetAmountOfWhite");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Winner {
            get {
                return this.WinnerField;
            }
            set {
                if ((object.ReferenceEquals(this.WinnerField, value) != true)) {
                    this.WinnerField = value;
                    this.RaisePropertyChanged("Winner");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public System.DateTime LastUpdate {
            get {
                return this.LastUpdateField;
            }
            set {
                if ((this.LastUpdateField.Equals(value) != true)) {
                    this.LastUpdateField = value;
                    this.RaisePropertyChanged("LastUpdate");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ColorsGameSvc.ColorsGameServiceSoap")]
    public interface ColorsGameServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/PayForWinnerInformation", ReplyAction="*")]
        System.IAsyncResult BeginPayForWinnerInformation(ColorsGame.ColorsGameSvc.PayForWinnerInformationRequest request, System.AsyncCallback callback, object asyncState);
        
        ColorsGame.ColorsGameSvc.PayForWinnerInformationResponse EndPayForWinnerInformation(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/GetMyGamePlayInfo", ReplyAction="*")]
        System.IAsyncResult BeginGetMyGamePlayInfo(ColorsGame.ColorsGameSvc.GetMyGamePlayInfoRequest request, System.AsyncCallback callback, object asyncState);
        
        ColorsGame.ColorsGameSvc.GetMyGamePlayInfoResponse EndGetMyGamePlayInfo(System.IAsyncResult result);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PayForWinnerInformationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PayForWinnerInformation", Namespace="http://tempuri.org/", Order=0)]
        public ColorsGame.ColorsGameSvc.PayForWinnerInformationRequestBody Body;
        
        public PayForWinnerInformationRequest() {
        }
        
        public PayForWinnerInformationRequest(ColorsGame.ColorsGameSvc.PayForWinnerInformationRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PayForWinnerInformationRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int tableId;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int roundId;
        
        public PayForWinnerInformationRequestBody() {
        }
        
        public PayForWinnerInformationRequestBody(int tableId, int roundId) {
            this.tableId = tableId;
            this.roundId = roundId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PayForWinnerInformationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PayForWinnerInformationResponse", Namespace="http://tempuri.org/", Order=0)]
        public ColorsGame.ColorsGameSvc.PayForWinnerInformationResponseBody Body;
        
        public PayForWinnerInformationResponse() {
        }
        
        public PayForWinnerInformationResponse(ColorsGame.ColorsGameSvc.PayForWinnerInformationResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PayForWinnerInformationResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string PayForWinnerInformationResult;
        
        public PayForWinnerInformationResponseBody() {
        }
        
        public PayForWinnerInformationResponseBody(string PayForWinnerInformationResult) {
            this.PayForWinnerInformationResult = PayForWinnerInformationResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetMyGamePlayInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetMyGamePlayInfo", Namespace="http://tempuri.org/", Order=0)]
        public ColorsGame.ColorsGameSvc.GetMyGamePlayInfoRequestBody Body;
        
        public GetMyGamePlayInfoRequest() {
        }
        
        public GetMyGamePlayInfoRequest(ColorsGame.ColorsGameSvc.GetMyGamePlayInfoRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetMyGamePlayInfoRequestBody {
        
        public GetMyGamePlayInfoRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetMyGamePlayInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetMyGamePlayInfoResponse", Namespace="http://tempuri.org/", Order=0)]
        public ColorsGame.ColorsGameSvc.GetMyGamePlayInfoResponseBody Body;
        
        public GetMyGamePlayInfoResponse() {
        }
        
        public GetMyGamePlayInfoResponse(ColorsGame.ColorsGameSvc.GetMyGamePlayInfoResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetMyGamePlayInfoResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.ObjectModel.ObservableCollection<ColorsGame.ColorsGameSvc.GamePlayInformation> GetMyGamePlayInfoResult;
        
        public GetMyGamePlayInfoResponseBody() {
        }
        
        public GetMyGamePlayInfoResponseBody(System.Collections.ObjectModel.ObservableCollection<ColorsGame.ColorsGameSvc.GamePlayInformation> GetMyGamePlayInfoResult) {
            this.GetMyGamePlayInfoResult = GetMyGamePlayInfoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ColorsGameServiceSoapChannel : ColorsGame.ColorsGameSvc.ColorsGameServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PayForWinnerInformationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public PayForWinnerInformationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetMyGamePlayInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetMyGamePlayInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<ColorsGame.ColorsGameSvc.GamePlayInformation> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<ColorsGame.ColorsGameSvc.GamePlayInformation>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ColorsGameServiceSoapClient : System.ServiceModel.ClientBase<ColorsGame.ColorsGameSvc.ColorsGameServiceSoap>, ColorsGame.ColorsGameSvc.ColorsGameServiceSoap {
        
        private BeginOperationDelegate onBeginPayForWinnerInformationDelegate;
        
        private EndOperationDelegate onEndPayForWinnerInformationDelegate;
        
        private System.Threading.SendOrPostCallback onPayForWinnerInformationCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetMyGamePlayInfoDelegate;
        
        private EndOperationDelegate onEndGetMyGamePlayInfoDelegate;
        
        private System.Threading.SendOrPostCallback onGetMyGamePlayInfoCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public ColorsGameServiceSoapClient() {
        }
        
        public ColorsGameServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ColorsGameServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ColorsGameServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ColorsGameServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<PayForWinnerInformationCompletedEventArgs> PayForWinnerInformationCompleted;
        
        public event System.EventHandler<GetMyGamePlayInfoCompletedEventArgs> GetMyGamePlayInfoCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult ColorsGame.ColorsGameSvc.ColorsGameServiceSoap.BeginPayForWinnerInformation(ColorsGame.ColorsGameSvc.PayForWinnerInformationRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginPayForWinnerInformation(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginPayForWinnerInformation(int tableId, int roundId, System.AsyncCallback callback, object asyncState) {
            ColorsGame.ColorsGameSvc.PayForWinnerInformationRequest inValue = new ColorsGame.ColorsGameSvc.PayForWinnerInformationRequest();
            inValue.Body = new ColorsGame.ColorsGameSvc.PayForWinnerInformationRequestBody();
            inValue.Body.tableId = tableId;
            inValue.Body.roundId = roundId;
            return ((ColorsGame.ColorsGameSvc.ColorsGameServiceSoap)(this)).BeginPayForWinnerInformation(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ColorsGame.ColorsGameSvc.PayForWinnerInformationResponse ColorsGame.ColorsGameSvc.ColorsGameServiceSoap.EndPayForWinnerInformation(System.IAsyncResult result) {
            return base.Channel.EndPayForWinnerInformation(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private string EndPayForWinnerInformation(System.IAsyncResult result) {
            ColorsGame.ColorsGameSvc.PayForWinnerInformationResponse retVal = ((ColorsGame.ColorsGameSvc.ColorsGameServiceSoap)(this)).EndPayForWinnerInformation(result);
            return retVal.Body.PayForWinnerInformationResult;
        }
        
        private System.IAsyncResult OnBeginPayForWinnerInformation(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int tableId = ((int)(inValues[0]));
            int roundId = ((int)(inValues[1]));
            return this.BeginPayForWinnerInformation(tableId, roundId, callback, asyncState);
        }
        
        private object[] OnEndPayForWinnerInformation(System.IAsyncResult result) {
            string retVal = this.EndPayForWinnerInformation(result);
            return new object[] {
                    retVal};
        }
        
        private void OnPayForWinnerInformationCompleted(object state) {
            if ((this.PayForWinnerInformationCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PayForWinnerInformationCompleted(this, new PayForWinnerInformationCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void PayForWinnerInformationAsync(int tableId, int roundId) {
            this.PayForWinnerInformationAsync(tableId, roundId, null);
        }
        
        public void PayForWinnerInformationAsync(int tableId, int roundId, object userState) {
            if ((this.onBeginPayForWinnerInformationDelegate == null)) {
                this.onBeginPayForWinnerInformationDelegate = new BeginOperationDelegate(this.OnBeginPayForWinnerInformation);
            }
            if ((this.onEndPayForWinnerInformationDelegate == null)) {
                this.onEndPayForWinnerInformationDelegate = new EndOperationDelegate(this.OnEndPayForWinnerInformation);
            }
            if ((this.onPayForWinnerInformationCompletedDelegate == null)) {
                this.onPayForWinnerInformationCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPayForWinnerInformationCompleted);
            }
            base.InvokeAsync(this.onBeginPayForWinnerInformationDelegate, new object[] {
                        tableId,
                        roundId}, this.onEndPayForWinnerInformationDelegate, this.onPayForWinnerInformationCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult ColorsGame.ColorsGameSvc.ColorsGameServiceSoap.BeginGetMyGamePlayInfo(ColorsGame.ColorsGameSvc.GetMyGamePlayInfoRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetMyGamePlayInfo(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginGetMyGamePlayInfo(System.AsyncCallback callback, object asyncState) {
            ColorsGame.ColorsGameSvc.GetMyGamePlayInfoRequest inValue = new ColorsGame.ColorsGameSvc.GetMyGamePlayInfoRequest();
            inValue.Body = new ColorsGame.ColorsGameSvc.GetMyGamePlayInfoRequestBody();
            return ((ColorsGame.ColorsGameSvc.ColorsGameServiceSoap)(this)).BeginGetMyGamePlayInfo(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ColorsGame.ColorsGameSvc.GetMyGamePlayInfoResponse ColorsGame.ColorsGameSvc.ColorsGameServiceSoap.EndGetMyGamePlayInfo(System.IAsyncResult result) {
            return base.Channel.EndGetMyGamePlayInfo(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.Collections.ObjectModel.ObservableCollection<ColorsGame.ColorsGameSvc.GamePlayInformation> EndGetMyGamePlayInfo(System.IAsyncResult result) {
            ColorsGame.ColorsGameSvc.GetMyGamePlayInfoResponse retVal = ((ColorsGame.ColorsGameSvc.ColorsGameServiceSoap)(this)).EndGetMyGamePlayInfo(result);
            return retVal.Body.GetMyGamePlayInfoResult;
        }
        
        private System.IAsyncResult OnBeginGetMyGamePlayInfo(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetMyGamePlayInfo(callback, asyncState);
        }
        
        private object[] OnEndGetMyGamePlayInfo(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<ColorsGame.ColorsGameSvc.GamePlayInformation> retVal = this.EndGetMyGamePlayInfo(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetMyGamePlayInfoCompleted(object state) {
            if ((this.GetMyGamePlayInfoCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetMyGamePlayInfoCompleted(this, new GetMyGamePlayInfoCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetMyGamePlayInfoAsync() {
            this.GetMyGamePlayInfoAsync(null);
        }
        
        public void GetMyGamePlayInfoAsync(object userState) {
            if ((this.onBeginGetMyGamePlayInfoDelegate == null)) {
                this.onBeginGetMyGamePlayInfoDelegate = new BeginOperationDelegate(this.OnBeginGetMyGamePlayInfo);
            }
            if ((this.onEndGetMyGamePlayInfoDelegate == null)) {
                this.onEndGetMyGamePlayInfoDelegate = new EndOperationDelegate(this.OnEndGetMyGamePlayInfo);
            }
            if ((this.onGetMyGamePlayInfoCompletedDelegate == null)) {
                this.onGetMyGamePlayInfoCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetMyGamePlayInfoCompleted);
            }
            base.InvokeAsync(this.onBeginGetMyGamePlayInfoDelegate, null, this.onEndGetMyGamePlayInfoDelegate, this.onGetMyGamePlayInfoCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override ColorsGame.ColorsGameSvc.ColorsGameServiceSoap CreateChannel() {
            return new ColorsGameServiceSoapClientChannel(this);
        }
        
        private class ColorsGameServiceSoapClientChannel : ChannelBase<ColorsGame.ColorsGameSvc.ColorsGameServiceSoap>, ColorsGame.ColorsGameSvc.ColorsGameServiceSoap {
            
            public ColorsGameServiceSoapClientChannel(System.ServiceModel.ClientBase<ColorsGame.ColorsGameSvc.ColorsGameServiceSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginPayForWinnerInformation(ColorsGame.ColorsGameSvc.PayForWinnerInformationRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("PayForWinnerInformation", _args, callback, asyncState);
                return _result;
            }
            
            public ColorsGame.ColorsGameSvc.PayForWinnerInformationResponse EndPayForWinnerInformation(System.IAsyncResult result) {
                object[] _args = new object[0];
                ColorsGame.ColorsGameSvc.PayForWinnerInformationResponse _result = ((ColorsGame.ColorsGameSvc.PayForWinnerInformationResponse)(base.EndInvoke("PayForWinnerInformation", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetMyGamePlayInfo(ColorsGame.ColorsGameSvc.GetMyGamePlayInfoRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("GetMyGamePlayInfo", _args, callback, asyncState);
                return _result;
            }
            
            public ColorsGame.ColorsGameSvc.GetMyGamePlayInfoResponse EndGetMyGamePlayInfo(System.IAsyncResult result) {
                object[] _args = new object[0];
                ColorsGame.ColorsGameSvc.GetMyGamePlayInfoResponse _result = ((ColorsGame.ColorsGameSvc.GetMyGamePlayInfoResponse)(base.EndInvoke("GetMyGamePlayInfo", _args, result)));
                return _result;
            }
        }
    }
}