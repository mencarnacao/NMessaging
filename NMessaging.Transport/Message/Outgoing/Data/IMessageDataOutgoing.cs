using System;
using NMessaging.Transport.Message.Data;
using NMessaging.Transport.Message.Outgoing.Data.Reporting;
using NMessaging.Transport.Message.Outgoing.Data.Trace;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public delegate void OnMessageSentDelegate(MessageDataSentReport pMessageDataSentReport);
    public delegate void OnMessageNotSentDelegate(MessageDataNotSentReport pMessageDataNotSentReport);

    public interface IMessageDataOutgoing : IMessageData
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        TraceStage TraceStage { get; }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        void MessageWasSent(Guid pMessageID, long pProcessingTime);

        //////////////////////////////

        void MessageWasNotSent(Guid pMessageID);

        //////////////////////////////
    }
}