using System;
using NMessaging.Transport.Message.Outgoing.Data;

namespace NMessaging.Transport.Channel.Outgoing.Queue
{
    public class MessageToSendOnQueue
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        protected readonly MessageDataToSendSettings _oMessageDataToSendSettings = default(MessageDataToSendSettings);
        protected readonly IMessageDataOutgoing _oMessageDataToSend = default(IMessageDataOutgoing);
        protected readonly Guid _oMessageID = default(Guid);
        protected long _iProcessingTime = default(long);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageToSendOnQueue(IMessageDataOutgoing pMessageDataToSend, MessageDataToSendSettings pMessageDataToSendSettings)
        {
            _oMessageDataToSend = pMessageDataToSend;
            _oMessageDataToSendSettings = pMessageDataToSendSettings;
            _oMessageID = Guid.NewGuid();
        }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public MessageDataToSendSettings MessageDataToSendSettings
        {
            get { return _oMessageDataToSendSettings; }
        }

        //////////////////////////////

        public IMessageDataOutgoing MessageData
        {
            get { return _oMessageDataToSend; }
        }

        //////////////////////////////

        public Guid MessageID
        {
            get { return _oMessageID; }
        }

        //////////////////////////////

        public long ProcessingTime
        {
            get { return _iProcessingTime; }

            set { _iProcessingTime = value; }
        }

        //////////////////////////////
    }
}