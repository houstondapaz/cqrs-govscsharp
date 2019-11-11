// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/greet.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CQRSService.Protos {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class Greeter
  {
    static readonly string __ServiceName = "Greet.Greeter";

    static readonly grpc::Marshaller<global::CQRSService.Protos.HelloRequest> __Marshaller_Greet_HelloRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CQRSService.Protos.HelloRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CQRSService.Protos.HelloReply> __Marshaller_Greet_HelloReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CQRSService.Protos.HelloReply.Parser.ParseFrom);

    static readonly grpc::Method<global::CQRSService.Protos.HelloRequest, global::CQRSService.Protos.HelloReply> __Method_SayHello = new grpc::Method<global::CQRSService.Protos.HelloRequest, global::CQRSService.Protos.HelloReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SayHello",
        __Marshaller_Greet_HelloRequest,
        __Marshaller_Greet_HelloReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CQRSService.Protos.GreetReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Greeter</summary>
    [grpc::BindServiceMethod(typeof(Greeter), "BindService")]
    public abstract partial class GreeterBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::CQRSService.Protos.HelloReply> SayHello(global::CQRSService.Protos.HelloRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GreeterBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SayHello, serviceImpl.SayHello).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GreeterBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SayHello, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CQRSService.Protos.HelloRequest, global::CQRSService.Protos.HelloReply>(serviceImpl.SayHello));
    }

  }
}
#endregion
