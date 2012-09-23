using System;
using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Dispatcher.Queue
{
    public class MessageToSendOnQueue
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        protected readonly MessageDataToSendSettings _oMessageDataToSendSettings = default(MessageDataToSendSettings);
        protected readonly MessageDataToSend _oMessageDataToSend = default(MessageDataToSend);
        protected readonly Guid _oMessageID = default(Guid);
        protected long _iProcessingTime = default(long);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageToSendOnQueue(MessageDataToSend pMessageDataToSend, MessageDataToSendSettings pMessageDataToSendSettings)
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

        public MessageDataToSend MessageDataToSend
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