﻿using System;
using System.Collections.Generic;
using NMessaging.Transport.Outgoing.Message.Data;

namespace NMessaging.Transport.Outgoing.Queue.OnError
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

        public MessageToSendOnQueueError(IMessageData pMessageData, MessageDataToSendSettings pMessageDataToSendSettings)
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