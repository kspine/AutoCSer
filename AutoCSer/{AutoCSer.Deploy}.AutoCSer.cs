//本文件由程序自动生成,请不要自行修改
using System;
using AutoCSer;

#if NoAutoCSer
#else
#pragma warning disable
namespace AutoCSer.Deploy
{
        public partial class Server
#if NOJIT
#else
             : AutoCSer.Net.TcpServer.ISetTcpServer<AutoCSer.Net.TcpInternalServer.Server, AutoCSer.Net.TcpInternalServer.ServerAttribute>
#endif
        {
            /// <summary>
            /// 命令序号记忆数据
            /// </summary>
            private static KeyValue<string, int>[] _identityCommandNames_()
            {
                KeyValue<string, int>[] names = new KeyValue<string, int>[13];
                names[0].Set(@"()register", 0);
                names[1].Set(@"(AutoCSer.Net.TcpInternalServer.ServerSocketSender,ulong,byte[],ref long)verify", 1);
                names[2].Set(@"(AutoCSer.Net.IndexIdentity,System.Func<AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Deploy.Log>,bool>)getLog", 2);
                names[3].Set(@"()clear", 3);
                names[4].Set(@"(AutoCSer.Net.IndexIdentity)create", 4);
                names[5].Set(@"(AutoCSer.Net.IndexIdentity)clear", 5);
                names[6].Set(@"(AutoCSer.Net.IndexIdentity,System.DateTime)start", 6);
                names[7].Set(@"(AutoCSer.Net.IndexIdentity,byte[][])setFileSource", 7);
                names[8].Set(@"(AutoCSer.Deploy.Directory,string)getFileDifferent", 8);
                names[9].Set(@"(AutoCSer.Net.IndexIdentity,AutoCSer.Deploy.Directory,string,AutoCSer.Deploy.TaskType)addFiles", 9);
                names[10].Set(@"(AutoCSer.Net.IndexIdentity,AutoCSer.KeyValue<string,int>[],string)addAssemblyFiles", 10);
                names[11].Set(@"(AutoCSer.Net.IndexIdentity,AutoCSer.KeyValue<string,int>[],string,int)addRun", 11);
                names[12].Set(@"(AutoCSer.Net.IndexIdentity,int)addWaitRunSwitch", 12);
                return names;
            }
            /// <summary>
            /// Deploy TCP服务
            /// </summary>
            public sealed class TcpInternalServer : AutoCSer.Net.TcpInternalServer.Server
            {
                public readonly AutoCSer.Deploy.Server Value;
                /// <summary>
                /// Deploy TCP调用服务端
                /// </summary>
                /// <param name="attribute">TCP 调用服务器端配置信息</param>
                /// <param name="verify">套接字验证委托</param>
                /// <param name="value">TCP 服务目标对象</param>
                /// <param name="log">日志接口</param>
                /// <param name="onCustomData">自定义数据包处理</param>
                public TcpInternalServer(AutoCSer.Net.TcpInternalServer.ServerAttribute attribute = null, Func<System.Net.Sockets.Socket, bool> verify = null, AutoCSer.Deploy.Server value = null, Action<SubArray<byte>> onCustomData = null, AutoCSer.Log.ILog log = null)
                    : base(attribute ?? (attribute = AutoCSer.Net.TcpInternalServer.ServerAttribute.GetConfig("Deploy", typeof(AutoCSer.Deploy.Server))), verify, onCustomData, log, false)
                {
                    Value = value ?? new AutoCSer.Deploy.Server();
                    setCommandData(13);
                    setCommand(0);
                    setVerifyCommand(1);
                    setCommand(2);
                    setCommand(3);
                    setCommand(4);
                    setCommand(5);
                    setCommand(6);
                    setCommand(7);
                    setCommand(8);
                    setCommand(9);
                    setCommand(10);
                    setCommand(11);
                    setCommand(12);
                    Value.SetTcpServer(this);
                    if (attribute.IsAutoServer) Start();
                }
                /// <summary>
                /// 命令处理
                /// </summary>
                /// <param name="index">命令序号</param>
                /// <param name="sender">TCP 内部服务套接字数据发送</param>
                /// <param name="data">命令数据</param>
                public override void DoCommand(int index, AutoCSer.Net.TcpInternalServer.ServerSocketSender sender, ref SubArray<byte> data)
                {
                    AutoCSer.Net.TcpServer.ReturnType returnType;
                    switch (index - 128)
                    {
                        case 0:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                {
                                    _p1 _outputParameter_ = new _p1();
                                    
                                    AutoCSer.Net.IndexIdentity Return;
                                    
                                    Return = Value.register();
                                    _outputParameter_.Return = Return;
                                    sender.Push(_c0, ref _outputParameter_);
                                    return;
                                }
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 1:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p2 inputParameter = new _p2();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    _p3 _outputParameter_ = new _p3();
                                    
                                    bool Return;
                                    
                                    Return = Value.verify(sender, inputParameter.p2, inputParameter.p0, ref inputParameter.p1);
                                    if (Return) sender.SetVerifyMethod();
                                    
                                    _outputParameter_.p0 = inputParameter.p1;
                                    _outputParameter_.Return = Return;
                                    sender.Push(_c1, ref _outputParameter_);
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 2:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p4 inputParameter = new _p4();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    _p5 outputParameter = new _p5();
                                    
                                    Value.getLog(inputParameter.p0, sender.GetCallback<_p5, AutoCSer.Deploy.Log>(_c2, ref outputParameter));
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 3:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                {
                                    
                                    Value.clear();
                                    sender.Push();
                                    return;
                                }
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 4:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p4 inputParameter = new _p4();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    _p1 _outputParameter_ = new _p1();
                                    
                                    AutoCSer.Net.IndexIdentity Return;
                                    
                                    Return = Value.create(inputParameter.p0);
                                    _outputParameter_.Return = Return;
                                    sender.Push(_c4, ref _outputParameter_);
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 5:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p4 inputParameter = new _p4();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    
                                    Value.clear(inputParameter.p0);
                                    sender.Push();
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 6:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p6 inputParameter = new _p6();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    _p7 _outputParameter_ = new _p7();
                                    
                                    bool Return;
                                    
                                    Return = Value.start(inputParameter.p0, inputParameter.p1);
                                    _outputParameter_.Return = Return;
                                    sender.Push(_c6, ref _outputParameter_);
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 7:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p8 inputParameter = new _p8();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    _p7 _outputParameter_ = new _p7();
                                    
                                    bool Return;
                                    
                                    Return = Value.setFileSource(inputParameter.p0, inputParameter.p1);
                                    _outputParameter_.Return = Return;
                                    sender.Push(_c7, ref _outputParameter_);
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 8:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p9 inputParameter = new _p9();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    (_s8/**/.Pop()?? new _s8()).Set(sender, Value, AutoCSer.Net.TcpServer.ServerTaskType.Timeout, ref inputParameter);
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 9:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p11 inputParameter = new _p11();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    _p12 _outputParameter_ = new _p12();
                                    
                                    int Return;
                                    
                                    Return = Value.addFiles(inputParameter.p2, inputParameter.p0, inputParameter.p3, inputParameter.p1);
                                    _outputParameter_.Return = Return;
                                    sender.Push(_c9, ref _outputParameter_);
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 10:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p13 inputParameter = new _p13();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    _p12 _outputParameter_ = new _p12();
                                    
                                    int Return;
                                    
                                    Return = Value.addAssemblyFiles(inputParameter.p1, inputParameter.p0, inputParameter.p2);
                                    _outputParameter_.Return = Return;
                                    sender.Push(_c10, ref _outputParameter_);
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 11:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p14 inputParameter = new _p14();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    _p12 _outputParameter_ = new _p12();
                                    
                                    int Return;
                                    
                                    Return = Value.addRun(inputParameter.p1, inputParameter.p0, inputParameter.p3, inputParameter.p2);
                                    _outputParameter_.Return = Return;
                                    sender.Push(_c11, ref _outputParameter_);
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        case 12:
                            returnType = AutoCSer.Net.TcpServer.ReturnType.Unknown;
                            try
                            {
                                _p15 inputParameter = new _p15();
                                if (sender.DeSerialize(ref data, ref inputParameter))
                                {
                                    _p12 _outputParameter_ = new _p12();
                                    
                                    int Return;
                                    
                                    Return = Value.addWaitRunSwitch(inputParameter.p0, inputParameter.p1);
                                    _outputParameter_.Return = Return;
                                    sender.Push(_c12, ref _outputParameter_);
                                    return;
                                }
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerDeSerializeError;
                            }
                            catch (Exception error)
                            {
                                returnType = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                                sender.Log(error);
                            }
                            sender.Push(returnType);
                            return;
                        default: return;
                    }
                }
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c0 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 1 };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c1 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 3, IsSimpleSerializeOutputParamter = true };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c2 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 5, IsKeepCallback = 1 };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c3 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 0 };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c4 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 1 };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c5 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 0 };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c6 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 7, IsSimpleSerializeOutputParamter = true };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c7 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 7, IsSimpleSerializeOutputParamter = true };
                sealed class _s8 : AutoCSer.Net.TcpInternalServer.ServerCall<_s8, AutoCSer.Deploy.Server, _p9>
                {
                    private void get(ref AutoCSer.Net.TcpServer.ReturnValue<_p10> value)
                    {
                        try
                        {
                            
                            AutoCSer.Deploy.Directory Return;

                            
                            Return = serverValue.getFileDifferent(inputParameter.p0, inputParameter.p1);

                            value.Value.Return = Return;
                            value.Type = AutoCSer.Net.TcpServer.ReturnType.Success;
                        }
                        catch (Exception error)
                        {
                            value.Type = AutoCSer.Net.TcpServer.ReturnType.ServerException;
                            Sender.Log(error);
                        }
                    }
                    public override void Call()
                    {
                        AutoCSer.Net.TcpServer.ReturnValue<_p10> value = new AutoCSer.Net.TcpServer.ReturnValue<_p10>();
                        if (Sender.IsSocket)
                        {
                            get(ref value);
                            Sender.Push(CommandIndex, _c8, ref value);
                        }
                        push(this);
                    }
                }
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c8 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 10 };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c9 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 12, IsSimpleSerializeOutputParamter = true };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c10 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 12, IsSimpleSerializeOutputParamter = true };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c11 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 12, IsSimpleSerializeOutputParamter = true };
                private static readonly AutoCSer.Net.TcpServer.OutputInfo _c12 = new AutoCSer.Net.TcpServer.OutputInfo { OutputParameterIndex = 12, IsSimpleSerializeOutputParamter = true };

                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [AutoCSer.Metadata.BoxSerialize]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p1
