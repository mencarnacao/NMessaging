using System;
using System.Collections.Generic;
using NMessaging.Transport.Message.Outgoing.Data;

namespace NMessaging.Transport.Channel.Outgoing.Queue.OnError
{
    public class MessageToSendOnQueueError : MessageToSendOnQueue
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly Lazy<ICollection<MessageDataNotSentError>> _oMessageDataWasNotSent = new Lazy<ICollection<MessageDataNotSentError>>();


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageToSendOnQueueError(IMessageDataOutgoing pMessageData, MessageDataOutgoingSettings pMessageDataToSendSettings)
            : base(pMessageData, pMessageDataToSendSettings)
        { }


        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        public ICollection<MessageDataNotSentError> MessageDataSentFailures
        {
            get { return _oMessageDataWasNotSent.Value; }
        }

        //////////////////////////////
    }
}