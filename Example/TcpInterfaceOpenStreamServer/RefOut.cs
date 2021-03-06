﻿using System;

namespace AutoCSer.Example.TcpInterfaceOpenStreamServer
{
    /// <summary>
    /// ref / out 参数测试接口
    /// </summary>
    [AutoCSer.Net.TcpOpenStreamServer.Server(Host = "127.0.0.1", Port = 12700, IsRemoteExpression = true)]
    public interface IRefOut
    {
        /// <summary>
        /// ref / out 参数测试
        /// </summary>
        /// <param name="left">加法左值</param>
        /// <param name="right">加法右值</param>
        /// <param name="product">乘积</param>
        /// <returns>和</returns>
        AutoCSer.Net.TcpServer.ReturnValue<int> Add(int left, ref int right, out int product); 
    }
    /// <summary>
    /// ref / out 参数测试 示例
    /// </summary>
    class RefOut : IRefOut
    {
        /// <summary>
        /// ref / out 参数测试
        /// </summary>
        /// <param name="left">加法左值</param>
        /// <param name="right">加法右值</param>
        /// <param name="product">乘积</param>
        /// <returns>和</returns>
        public AutoCSer.Net.TcpServer.ReturnValue<int> Add(int left, ref int right, out int product)
        {
            product = left * right;
            int sum = left + right;
            right <<= 1;
            return sum;
        }

        /// <summary>
        /// ref / out 参数 测试
        /// </summary>
        /// <returns></returns>
        [AutoCSer.Metadata.TestMethod]
        internal static bool TestCase()
        {
            using (AutoCSer.Net.TcpOpenStreamServer.Server server = AutoCSer.Net.TcpOpenStreamServer.Emit.Server<IRefOut>.Create(new RefOut()))
            {
                if (server.IsListen)
                {
                    IRefOut client = AutoCSer.Net.TcpOpenStreamServer.Emit.Client<IRefOut>.Create();
                    using (client as IDisposable)
                    {
                        int right = 3, product;
                        AutoCSer.Net.TcpServer.ReturnValue<int> sum = client.Add(2, ref right, out product);
                        return sum.Type == AutoCSer.Net.TcpServer.ReturnType.Success && sum.Value == 2 + 3 && right == (3 << 1) && product == 2 * 3;
                    }
                }
            }
            return false;
        }
    }
}
