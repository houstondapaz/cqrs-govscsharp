// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/client.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CQRSService.Protos {
  public static partial class UserService
  {
    static readonly string __ServiceName = "Users.UserService";

    static readonly grpc::Marshaller<global::CQRSService.Protos.GetUserRequest> __Marshaller_Users_GetUserRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CQRSService.Protos.GetUserRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CQRSService.Protos.User> __Marshaller_Users_User = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CQRSService.Protos.User.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CQRSService.Protos.GetUsersRequest> __Marshaller_Users_GetUsersRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CQRSService.Protos.GetUsersRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CQRSService.Protos.AddUserRequest> __Marshaller_Users_AddUserRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CQRSService.Protos.AddUserRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);

    static readonly grpc::Method<global::CQRSService.Protos.GetUserRequest, global::CQRSService.Protos.User> __Method_GetUser = new grpc::Method<global::CQRSService.Protos.GetUserRequest, global::CQRSService.Protos.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetUser",
        __Marshaller_Users_GetUserRequest,
        __Marshaller_Users_User);

    static readonly grpc::Method<global::CQRSService.Protos.GetUsersRequest, global::CQRSService.Protos.User> __Method_GetUsers = new grpc::Method<global::CQRSService.Protos.GetUsersRequest, global::CQRSService.Protos.User>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetUsers",
        __Marshaller_Users_GetUsersRequest,
        __Marshaller_Users_User);

    static readonly grpc::Method<global::CQRSService.Protos.AddUserRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Add = new grpc::Method<global::CQRSService.Protos.AddUserRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Add",
        __Marshaller_Users_AddUserRequest,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CQRSService.Protos.ClientReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of UserService</summary>
    [grpc::BindServiceMethod(typeof(UserService), "BindService")]
    public abstract partial class UserServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::CQRSService.Protos.User> GetUser(global::CQRSService.Protos.GetUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task GetUsers(global::CQRSService.Protos.GetUsersRequest request, grpc::IServerStreamWriter<global::CQRSService.Protos.User> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> Add(global::CQRSService.Protos.AddUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(UserServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetUser, serviceImpl.GetUser)
          .AddMethod(__Method_GetUsers, serviceImpl.GetUsers)
          .AddMethod(__Method_Add, serviceImpl.Add).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UserServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CQRSService.Protos.GetUserRequest, global::CQRSService.Protos.User>(serviceImpl.GetUser));
      serviceBinder.AddMethod(__Method_GetUsers, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::CQRSService.Protos.GetUsersRequest, global::CQRSService.Protos.User>(serviceImpl.GetUsers));
      serviceBinder.AddMethod(__Method_Add, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CQRSService.Protos.AddUserRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.Add));
    }

  }
}
#endregion
