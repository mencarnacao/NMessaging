using System;
using NMessaging.Transport.Outgoing.Message.Data.Reporting;
using NMessaging.Transport.Message;
using NMessaging.Transport.Outgoing.Message.Data.Trace;

namespace NMessaging.Transport.Outgoing.Message.Data
{
    public delegate void OnMessageSentDelegate(MessageDataSentReport pMessageDataSentReport);
    public delegate void OnMessageNotSentDelegate(MessageDataNotSentReport pMessageDataNotSentReport);

    public interface IMessageData<T> : IMessage
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        MessageContentType MessageContentType { get; }

        MessageDataType MessageDataType { get; }

        TraceStage TraceStage { get; }

        T Data { get; }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        void MessageWasSent(Guid pMessageID, long pProcessingTime);

        //////////////////////////////

        void MessageWasNotSent(Guid pMessageID);

        //////////////////////////////

        byte[] Serialize();

        //////////////////////////////
    }
}