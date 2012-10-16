using System;

namespace NMessaging.Transport.Message.Outgoing.Data.Trace
{
    public class TraceStage
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly IMessageDataOutgoing _oMessage = default(IMessageDataOutgoing);
        private DateTime _oDateProcessingStarted = default(DateTime);
        private DateTime _oDateMessageSerializationStarted = default(DateTime);
        private DateTime _oDateMessageSerializationFinished = default(DateTime);


        //////////////////////////////
        //       CONSTRUCTORS       //
        //////////////////////////////
        
        public TraceStage(IMessageDataOutgoing pMessageData)
        {
            _oMessage = pMessageData;
        }


        //////////////////////////////
        //        PROPERTIES        //
        //////////////////////////////

        public IMessageDataOutgoing MessageData
        {
            get { return _oMessage; }
        }

        //////////////////////////////

        public DateTime DateProcessingStarted
        {
            get { return _oDateProcessingStarted; }
            set { _oDateProcessingStarted = value; }
        }

        //////////////////////////////

        public DateTime DateMessageSerializationStarted
        {
            get { return _oDateMessageSerializationStarted; }
            set { _oDateMessageSerializationStarted = value; }
        }

        //////////////////////////////

        public DateTime DateMessageSerializationFinished
        {
            get { return _oDateMessageSerializationFinished; }
            set { _oDateMessageSerializationFinished = value; }
        }

        //////////////////////////////
    }
}
