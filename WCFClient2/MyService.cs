﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="WCFServices", ConfigurationName="IMyService")]
public interface IMyService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="WCFServices/IMyService/RetSomeValue", ReplyAction="WCFServices/IMyService/RetSomeValueResponse")]
    int RetSomeValue();
    
    [System.ServiceModel.OperationContractAttribute(Action="WCFServices/IMyService/RetSomeValue", ReplyAction="WCFServices/IMyService/RetSomeValueResponse")]
    System.Threading.Tasks.Task<int> RetSomeValueAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="WCFServices/IMyService/sum", ReplyAction="WCFServices/IMyService/sumResponse")]
    int sum(int a, int b);
    
    [System.ServiceModel.OperationContractAttribute(Action="WCFServices/IMyService/sum", ReplyAction="WCFServices/IMyService/sumResponse")]
    System.Threading.Tasks.Task<int> sumAsync(int a, int b);
    
    [System.ServiceModel.OperationContractAttribute(Action="WCFServices/IMyService/minus", ReplyAction="WCFServices/IMyService/minusResponse")]
    int minus(int a, int b);
    
    [System.ServiceModel.OperationContractAttribute(Action="WCFServices/IMyService/minus", ReplyAction="WCFServices/IMyService/minusResponse")]
    System.Threading.Tasks.Task<int> minusAsync(int a, int b);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IMyServiceChannel : IMyService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class MyServiceClient : System.ServiceModel.ClientBase<IMyService>, IMyService
{
    
    public MyServiceClient()
    {
    }
    
    public MyServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public MyServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public MyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public MyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int RetSomeValue()
    {
        return base.Channel.RetSomeValue();
    }
    
    public System.Threading.Tasks.Task<int> RetSomeValueAsync()
    {
        return base.Channel.RetSomeValueAsync();
    }
    
    public int sum(int a, int b)
    {
        return base.Channel.sum(a, b);
    }
    
    public System.Threading.Tasks.Task<int> sumAsync(int a, int b)
    {
        return base.Channel.sumAsync(a, b);
    }
    
    public int minus(int a, int b)
    {
        return base.Channel.minus(a, b);
    }
    
    public System.Threading.Tasks.Task<int> minusAsync(int a, int b)
    {
        return base.Channel.minusAsync(a, b);
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="WCFServices", ConfigurationName="IMyService2")]
public interface IMyService2
{
    
    [System.ServiceModel.OperationContractAttribute(Action="WCFServices/IMyService2/pro", ReplyAction="WCFServices/IMyService2/proResponse")]
    int pro(int a, int b);
    
    [System.ServiceModel.OperationContractAttribute(Action="WCFServices/IMyService2/pro", ReplyAction="WCFServices/IMyService2/proResponse")]
    System.Threading.Tasks.Task<int> proAsync(int a, int b);
    
    [System.ServiceModel.OperationContractAttribute(Action="WCFServices/IMyService2/del", ReplyAction="WCFServices/IMyService2/delResponse")]
    int del(int a, int b);
    
    [System.ServiceModel.OperationContractAttribute(Action="WCFServices/IMyService2/del", ReplyAction="WCFServices/IMyService2/delResponse")]
    System.Threading.Tasks.Task<int> delAsync(int a, int b);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IMyService2Channel : IMyService2, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class MyService2Client : System.ServiceModel.ClientBase<IMyService2>, IMyService2
{
    
    public MyService2Client()
    {
    }
    
    public MyService2Client(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public MyService2Client(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public MyService2Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public MyService2Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int pro(int a, int b)
    {
        return base.Channel.pro(a, b);
    }
    
    public System.Threading.Tasks.Task<int> proAsync(int a, int b)
    {
        return base.Channel.proAsync(a, b);
    }
    
    public int del(int a, int b)
    {
        return base.Channel.del(a, b);
    }
    
    public System.Threading.Tasks.Task<int> delAsync(int a, int b)
    {
        return base.Channel.delAsync(a, b);
    }
}
