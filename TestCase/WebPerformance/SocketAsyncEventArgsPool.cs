﻿using System;
using System.Net.Sockets;
using System.Threading;

namespace AutoCSer.TestCase.WebPerformance
{
    /// <summary>
    /// 套接字异步事件对象池
    /// </summary>
    internal static class SocketAsyncEventArgsPool
    {
        /// <summary>
        /// 缓存数量
        /// </summary>
        private readonly static int maxCount = AutoCSer.Config.Pub.Default.GetYieldPoolCount(typeof(SocketAsyncEventArgs));
        /// <summary>
        /// 套接字异步事件对象池首节点
        /// </summary>
        private static SocketAsyncEventArgs head;
        /// <summary>
        /// 套接字异步事件对象池弹出节点访问锁
        /// </summary>
        private static int popLock;
        /// <summary>
        /// 缓存数量
        /// </summary>
        private static int count;
        /// <summary>
        /// 弹出节点
        /// </summary>
        /// <returns></returns>
        internal static SocketAsyncEventArgs Get()
        {
            SocketAsyncEventArgs value;
            AutoCSer.Threading.Interlocked.CompareExchangeYield(ref popLock);
            do
            {
                if ((value = head) == null)
                {
                    popLock = 0;
                    value = new SocketAsyncEventArgs();
                    value.SocketFlags = System.Net.Sockets.SocketFlags.None;
                    value.DisconnectReuseSocket = false;
                    return value;
                }
                if (Interlocked.CompareExchange(ref head, new UnionType { Value = value.UserToken }.SocketAsyncEventArgs, value) == value)
                {
                    popLock = 0;
                    System.Threading.Interlocked.Decrement(ref count);
                    value.UserToken = null;
                    return value;
                }
                AutoCSer.Threading.ThreadYield.Yield();
            }
            while (true);
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="value"></param>
        internal static void PushNotNull(ref SocketAsyncEventArgs value)
        {
            SocketAsyncEventArgs newValue = Interlocked.Exchange(ref value, null);
            if (newValue != null)
            {
                if (count >= maxCount) return;
                System.Threading.Interlocked.Increment(ref count);
                newValue.SetBuffer(null, 0, 0);
                newValue.UserToken = null;
                newValue.SocketError = SocketError.Success;
                SocketAsyncEventArgs oldHead;
                do
                {
                    if ((oldHead = head) == null)
                    {
                        newValue.UserToken = null;
                        if (System.Threading.Interlocked.CompareExchange(ref head, newValue, null) == null) return;
                    }
                    else
                    {
                        newValue.UserToken = oldHead;
                        if (System.Threading.Interlocked.CompareExchange(ref head, newValue, oldHead) == oldHead) return;
                    }
                    AutoCSer.Threading.ThreadYield.Yield();
                }
                while (true);
            }
        }
    }
}
