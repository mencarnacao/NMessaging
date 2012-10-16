using System;
using NMessaging.Transport.Message.Outgoing.Data.Reporting;
using NMessaging.Transport.Message.Outgoing.Data.Trace;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public delegate void OnMessageSentDelegate(MessageDataSentReport pMessageDataSentReport);
    public delegate void OnMessageNotSentDelegate(MessageDataNotSentReport pMessageDataNotSentReport);

    public interface IMessageData : IMessage
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        MessageContentType MessageContentType { get; }

        MessageDataType MessageDataType { get; }

        TraceStage TraceStage { get; }

        object Data { get; }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        void MessageWasSent(Guid pMessageID, long pProcessingTime);

        //////////////////////////////

        void MessageWasNotSent(Guid pMessageID);

        //////////////////////////////
    }
}