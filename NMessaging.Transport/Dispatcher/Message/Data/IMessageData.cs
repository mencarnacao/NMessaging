using System;

using NMessaging.Transport.Dispatcher.Message.Data.Reporting;

namespace NMessaging.Transport.Dispatcher.Message.Data
{
    public delegate void OnMessageSentDelegate(MessageDataSentReport pMessageDataSentReport);
    public delegate void OnMessageNotSentDelegate(MessageDataNotSentReport pMessageDataNotSentReport);

    public interface IMessageData
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        Guid MessageID { get; }

        MessageType MessageType { get; }

        MessageDataType MessageDataType { get; }

        long Version { get; }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        void MessageWasSent(Guid pMessageID, long pProcessingTime);

        //////////////////////////////

        void MessageWasNotSent(Guid pMessageID);

        //////////////////////////////
    }
}