﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShop.PayService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PayService.PayServiceSoap")]
    public interface PayServiceSoap {
        
        // CODEGEN: Контракт генерации сообщений с именем cardNumber из пространства имен http://tempuri.org/ не отмечен как обнуляемый
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PayOnline", ReplyAction="*")]
        OnlineShop.PayService.PayOnlineResponse PayOnline(OnlineShop.PayService.PayOnlineRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PayOnline", ReplyAction="*")]
        System.Threading.Tasks.Task<OnlineShop.PayService.PayOnlineResponse> PayOnlineAsync(OnlineShop.PayService.PayOnlineRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PayOnlineRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PayOnline", Namespace="http://tempuri.org/", Order=0)]
        public OnlineShop.PayService.PayOnlineRequestBody Body;
        
        public PayOnlineRequest() {
        }
        
        public PayOnlineRequest(OnlineShop.PayService.PayOnlineRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PayOnlineRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cardNumber;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int expYear;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int expMonth;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string cardHolderName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string cvcCode;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public decimal purchaseSum;
        
        public PayOnlineRequestBody() {
        }
        
        public PayOnlineRequestBody(string cardNumber, int expYear, int expMonth, string cardHolderName, string cvcCode, decimal purchaseSum) {
            this.cardNumber = cardNumber;
            this.expYear = expYear;
            this.expMonth = expMonth;
            this.cardHolderName = cardHolderName;
            this.cvcCode = cvcCode;
            this.purchaseSum = purchaseSum;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PayOnlineResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PayOnlineResponse", Namespace="http://tempuri.org/", Order=0)]
        public OnlineShop.PayService.PayOnlineResponseBody Body;
        
        public PayOnlineResponse() {
        }
        
        public PayOnlineResponse(OnlineShop.PayService.PayOnlineResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PayOnlineResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool PayOnlineResult;
        
        public PayOnlineResponseBody() {
        }
        
        public PayOnlineResponseBody(bool PayOnlineResult) {
            this.PayOnlineResult = PayOnlineResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PayServiceSoapChannel : OnlineShop.PayService.PayServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PayServiceSoapClient : System.ServiceModel.ClientBase<OnlineShop.PayService.PayServiceSoap>, OnlineShop.PayService.PayServiceSoap {
        
        public PayServiceSoapClient() {
        }
        
        public PayServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PayServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PayServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PayServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OnlineShop.PayService.PayOnlineResponse OnlineShop.PayService.PayServiceSoap.PayOnline(OnlineShop.PayService.PayOnlineRequest request) {
            return base.Channel.PayOnline(request);
        }
        
        public bool PayOnline(string cardNumber, int expYear, int expMonth, string cardHolderName, string cvcCode, decimal purchaseSum) {
            OnlineShop.PayService.PayOnlineRequest inValue = new OnlineShop.PayService.PayOnlineRequest();
            inValue.Body = new OnlineShop.PayService.PayOnlineRequestBody();
            inValue.Body.cardNumber = cardNumber;
            inValue.Body.expYear = expYear;
            inValue.Body.expMonth = expMonth;
            inValue.Body.cardHolderName = cardHolderName;
            inValue.Body.cvcCode = cvcCode;
            inValue.Body.purchaseSum = purchaseSum;
            OnlineShop.PayService.PayOnlineResponse retVal = ((OnlineShop.PayService.PayServiceSoap)(this)).PayOnline(inValue);
            return retVal.Body.PayOnlineResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OnlineShop.PayService.PayOnlineResponse> OnlineShop.PayService.PayServiceSoap.PayOnlineAsync(OnlineShop.PayService.PayOnlineRequest request) {
            return base.Channel.PayOnlineAsync(request);
        }
        
        public System.Threading.Tasks.Task<OnlineShop.PayService.PayOnlineResponse> PayOnlineAsync(string cardNumber, int expYear, int expMonth, string cardHolderName, string cvcCode, decimal purchaseSum) {
            OnlineShop.PayService.PayOnlineRequest inValue = new OnlineShop.PayService.PayOnlineRequest();
            inValue.Body = new OnlineShop.PayService.PayOnlineRequestBody();
            inValue.Body.cardNumber = cardNumber;
            inValue.Body.expYear = expYear;
            inValue.Body.expMonth = expMonth;
            inValue.Body.cardHolderName = cardHolderName;
            inValue.Body.cvcCode = cvcCode;
            inValue.Body.purchaseSum = purchaseSum;
            return ((OnlineShop.PayService.PayServiceSoap)(this)).PayOnlineAsync(inValue);
        }
    }
}
