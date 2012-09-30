using System;
using NMessaging.Transport.Outgoing.Message.Data;

namespace NMessaging.Transport.Outgoing.Queue
{
    public class MessageToSendOnQueue
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        protected readonly MessageDataToSendSettings _oMessageDataToSendSettings = default(MessageDataToSendSettings);
        protected readonly IMessageData _oMessageDataToSend = default(IMessageData);
        protected readonly Guid _oMessageID = default(Guid);
        protected long _iProcessingTime = default(long);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageToSendOnQueue(IMessageData pMessageDataToSend, MessageDataToSendSettings pMessageDataToSendSettings)
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

        public IMessageData MessageData
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