#if NOJIT
                     : AutoCSer.Net.IReturnParameter
#else
                     : AutoCSer.Net.IReturnParameter<AutoCSer.Net.IndexIdentity>
#endif
                {
                    [AutoCSer.Json.IgnoreMember]
                    public AutoCSer.Net.IndexIdentity Ret;
                    [AutoCSer.IOS.Preserve(Conditional = true)]
                    public AutoCSer.Net.IndexIdentity Return
                    {
                        get { return Ret; }
                        set { Ret = value; }
                    }
#if NOJIT
                    [AutoCSer.Metadata.Ignore]
                    public object ReturnObject
                    {
                        get { return Ret; }
                        set { Ret = (AutoCSer.Net.IndexIdentity)value; }
                    }
#endif
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p2
                {
                    public byte[] p0;
                    public long p1;
                    public ulong p2;
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [AutoCSer.Metadata.BoxSerialize]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p3
#if NOJIT
                     : AutoCSer.Net.IReturnParameter
#else
                     : AutoCSer.Net.IReturnParameter<bool>
#endif
                {
                    public long p0;
                    [AutoCSer.Json.IgnoreMember]
                    public bool Ret;
                    [AutoCSer.IOS.Preserve(Conditional = true)]
                    public bool Return
                    {
                        get { return Ret; }
                        set { Ret = value; }
                    }
#if NOJIT
                    [AutoCSer.Metadata.Ignore]
                    public object ReturnObject
                    {
                        get { return Ret; }
                        set { Ret = (bool)value; }
                    }
#endif
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p4
                {
                    public AutoCSer.Net.IndexIdentity p0;
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [AutoCSer.Metadata.BoxSerialize]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p5
#if NOJIT
                     : AutoCSer.Net.IReturnParameter
#else
                     : AutoCSer.Net.IReturnParameter<AutoCSer.Deploy.Log>
#endif
                {
                    [AutoCSer.Json.IgnoreMember]
                    public AutoCSer.Deploy.Log Ret;
                    [AutoCSer.IOS.Preserve(Conditional = true)]
                    public AutoCSer.Deploy.Log Return
                    {
                        get { return Ret; }
                        set { Ret = value; }
                    }
#if NOJIT
                    [AutoCSer.Metadata.Ignore]
                    public object ReturnObject
                    {
                        get { return Ret; }
                        set { Ret = (AutoCSer.Deploy.Log)value; }
                    }
#endif
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p6
                {
                    public AutoCSer.Net.IndexIdentity p0;
                    public System.DateTime p1;
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [AutoCSer.Metadata.BoxSerialize]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p7
#if NOJIT
                     : AutoCSer.Net.IReturnParameter
#else
                     : AutoCSer.Net.IReturnParameter<bool>
#endif
                {
                    [AutoCSer.Json.IgnoreMember]
                    public bool Ret;
                    [AutoCSer.IOS.Preserve(Conditional = true)]
                    public bool Return
                    {
                        get { return Ret; }
                        set { Ret = value; }
                    }
#if NOJIT
                    [AutoCSer.Metadata.Ignore]
                    public object ReturnObject
                    {
                        get { return Ret; }
                        set { Ret = (bool)value; }
                    }
#endif
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p8
                {
                    public AutoCSer.Net.IndexIdentity p0;
                    public byte[][] p1;
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p9
                {
                    public AutoCSer.Deploy.Directory p0;
                    public string p1;
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [AutoCSer.Metadata.BoxSerialize]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p10
#if NOJIT
                     : AutoCSer.Net.IReturnParameter
#else
                     : AutoCSer.Net.IReturnParameter<AutoCSer.Deploy.Directory>
#endif
                {
                    [AutoCSer.Json.IgnoreMember]
                    public AutoCSer.Deploy.Directory Ret;
                    [AutoCSer.IOS.Preserve(Conditional = true)]
                    public AutoCSer.Deploy.Directory Return
                    {
                        get { return Ret; }
                        set { Ret = value; }
                    }
#if NOJIT
                    [AutoCSer.Metadata.Ignore]
                    public object ReturnObject
                    {
                        get { return Ret; }
                        set { Ret = (AutoCSer.Deploy.Directory)value; }
                    }
#endif
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p11
                {
                    public AutoCSer.Deploy.Directory p0;
                    public AutoCSer.Deploy.TaskType p1;
                    public AutoCSer.Net.IndexIdentity p2;
                    public string p3;
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [AutoCSer.Metadata.BoxSerialize]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p12
#if NOJIT
                     : AutoCSer.Net.IReturnParameter
#else
                     : AutoCSer.Net.IReturnParameter<int>
#endif
                {
                    [AutoCSer.Json.IgnoreMember]
                    public int Ret;
                    [AutoCSer.IOS.Preserve(Conditional = true)]
                    public int Return
                    {
                        get { return Ret; }
                        set { Ret = value; }
                    }
#if NOJIT
                    [AutoCSer.Metadata.Ignore]
                    public object ReturnObject
                    {
                        get { return Ret; }
                        set { Ret = (int)value; }
                    }
#endif
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p13
                {
                    public AutoCSer.KeyValue<string,int>[] p0;
                    public AutoCSer.Net.IndexIdentity p1;
                    public string p2;
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p14
                {
                    public AutoCSer.KeyValue<string,int>[] p0;
                    public AutoCSer.Net.IndexIdentity p1;
                    public int p2;
                    public string p3;
                }
                [AutoCSer.BinarySerialize.Serialize(IsMemberMap = false, IsReferenceMember = false)]
                [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]
                internal struct _p15
                {
                    public AutoCSer.Net.IndexIdentity p0;
                    public int p1;
                }
            }
            /// <summary>
            /// TCP客户端
            /// </summary>
            public class TcpInternalClient : AutoCSer.Net.TcpInternalServer.MethodClient<TcpInternalClient>
            {
                private bool _timerVerify_(TcpInternalClient client, AutoCSer.Net.TcpInternalServer.ClientSocketSender sender)
                {
                    return AutoCSer.Net.TcpInternalServer.TimeVerifyClient.Verify(verify, sender, _TcpClient_);
                }
                /// <summary>
                /// TCP调用客户端
                /// </summary>
                /// <param name="attribute">TCP 调用服务器端配置信息</param>
                /// <param name="verifyMethod">TCP 验证方法</param>
                /// <param name="onCustomData">自定义数据包处理</param>
                /// <param name="log">日志接口</param>
                public TcpInternalClient(AutoCSer.Net.TcpInternalServer.ServerAttribute attribute = null, Func<TcpInternalClient, AutoCSer.Net.TcpInternalServer.ClientSocketSender, bool> verifyMethod = null, Action<SubArray<byte>> onCustomData = null, AutoCSer.Log.ILog log = null)
                {
                    if (attribute == null)
                    {
                        attribute = AutoCSer.Net.TcpInternalServer.ServerAttribute.GetConfig("Deploy", typeof(AutoCSer.Deploy.Server));
                    }
                    _TcpClient_ = new AutoCSer.Net.TcpInternalServer.Client<TcpInternalClient>(this, attribute, onCustomData, log, verifyMethod ?? (Func<TcpInternalClient, AutoCSer.Net.TcpInternalServer.ClientSocketSender, bool>)_timerVerify_);
                    if (attribute.IsAuto) _TcpClient_.TryCreateSocket();
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c0 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 0 + 128, InputParameterIndex = 0, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous };

                /// <summary>
                /// 注册客户端
                /// </summary>
                public AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Net.IndexIdentity> register()
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p1> _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p1>.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p1 _outputParameter_ = new TcpInternalServer._p1
                            {
                            };
                            AutoCSer.Net.TcpServer.ReturnType _returnType_ = _socket_.WaitGet<TcpInternalServer._p1>(_c0, ref _wait_, ref _outputParameter_);
                            return new AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Net.IndexIdentity> { Type = _returnType_, Value = _outputParameter_.Return };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p1>.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Net.IndexIdentity> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c1 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 1 + 128, InputParameterIndex = 2, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous, IsVerifyMethod = true, IsSimpleSerializeOutputParamter = true };

                public AutoCSer.Net.TcpServer.ReturnValue<bool> verify(AutoCSer.Net.TcpInternalServer.ClientSocketSender _sender_, ulong randomPrefix, byte[] md5Data, ref long ticks)
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p3> _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p3>.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _sender_;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p2 _inputParameter_ = new TcpInternalServer._p2
                            {
                                
                                p2 = randomPrefix,
                                
                                p0 = md5Data,
                                
                                p1 = ticks,
                            };
                            TcpInternalServer._p3 _outputParameter_ = new TcpInternalServer._p3
                            {
                                
                                p0 = ticks,
                            };
                            AutoCSer.Net.TcpServer.ReturnType _returnType_ = _socket_.WaitGet<TcpInternalServer._p2, TcpInternalServer._p3>(_c1, ref _wait_, ref _inputParameter_, ref _outputParameter_);
                            
                            ticks = _outputParameter_.p0;
                            return new AutoCSer.Net.TcpServer.ReturnValue<bool> { Type = _returnType_, Value = _outputParameter_.Return };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p3>.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<bool> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }


                private static readonly AutoCSer.Net.TcpServer.CommandInfo _ac2 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 2 + 128, InputParameterIndex = 4, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Timeout, IsKeepCallback = 1 };
                /// <summary>
                /// 部署任务状态轮询
                /// </summary>
                /// <param name="clientId">服务端标识</param>
                /// <returns>保持异步回调</returns>
                public AutoCSer.Net.TcpServer.KeepCallback getLog(AutoCSer.Net.IndexIdentity clientId, Action<AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Deploy.Log>> _onReturn_)
                {
                    AutoCSer.Net.Callback<AutoCSer.Net.TcpServer.ReturnValue<TcpInternalServer._p5>> _onOutput_ = _TcpClient_.GetCallback<AutoCSer.Deploy.Log, TcpInternalServer._p5>(_onReturn_);
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p4 _inputParameter_ = new TcpInternalServer._p4
                            {
                                
                                p0 = clientId,
                            };
                            return _socket_.GetKeep<TcpInternalServer._p4, TcpInternalServer._p5>(_ac2, ref _onOutput_, ref _inputParameter_);
                        }
                    }
                    finally
                    {
                        if (_onOutput_ != null)
                        {
                            AutoCSer.Net.TcpServer.ReturnValue<TcpInternalServer._p5> _outputParameter_ = new AutoCSer.Net.TcpServer.ReturnValue<TcpInternalServer._p5> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                            _onOutput_.Call(ref _outputParameter_);
                        }
                    }
                    return null;
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c3 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 3 + 128, InputParameterIndex = 0, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous };

                /// <summary>
                /// 清除所有部署任务
                /// </summary>
                public AutoCSer.Net.TcpServer.ReturnValue clear()
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            return new AutoCSer.Net.TcpServer.ReturnValue { Type = _socket_.WaitCall(_c3, ref _wait_) };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }
                /// <summary>
                /// 清除所有部署任务
                /// </summary>
                public AutoCSer.Net.TcpServer.Awaiter clearAwaiter()
                {
                    AutoCSer.Net.TcpServer.Awaiter _awaiter_ = new AutoCSer.Net.TcpServer.Awaiter();
                    AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                    if (_socket_ != null)
                    {
                        AutoCSer.Net.TcpServer.ReturnType _returnType_;
                        _returnType_ = _socket_.GetAwaiter(_c3, _awaiter_);
                        if (_returnType_ != AutoCSer.Net.TcpServer.ReturnType.Success) _awaiter_.Call(_returnType_);
                    }
                    else _awaiter_.Call(AutoCSer.Net.TcpServer.ReturnType.ClientException);
                    return _awaiter_;
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c4 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 4 + 128, InputParameterIndex = 4, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous };

                /// <summary>
                /// 创建部署
                /// </summary>
                /// <param name="clientId">部署服务端标识</param>
                /// <returns>部署信息索引标识</returns>
                public AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Net.IndexIdentity> create(AutoCSer.Net.IndexIdentity clientId)
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p1> _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p1>.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p4 _inputParameter_ = new TcpInternalServer._p4
                            {
                                
                                p0 = clientId,
                            };
                            TcpInternalServer._p1 _outputParameter_ = new TcpInternalServer._p1
                            {
                            };
                            AutoCSer.Net.TcpServer.ReturnType _returnType_ = _socket_.WaitGet<TcpInternalServer._p4, TcpInternalServer._p1>(_c4, ref _wait_, ref _inputParameter_, ref _outputParameter_);
                            return new AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Net.IndexIdentity> { Type = _returnType_, Value = _outputParameter_.Return };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p1>.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Net.IndexIdentity> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }
                /// <summary>
                /// 创建部署
                /// </summary>
                /// <param name="clientId">部署服务端标识</param>
                /// <returns>部署信息索引标识</returns>
                public AutoCSer.Net.TcpServer.AwaiterBox<AutoCSer.Net.IndexIdentity> createAwaiter(AutoCSer.Net.IndexIdentity clientId)
                {
                    AutoCSer.Net.TcpServer.AwaiterBox<AutoCSer.Net.IndexIdentity> _awaiter_ = new AutoCSer.Net.TcpServer.AwaiterBox<AutoCSer.Net.IndexIdentity>();
                    AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                    if (_socket_ != null)
                    {
                        TcpInternalServer._p4 _inputParameter_ = new TcpInternalServer._p4
                        {
                            
                            p0 = clientId,
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_;
                        AutoCSer.Net.TcpServer.AwaiterReturnValueBox<AutoCSer.Net.IndexIdentity> _outputParameter_ = default(AutoCSer.Net.TcpServer.AwaiterReturnValueBox<AutoCSer.Net.IndexIdentity>);
                        _returnType_ = _socket_.GetAwaiter<TcpInternalServer._p4, AutoCSer.Net.TcpServer.AwaiterReturnValueBox<AutoCSer.Net.IndexIdentity>>(_c4, _awaiter_, ref _inputParameter_, ref _outputParameter_);
                        if (_returnType_ != AutoCSer.Net.TcpServer.ReturnType.Success) _awaiter_.Call(_returnType_);
                    }
                    else _awaiter_.Call(AutoCSer.Net.TcpServer.ReturnType.ClientException);
                    return _awaiter_;
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c5 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 5 + 128, InputParameterIndex = 4, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous };

                /// <summary>
                /// 清除部署信息
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                public AutoCSer.Net.TcpServer.ReturnValue clear(AutoCSer.Net.IndexIdentity identity)
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p4 _inputParameter_ = new TcpInternalServer._p4
                            {
                                
                                p0 = identity,
                            };
                            return new AutoCSer.Net.TcpServer.ReturnValue { Type = _socket_.WaitCall(_c5, ref _wait_, ref _inputParameter_) };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }
                /// <summary>
                /// 清除部署信息
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                public AutoCSer.Net.TcpServer.Awaiter clearAwaiter(AutoCSer.Net.IndexIdentity identity)
                {
                    AutoCSer.Net.TcpServer.Awaiter _awaiter_ = new AutoCSer.Net.TcpServer.Awaiter();
                    AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                    if (_socket_ != null)
                    {
                        TcpInternalServer._p4 _inputParameter_ = new TcpInternalServer._p4
                        {
                            
                            p0 = identity,
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_;
                        _returnType_ = _socket_.GetAwaiter(_c5, _awaiter_, ref _inputParameter_);
                        if (_returnType_ != AutoCSer.Net.TcpServer.ReturnType.Success) _awaiter_.Call(_returnType_);
                    }
                    else _awaiter_.Call(AutoCSer.Net.TcpServer.ReturnType.ClientException);
                    return _awaiter_;
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c6 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 6 + 128, InputParameterIndex = 6, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous, IsSimpleSerializeOutputParamter = true };

                /// <summary>
                /// 启动部署
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="time">启动时间</param>
                public AutoCSer.Net.TcpServer.ReturnValue<bool> start(AutoCSer.Net.IndexIdentity identity, System.DateTime time)
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p7> _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p7>.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p6 _inputParameter_ = new TcpInternalServer._p6
                            {
                                
                                p0 = identity,
                                
                                p1 = time,
                            };
                            TcpInternalServer._p7 _outputParameter_ = new TcpInternalServer._p7
                            {
                            };
                            AutoCSer.Net.TcpServer.ReturnType _returnType_ = _socket_.WaitGet<TcpInternalServer._p6, TcpInternalServer._p7>(_c6, ref _wait_, ref _inputParameter_, ref _outputParameter_);
                            return new AutoCSer.Net.TcpServer.ReturnValue<bool> { Type = _returnType_, Value = _outputParameter_.Return };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p7>.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<bool> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }
                /// <summary>
                /// 启动部署
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="time">启动时间</param>
                public AutoCSer.Net.TcpServer.AwaiterBox<bool> startAwaiter(AutoCSer.Net.IndexIdentity identity, System.DateTime time)
                {
                    AutoCSer.Net.TcpServer.AwaiterBox<bool> _awaiter_ = new AutoCSer.Net.TcpServer.AwaiterBox<bool>();
                    AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                    if (_socket_ != null)
                    {
                        TcpInternalServer._p6 _inputParameter_ = new TcpInternalServer._p6
                        {
                            
                            p0 = identity,
                            
                            p1 = time,
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_;
                        AutoCSer.Net.TcpServer.AwaiterReturnValueBox<bool> _outputParameter_ = default(AutoCSer.Net.TcpServer.AwaiterReturnValueBox<bool>);
                        _returnType_ = _socket_.GetAwaiter<TcpInternalServer._p6, AutoCSer.Net.TcpServer.AwaiterReturnValueBox<bool>>(_c6, _awaiter_, ref _inputParameter_, ref _outputParameter_);
                        if (_returnType_ != AutoCSer.Net.TcpServer.ReturnType.Success) _awaiter_.Call(_returnType_);
                    }
                    else _awaiter_.Call(AutoCSer.Net.TcpServer.ReturnType.ClientException);
                    return _awaiter_;
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c7 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 7 + 128, InputParameterIndex = 8, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous, IsSimpleSerializeOutputParamter = true };

                /// <summary>
                /// 设置文件数据源
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="files">文件数据源</param>
                public AutoCSer.Net.TcpServer.ReturnValue<bool> setFileSource(AutoCSer.Net.IndexIdentity identity, byte[][] files)
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p7> _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p7>.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p8 _inputParameter_ = new TcpInternalServer._p8
                            {
                                
                                p0 = identity,
                                
                                p1 = files,
                            };
                            TcpInternalServer._p7 _outputParameter_ = new TcpInternalServer._p7
                            {
                            };
                            AutoCSer.Net.TcpServer.ReturnType _returnType_ = _socket_.WaitGet<TcpInternalServer._p8, TcpInternalServer._p7>(_c7, ref _wait_, ref _inputParameter_, ref _outputParameter_);
                            return new AutoCSer.Net.TcpServer.ReturnValue<bool> { Type = _returnType_, Value = _outputParameter_.Return };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p7>.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<bool> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }
                /// <summary>
                /// 设置文件数据源
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="files">文件数据源</param>
                public AutoCSer.Net.TcpServer.AwaiterBox<bool> setFileSourceAwaiter(AutoCSer.Net.IndexIdentity identity, byte[][] files)
                {
                    AutoCSer.Net.TcpServer.AwaiterBox<bool> _awaiter_ = new AutoCSer.Net.TcpServer.AwaiterBox<bool>();
                    AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                    if (_socket_ != null)
                    {
                        TcpInternalServer._p8 _inputParameter_ = new TcpInternalServer._p8
                        {
                            
                            p0 = identity,
                            
                            p1 = files,
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_;
                        AutoCSer.Net.TcpServer.AwaiterReturnValueBox<bool> _outputParameter_ = default(AutoCSer.Net.TcpServer.AwaiterReturnValueBox<bool>);
                        _returnType_ = _socket_.GetAwaiter<TcpInternalServer._p8, AutoCSer.Net.TcpServer.AwaiterReturnValueBox<bool>>(_c7, _awaiter_, ref _inputParameter_, ref _outputParameter_);
                        if (_returnType_ != AutoCSer.Net.TcpServer.ReturnType.Success) _awaiter_.Call(_returnType_);
                    }
                    else _awaiter_.Call(AutoCSer.Net.TcpServer.ReturnType.ClientException);
                    return _awaiter_;
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c8 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 8 + 128, InputParameterIndex = 9, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous };

                /// <summary>
                /// 比较文件最后修改时间
                /// </summary>
                /// <param name="directory">目录信息</param>
                /// <param name="serverPath">服务器端路径</param>
                public AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Deploy.Directory> getFileDifferent(AutoCSer.Deploy.Directory directory, string serverPath)
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p10> _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p10>.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p9 _inputParameter_ = new TcpInternalServer._p9
                            {
                                
                                p0 = directory,
                                
                                p1 = serverPath,
                            };
                            TcpInternalServer._p10 _outputParameter_ = new TcpInternalServer._p10
                            {
                            };
                            AutoCSer.Net.TcpServer.ReturnType _returnType_ = _socket_.WaitGet<TcpInternalServer._p9, TcpInternalServer._p10>(_c8, ref _wait_, ref _inputParameter_, ref _outputParameter_);
                            return new AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Deploy.Directory> { Type = _returnType_, Value = _outputParameter_.Return };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p10>.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<AutoCSer.Deploy.Directory> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }
                /// <summary>
                /// 比较文件最后修改时间
                /// </summary>
                /// <param name="directory">目录信息</param>
                /// <param name="serverPath">服务器端路径</param>
                public AutoCSer.Net.TcpServer.AwaiterBox<AutoCSer.Deploy.Directory> getFileDifferentAwaiter(AutoCSer.Deploy.Directory directory, string serverPath)
                {
                    AutoCSer.Net.TcpServer.AwaiterBox<AutoCSer.Deploy.Directory> _awaiter_ = new AutoCSer.Net.TcpServer.AwaiterBox<AutoCSer.Deploy.Directory>();
                    AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                    if (_socket_ != null)
                    {
                        TcpInternalServer._p9 _inputParameter_ = new TcpInternalServer._p9
                        {
                            
                            p0 = directory,
                            
                            p1 = serverPath,
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_;
                        AutoCSer.Net.TcpServer.AwaiterReturnValueBox<AutoCSer.Deploy.Directory> _outputParameter_ = default(AutoCSer.Net.TcpServer.AwaiterReturnValueBox<AutoCSer.Deploy.Directory>);
                        _returnType_ = _socket_.GetAwaiter<TcpInternalServer._p9, AutoCSer.Net.TcpServer.AwaiterReturnValueBox<AutoCSer.Deploy.Directory>>(_c8, _awaiter_, ref _inputParameter_, ref _outputParameter_);
                        if (_returnType_ != AutoCSer.Net.TcpServer.ReturnType.Success) _awaiter_.Call(_returnType_);
                    }
                    else _awaiter_.Call(AutoCSer.Net.TcpServer.ReturnType.ClientException);
                    return _awaiter_;
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c9 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 9 + 128, InputParameterIndex = 11, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous, IsSimpleSerializeOutputParamter = true };

                /// <summary>
                /// 添加web任务(css/js/html)
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="directory">目录信息</param>
                /// <param name="serverPath">服务器端路径</param>
                /// <param name="taskType">任务类型</param>
                /// <returns>任务索引编号,-1表示失败</returns>
                public AutoCSer.Net.TcpServer.ReturnValue<int> addFiles(AutoCSer.Net.IndexIdentity identity, AutoCSer.Deploy.Directory directory, string serverPath, AutoCSer.Deploy.TaskType taskType)
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12> _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12>.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p11 _inputParameter_ = new TcpInternalServer._p11
                            {
                                
                                p2 = identity,
                                
                                p0 = directory,
                                
                                p3 = serverPath,
                                
                                p1 = taskType,
                            };
                            TcpInternalServer._p12 _outputParameter_ = new TcpInternalServer._p12
                            {
                            };
                            AutoCSer.Net.TcpServer.ReturnType _returnType_ = _socket_.WaitGet<TcpInternalServer._p11, TcpInternalServer._p12>(_c9, ref _wait_, ref _inputParameter_, ref _outputParameter_);
                            return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = _returnType_, Value = _outputParameter_.Return };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12>.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }
                /// <summary>
                /// 添加web任务(css/js/html)
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="directory">目录信息</param>
                /// <param name="serverPath">服务器端路径</param>
                /// <param name="taskType">任务类型</param>
                /// <returns>任务索引编号,-1表示失败</returns>
                public AutoCSer.Net.TcpServer.AwaiterBox<int> addFilesAwaiter(AutoCSer.Net.IndexIdentity identity, AutoCSer.Deploy.Directory directory, string serverPath, AutoCSer.Deploy.TaskType taskType)
                {
                    AutoCSer.Net.TcpServer.AwaiterBox<int> _awaiter_ = new AutoCSer.Net.TcpServer.AwaiterBox<int>();
                    AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                    if (_socket_ != null)
                    {
                        TcpInternalServer._p11 _inputParameter_ = new TcpInternalServer._p11
                        {
                            
                            p2 = identity,
                            
                            p0 = directory,
                            
                            p3 = serverPath,
                            
                            p1 = taskType,
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_;
                        AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int> _outputParameter_ = default(AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int>);
                        _returnType_ = _socket_.GetAwaiter<TcpInternalServer._p11, AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int>>(_c9, _awaiter_, ref _inputParameter_, ref _outputParameter_);
                        if (_returnType_ != AutoCSer.Net.TcpServer.ReturnType.Success) _awaiter_.Call(_returnType_);
                    }
                    else _awaiter_.Call(AutoCSer.Net.TcpServer.ReturnType.ClientException);
                    return _awaiter_;
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c10 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 10 + 128, InputParameterIndex = 13, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous, IsSimpleSerializeOutputParamter = true };

                /// <summary>
                /// 写文件
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="files">文件集合</param>
                /// <param name="serverPath">服务器端路径</param>
                /// <returns>任务索引编号,-1表示失败</returns>
                public AutoCSer.Net.TcpServer.ReturnValue<int> addAssemblyFiles(AutoCSer.Net.IndexIdentity identity, AutoCSer.KeyValue<string,int>[] files, string serverPath)
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12> _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12>.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p13 _inputParameter_ = new TcpInternalServer._p13
                            {
                                
                                p1 = identity,
                                
                                p0 = files,
                                
                                p2 = serverPath,
                            };
                            TcpInternalServer._p12 _outputParameter_ = new TcpInternalServer._p12
                            {
                            };
                            AutoCSer.Net.TcpServer.ReturnType _returnType_ = _socket_.WaitGet<TcpInternalServer._p13, TcpInternalServer._p12>(_c10, ref _wait_, ref _inputParameter_, ref _outputParameter_);
                            return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = _returnType_, Value = _outputParameter_.Return };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12>.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }
                /// <summary>
                /// 写文件
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="files">文件集合</param>
                /// <param name="serverPath">服务器端路径</param>
                /// <returns>任务索引编号,-1表示失败</returns>
                public AutoCSer.Net.TcpServer.AwaiterBox<int> addAssemblyFilesAwaiter(AutoCSer.Net.IndexIdentity identity, AutoCSer.KeyValue<string,int>[] files, string serverPath)
                {
                    AutoCSer.Net.TcpServer.AwaiterBox<int> _awaiter_ = new AutoCSer.Net.TcpServer.AwaiterBox<int>();
                    AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                    if (_socket_ != null)
                    {
                        TcpInternalServer._p13 _inputParameter_ = new TcpInternalServer._p13
                        {
                            
                            p1 = identity,
                            
                            p0 = files,
                            
                            p2 = serverPath,
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_;
                        AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int> _outputParameter_ = default(AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int>);
                        _returnType_ = _socket_.GetAwaiter<TcpInternalServer._p13, AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int>>(_c10, _awaiter_, ref _inputParameter_, ref _outputParameter_);
                        if (_returnType_ != AutoCSer.Net.TcpServer.ReturnType.Success) _awaiter_.Call(_returnType_);
                    }
                    else _awaiter_.Call(AutoCSer.Net.TcpServer.ReturnType.ClientException);
                    return _awaiter_;
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c11 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 11 + 128, InputParameterIndex = 14, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous, IsSimpleSerializeOutputParamter = true };

                /// <summary>
                /// 写文件并运行程序
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="files">文件集合</param>
                /// <param name="serverPath">服务器端路径</param>
                /// <param name="runSleep">运行前休眠</param>
                /// <returns>任务索引编号,-1表示失败</returns>
                public AutoCSer.Net.TcpServer.ReturnValue<int> addRun(AutoCSer.Net.IndexIdentity identity, AutoCSer.KeyValue<string,int>[] files, string serverPath, int runSleep)
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12> _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12>.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p14 _inputParameter_ = new TcpInternalServer._p14
                            {
                                
                                p1 = identity,
                                
                                p0 = files,
                                
                                p3 = serverPath,
                                
                                p2 = runSleep,
                            };
                            TcpInternalServer._p12 _outputParameter_ = new TcpInternalServer._p12
                            {
                            };
                            AutoCSer.Net.TcpServer.ReturnType _returnType_ = _socket_.WaitGet<TcpInternalServer._p14, TcpInternalServer._p12>(_c11, ref _wait_, ref _inputParameter_, ref _outputParameter_);
                            return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = _returnType_, Value = _outputParameter_.Return };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12>.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }
                /// <summary>
                /// 写文件并运行程序
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="files">文件集合</param>
                /// <param name="serverPath">服务器端路径</param>
                /// <param name="runSleep">运行前休眠</param>
                /// <returns>任务索引编号,-1表示失败</returns>
                public AutoCSer.Net.TcpServer.AwaiterBox<int> addRunAwaiter(AutoCSer.Net.IndexIdentity identity, AutoCSer.KeyValue<string,int>[] files, string serverPath, int runSleep)
                {
                    AutoCSer.Net.TcpServer.AwaiterBox<int> _awaiter_ = new AutoCSer.Net.TcpServer.AwaiterBox<int>();
                    AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                    if (_socket_ != null)
                    {
                        TcpInternalServer._p14 _inputParameter_ = new TcpInternalServer._p14
                        {
                            
                            p1 = identity,
                            
                            p0 = files,
                            
                            p3 = serverPath,
                            
                            p2 = runSleep,
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_;
                        AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int> _outputParameter_ = default(AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int>);
                        _returnType_ = _socket_.GetAwaiter<TcpInternalServer._p14, AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int>>(_c11, _awaiter_, ref _inputParameter_, ref _outputParameter_);
                        if (_returnType_ != AutoCSer.Net.TcpServer.ReturnType.Success) _awaiter_.Call(_returnType_);
                    }
                    else _awaiter_.Call(AutoCSer.Net.TcpServer.ReturnType.ClientException);
                    return _awaiter_;
                }

                private static readonly AutoCSer.Net.TcpServer.CommandInfo _c12 = new AutoCSer.Net.TcpServer.CommandInfo { Command = 12 + 128, InputParameterIndex = 15, IsSendOnly = 0, TaskType = AutoCSer.Net.TcpServer.ClientTaskType.Synchronous, IsSimpleSerializeOutputParamter = true };

                /// <summary>
                /// 等待运行程序切换结束
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="taskIndex">任务索引位置</param>
                /// <returns>任务索引编号,-1表示失败</returns>
                public AutoCSer.Net.TcpServer.ReturnValue<int> addWaitRunSwitch(AutoCSer.Net.IndexIdentity identity, int taskIndex)
                {
                    AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12> _wait_ = AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12>.Pop();
                    try
                    {
                        AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                        if (_socket_ != null)
                        {
                            TcpInternalServer._p15 _inputParameter_ = new TcpInternalServer._p15
                            {
                                
                                p0 = identity,
                                
                                p1 = taskIndex,
                            };
                            TcpInternalServer._p12 _outputParameter_ = new TcpInternalServer._p12
                            {
                            };
                            AutoCSer.Net.TcpServer.ReturnType _returnType_ = _socket_.WaitGet<TcpInternalServer._p15, TcpInternalServer._p12>(_c12, ref _wait_, ref _inputParameter_, ref _outputParameter_);
                            return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = _returnType_, Value = _outputParameter_.Return };
                        }
                    }
                    finally
                    {
                        if (_wait_ != null) AutoCSer.Net.TcpServer.AutoWaitReturnValue<TcpInternalServer._p12>.PushNotNull(_wait_);
                    }
                    return new AutoCSer.Net.TcpServer.ReturnValue<int> { Type = AutoCSer.Net.TcpServer.ReturnType.ClientException };
                }
                /// <summary>
                /// 等待运行程序切换结束
                /// </summary>
                /// <param name="identity">部署信息索引标识</param>
                /// <param name="taskIndex">任务索引位置</param>
                /// <returns>任务索引编号,-1表示失败</returns>
                public AutoCSer.Net.TcpServer.AwaiterBox<int> addWaitRunSwitchAwaiter(AutoCSer.Net.IndexIdentity identity, int taskIndex)
                {
                    AutoCSer.Net.TcpServer.AwaiterBox<int> _awaiter_ = new AutoCSer.Net.TcpServer.AwaiterBox<int>();
                    AutoCSer.Net.TcpInternalServer.ClientSocketSender _socket_ = _TcpClient_.Sender;
                    if (_socket_ != null)
                    {
                        TcpInternalServer._p15 _inputParameter_ = new TcpInternalServer._p15
                        {
                            
                            p0 = identity,
                            
                            p1 = taskIndex,
                        };
                        AutoCSer.Net.TcpServer.ReturnType _returnType_;
                        AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int> _outputParameter_ = default(AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int>);
                        _returnType_ = _socket_.GetAwaiter<TcpInternalServer._p15, AutoCSer.Net.TcpServer.AwaiterReturnValueBox<int>>(_c12, _awaiter_, ref _inputParameter_, ref _outputParameter_);
                        if (_returnType_ != AutoCSer.Net.TcpServer.ReturnType.Success) _awaiter_.Call(_returnType_);
                    }
                    else _awaiter_.Call(AutoCSer.Net.TcpServer.ReturnType.ClientException);
                    return _awaiter_;
                }

            }
        }
}
#endif