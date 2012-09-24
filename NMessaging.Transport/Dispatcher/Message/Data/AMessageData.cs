using System;
using NMessaging.Transport.Dispatcher.Message.Data.Reporting;

namespace NMessaging.Transport.Dispatcher.Message.Data
{
    public abstract class AMessageData<T> : IMessageData
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly Guid _oMessageID = default(Guid);
        private readonly short _iVersion = default(short);
        protected T _oData = default(T);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected AMessageData(Guid pMessageID, short pVersion, T pData)
        {
            _oMessageID = pMessageID;
            _iVersion = pVersion;
            _oData = pData;
        }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public MessageType MessageType
        {
            get { return MessageType.Data; }
        }

        //////////////////////////////

        public abstract MessageDataType MessageDataType { get; }

        //////////////////////////////

        public Guid MessageID
        {
            get { return _oMessageID; }
        }

        //////////////////////////////

        public long Version
        {
            get { return _iVersion; }
        }

        //////////////////////////////

        public T Data
        {
            get { return _iVersion; }
        }

        //////////////////////////////

        public event OnMessageSentDelegate OnMessageSent;

        //////////////////////////////

        public event OnMessageNotSentDelegate OnMessageNotSent;


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        public void MessageWasSent(Guid pMessageID, long pProcessingTime)
        {
            this.OnMessageSent(new MessageDataSentReport(pMessageID, pProcessingTime));
        }

        //////////////////////////////

        public void MessageWasNotSent(Guid pMessageID)
        {
            OnMessageNotSent(new MessageDataNotSentReport(pMessageID));
        }

        //////////////////////////////
    }
}