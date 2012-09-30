using System;

namespace NMessaging.Transport.Outgoing.Message.Data.Reporting
{
    public class MessageDataSentReport : IMessageDataReport
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly Guid _oMessageID = default(Guid);
        private readonly long _iProcessingTime = default(long);


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public MessageDataSentReport(Guid pMessageID, long pProcessingTime)
        {
            _oMessageID = pMessageID;
            _iProcessingTime = pProcessingTime;
        }

        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public Guid MessageID
        {
            get { return _oMessageID; }
        }

        //////////////////////////////

        public long ProcessingTime
        {
            get { return _iProcessingTime; }
        }

        //////////////////////////////
    }
}