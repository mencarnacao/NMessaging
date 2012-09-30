using System;
using NMessaging.Transport.Message;
using NMessaging.Transport.Outgoing.Message.Data.Reporting;

namespace NMessaging.Transport.Outgoing.Message.Data
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

        public MessageContentType MessageContentType
        {
            get { return MessageContentType.Data; }
        }

        //////////////////////////////

        public abstract MessageDataType MessageDataType { get; }

        //////////////////////////////

        public Guid MessageID
        {
            get { return _oMessageID; }
        }

        //////////////////////////////

        public MessageOnTransportType MessageOnTransportType
        {
            get { return MessageOnTransportType.Outgoing; }
        }

        //////////////////////////////

        public long Version
        {
            get { return _iVersion; }
        }

        //////////////////////////////

        public T Data
        {
            get { return _oData; }
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