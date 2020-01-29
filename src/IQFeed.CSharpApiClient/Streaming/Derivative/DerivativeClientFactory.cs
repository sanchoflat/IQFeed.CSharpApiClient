﻿using IQFeed.CSharpApiClient.Socket;
using IQFeed.CSharpApiClient.Streaming.Derivative.Handlers;

namespace IQFeed.CSharpApiClient.Streaming.Derivative
{
    public class DerivativeClientFactory
    {
        public static DerivativeClient<T> CreateNew<T>(
            string host,
            int port,
            int bufferSize,
            IDerivativeMessageHandler<T> derivativeMessageHandler)
        {
            return new DerivativeClient<T>(
                new SocketClient(host, port, bufferSize),
                new DerivativeRequestFormatter(),
                derivativeMessageHandler);
        }

        public static DerivativeClient<decimal> CreateNew()
        {
            return CreateNew(
                IQFeedDefault.Hostname,
                IQFeedDefault.DerivativePort,
                DerivativeDefault.BufferSize,
                new DerivativeMessageDecimalHandler());
        }

        public static DerivativeClient<decimal> CreateNew(string host, int port)
        {
            return CreateNew(host, port, DerivativeDefault.BufferSize, new DerivativeMessageDecimalHandler());
        }

        public static DerivativeClient<decimal> CreateNew(string host, int port, int bufferSize)
        {
            return CreateNew(host, port, bufferSize, new DerivativeMessageDecimalHandler());
        }
    }
}