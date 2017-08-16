﻿using System;
using AutoCSer.Metadata;
using AutoCSer.CodeGenerator.Metadata;
using System.Collections.Generic;
using AutoCSer.Extension;
using System.Reflection;

namespace AutoCSer.CodeGenerator.TemplateGenerator
{
    /// <summary>
    /// TCP 静态服务代码生成
    /// </summary>
    internal sealed partial class TcpStaticServer : TcpServer
    {
        /// <summary>
        /// TCP 静态服务代码生成
        /// </summary>
        [Generator(Name = "TCP 静态服务", DependType = typeof(CSharper), IsAuto = true)]
        internal sealed partial class Generator : Generator<AutoCSer.Net.TcpStaticServer.ServerAttribute, AutoCSer.Net.TcpStaticServer.MethodAttribute, AutoCSer.Net.TcpInternalServer.ServerSocketSender>
        {
            /// <summary>
            /// 服务器端位置
            /// </summary>
            private const string serverPart = "TcpStaticServer";
            /// <summary>
            /// 客户端位置
            /// </summary>
            public string ClientPart
            {
                get { return "TcpStaticClient"; }
            }
            /// <summary>
            /// 调用参数位置
            /// </summary>
            public string ParameterPart
            {
                get { return ServiceAttribute.IsSegmentation ? ClientPart : serverPart; }
            }
            /// <summary>
            /// TCP 静态服务
            /// </summary>
            private sealed class Server
            {
                /// <summary>
                /// TCP调用服务配置
                /// </summary>
                public AutoCSer.Net.TcpStaticServer.ServerAttribute Attribute = new AutoCSer.Net.TcpStaticServer.ServerAttribute();
                /// <summary>
                /// 类型集合
                /// </summary>
                public LeftArray<ServerType> Types;
                /// <summary>
                /// 配置类型
                /// </summary>
                public ExtensionType AttributeType;
                /// <summary>
                /// 是否存在方法
                /// </summary>
                public bool IsMethod;
                /// <summary>
                /// 是否默认时间验证服务
                /// </summary>
                public bool IsTimeVerify
                {
                    get { return typeof(AutoCSer.Net.TcpStaticServer.TimeVerify<>).isAssignableFromGenericDefinition(AttributeType); }
                }
            }
            /// <summary>
            /// TCP 静态服务类型信息
            /// </summary>
            private sealed class ServerType
            {
                /// <summary>
                /// TCP调用类型
                /// </summary>
                public ExtensionType Type;
                /// <summary>
                /// TCP调用配置
                /// </summary>
                public AutoCSer.Net.TcpStaticServer.ServerAttribute Attribute;
                /// <summary>
                /// 方法集合
                /// </summary>
                public ListArray<TcpMethod> Methods = new ListArray<TcpMethod>();
            }
            /// <summary>
            /// 是否所有类型
            /// </summary>
            public bool IsAllType;
            /// <summary>
            /// 配置类型
            /// </summary>
            public string TcpServerAttributeType;
            /// <summary>
            /// TCP 静态服务集合
            /// </summary>
            private Dictionary<HashString, Server> servers = DictionaryCreator.CreateHashString<Server>();
            /// <summary>
            /// TCP 静态服务类型集合
            /// </summary>
            private Dictionary<HashString, ServerType> serverTypes = DictionaryCreator.CreateHashString<ServerType>();
            /// <summary>
            /// 服务类名称(临时变量)
            /// </summary>
            private string defaultServerName;
            /// <summary>
            /// TCP调用服务(临时变量)
            /// </summary>
            private Server defaultServer;
            /// <summary>
            /// TCP调用类型(临时变量)
            /// </summary>
            private ServerType defaultType;
            /// <summary>
            /// 时间验证函数
            /// </summary>
            private TcpMethod TimeVerifyMethod;
            /// <summary>
            /// 客户端时间验证类型
            /// </summary>
            public string TimeVerifyClientType
            {
                get
                {
                    return AutoParameter.DefaultNamespace + ".TcpCall." + Type.TypeName;
                }
            }
            /// <summary>
            /// 安装下一个类型
            /// </summary>
            protected override void nextCreate()
            {
                if ((Attribute.IsAbstract || Type.Type.IsSealed || !Type.Type.IsAbstract) && !Type.Type.IsInterface)
                {
                    defaultServerName = Attribute.ServerName;
                    defaultServer = null;
                    defaultType = null;
                    if (defaultServerName != null)
                    {
                        HashString nameKey = defaultServerName;
                        if (!servers.TryGetValue(nameKey, out defaultServer)) servers.Add(nameKey, defaultServer = new Server());
                        defaultServer.Attribute.Name = defaultServerName;
                        defaultServer.Types.Add(defaultType = new ServerType { Type = Type, Attribute = Attribute });
                        if (Attribute.IsServer)
                        {
                            defaultServer.AttributeType = Type;
                            defaultServer.Attribute.CopyFrom(Attribute);
                        }
                    }
                    foreach (MethodIndex method in MethodIndex.GetMethods<AutoCSer.Net.TcpStaticServer.MethodAttribute>(Type, Attribute.MemberFilters, false, Attribute.IsAttribute, Attribute.IsBaseTypeAttribute))
                    {
                        next(new TcpMethod { Method = method, MethodType = Type });
                    }
                    if (!Type.Type.IsGenericType)
                    {
                        foreach (MemberIndexInfo member in StaticMemberIndexGroup.Get<AutoCSer.Net.TcpStaticServer.MethodAttribute>(Type, Attribute.MemberFilters, false, Attribute.IsAttribute, Attribute.IsBaseTypeAttribute))
                        {
                            if (member.IsField)
                            {
                                FieldInfo field = (FieldInfo)member.Member;
                                TcpMethod getMethod = new TcpMethod
                                {
                                    Method = new Metadata.MethodIndex(field, true),
                                    MemberIndex = member,
                                    MethodType = Type
                                };
                                if (!getMethod.Attribute.IsOnlyGetMember)
                                {
                                    getMethod.SetMethod = new TcpMethod { Method = new Metadata.MethodIndex(field, false), MemberIndex = member, MethodType = Type };
                                }
                                next(getMethod);
                                if (getMethod.SetMethod != null) next(getMethod.SetMethod);
                            }
                            else if (member.CanGet)
                            {
                                PropertyInfo property = (PropertyInfo)member.Member;
                                TcpMethod getMethod = new TcpMethod
                                {
                                    Method = new Metadata.MethodIndex(property, true),
                                    MemberIndex = member,
                                    MethodType = Type
                                };
                                if (member.CanSet && !getMethod.Attribute.IsOnlyGetMember)
                                {
                                    getMethod.SetMethod = new TcpMethod { Method = new Metadata.MethodIndex(property, false), MemberIndex = member, MethodType = Type };
                                }
                                next(getMethod);
                                if (getMethod.SetMethod != null) next(getMethod.SetMethod);
                            }
                        }
                    }
                    serverTypes.Clear();
                }
            }
            /// <summary>
            /// 下一个函数处理
            /// </summary>
            /// <param name="methodIndex"></param>
            private void next(TcpMethod methodIndex)
            {
                AutoCSer.Net.TcpStaticServer.MethodAttribute attribute = methodIndex.Attribute;
                Server server = defaultServer;
                ServerType serverType = defaultType;
                string serviceName = attribute.GetServerName;
                if (serviceName == null) serviceName = Attribute.ServerName;
                if (serviceName != defaultServerName)
                {
                    if (serviceName == null) serverType = null;
                    else
                    {
                        HashString nameKey = serviceName;
                        if (!servers.TryGetValue(nameKey, out server))
                        {
                            servers.Add(nameKey, server = new Server());
                            server.Attribute.Name = serviceName;
                        }
                        if (!serverTypes.TryGetValue(nameKey, out serverType))
                        {
                            server.Types.Add(serverType = new ServerType { Type = Type });
                            serverTypes.Add(nameKey, serverType);
                        }
                    }
                }
                if (serverType != null)
                {
                    server.IsMethod = true;
                    methodIndex.ServiceAttribute = server.Attribute;
                    //methodIndex.MethodIndex = server.MethodIndex++;
                    //methodIndex.ParameterIndex = parameterIndex++;
                    serverType.Methods.Add(methodIndex);
                }
            }
            /// <summary>
            /// 获取命令序号记忆数据
            /// </summary>
            /// <returns></returns>
            private Dictionary<HashString, int> getRememberIdentityName()
            {
                string serverTypeName = AutoParameter.DefaultNamespace + "." + serverPart + "." + ServerName;
                Type serverType = assembly.GetType(serverTypeName);
                return serverType == null ? nullRememberIdentityName : getRememberIdentityName(serverType);
            }
            /// <summary>
            /// 安装完成处理
            /// </summary>
            protected unsafe override void onCreated()
            {
                StringArray clientCallCode = new StringArray();
                LeftArray<TcpMethod> methods = new LeftArray<TcpMethod>();
                TcpMethod[] methodIndexs;
                ParameterBuilder parameterBuilder = new ParameterBuilder();
                int staticMethodIndex = 0;
                foreach (Server server in servers.Values)
                {
                    if (server.IsMethod)
                    {
                        IsAllType = false;
                        TcpServerAttributeType = server.AttributeType == null || server.AttributeType.Type == null ? null : server.AttributeType.FullName;
                        ServiceAttribute = server.Attribute;
                        foreach (ServerType serverType in server.Types) methods.Add(serverType.Methods);
                        methodIndexs = methods.ToArray();
                        methods.Length = 0;
                        methodIndexs = TcpMethod.CheckIdentity(methodIndexs, getRememberIdentityName(), method => method.Method.MethodKeyFullName);
                        if (methodIndexs == null) return;
                        int index = 0;
                        IsVerifyMethod = IsCallQueue = false;
                        parameterBuilder.Clear(ServiceAttribute.IsSimpleSerialize);
                        foreach (TcpMethod method in methodIndexs)
                        {
                            method.MethodIndex = index++;
                            method.StaticMethodIndex = ++staticMethodIndex;
                            if (!method.IsNullMethod)
                            {
                                if (IsVerifyMethod) method.Attribute.IsVerifyMethod = false;
                                else if (method.IsVerifyMethod)
                                {
                                    IsVerifyMethod = true;
                                    if (method.MethodType == server.AttributeType && server.IsTimeVerify) TimeVerifyMethod = method;
                                    method.Attribute.ServerTaskType = Net.TcpServer.ServerTaskType.Synchronous;
                                }
                                parameterBuilder.Add(method);

                                IsCallQueue |= method.Attribute.ServerTaskType == Net.TcpServer.ServerTaskType.Queue;
                            }
                        }
                        ParameterTypes = parameterBuilder.Get();
                        foreach (ServerType serverType in server.Types)
                        {
                            if (serverType.Methods.Length != 0)
                            {
                                Type = serverType.Type;
                                //TimeVerifyType = Type == server.AttributeType && server.IsTimeVerify ? Type : ExtensionType.Null;
                                Attribute = serverType.Attribute ?? server.Attribute;
                                MethodIndexs = serverType.Methods.ToArray();
                                CSharpTypeDefinition definition = new CSharpTypeDefinition(Type, true, false);
                                _code_.Length = 0;
                                create(false);
                                Coder.Add(definition.Start + _partCodes_["SERVERCALL"] + definition.End);
                                if (ServiceAttribute.IsSegmentation)
                                {
                                    clientCallCode.Add(definition.Start + _partCodes_["CLIENTCALL"] + definition.End);
                                }
                                else Coder.Add(definition.Start + _partCodes_["CLIENTCALL"] + definition.End);
                            }
                        }
                        Type = server.AttributeType;
                        Attribute = server.Attribute;
                        IsAllType = true;
                        MethodIndexs = methodIndexs;
                        methods.Length = 0;
                        _code_.Length = 0;
                        create(false);
                        Coder.Add(@"
namespace " + AutoParameter.DefaultNamespace + "." + serverPart + @"
{
" + _partCodes_["SERVER"] + @"
}");
                        string clientCode = @"
namespace " + AutoParameter.DefaultNamespace + "." + ClientPart + @"
{
" + _partCodes_["CLIENT"] + @"
}";
                        if (ServiceAttribute.IsSegmentation)
                        {
                            clientCallCode.Add(clientCode);
                            string fileName = AutoParameter.ProjectPath + "{" + AutoParameter.DefaultNamespace + "}.TcpStaticServer." + ServiceAttribute.ServerName + ".Client.cs";
                            clientCode = Coder.WarningCode + clientCallCode.ToString() + Coder.FileEndCode;
                            if (Coder.WriteFile(fileName, clientCode))
                            {
                                if (ServiceAttribute.ClientSegmentationCopyPath != null)
                                {
                                    string copyFileName = ServiceAttribute.ClientSegmentationCopyPath + "{" + AutoParameter.DefaultNamespace + "}.TcpStaticServer." + ServiceAttribute.ServerName + ".Client.cs";
                                    if (Coder.WriteFile(copyFileName, clientCode)) Messages.Message(copyFileName + " 被修改");
                                }
                                Messages.Message(fileName + " 被修改");
                            }
                            clientCallCode.Length = 0;
                        }
                        else Coder.Add(clientCode);
                    }
                }
            }
        }
    }
}
