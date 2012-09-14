using System;
using System.Collections.Generic;
using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Dispatcher.Queue.OnError
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

        public MessageToSendOnQueueError(MessageDataToSend pMessageDataToSend, MessageDataToSendSettings pMessageDataToSendSettings)
            : base(pMessageDataToSend, pMessageDataToSendSettings)
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