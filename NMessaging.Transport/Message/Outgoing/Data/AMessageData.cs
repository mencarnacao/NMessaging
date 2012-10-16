using System;
using NMessaging.Transport.Message.Outgoing.Data.Reporting;
using NMessaging.Transport.Message.Outgoing.Data.Trace;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public abstract class AMessageData<T> : IMessageData
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly Guid _oMessageID = default(Guid);
        private readonly short _iVersion = default(short);
        protected T _oData = default(T);
        protected TraceStage _oTraceStage = default(TraceStage);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected AMessageData(Guid pMessageID, short pVersion, T pData)
        {
            _oMessageID = pMessageID;
            _iVersion = pVersion;
            _oData = pData;
            _oTraceStage = new TraceStage(this);
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

        public object Data
        {
            get { return _oData; }
        }

        //////////////////////////////

        public TraceStage TraceStage
        {
            get { throw new NotImplementedException(); }
        }

        //////////////////////////////

        public abstract byte[] SerializedMessageContent { get; }

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