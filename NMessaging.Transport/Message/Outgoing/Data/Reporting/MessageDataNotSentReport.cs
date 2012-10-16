using System;

namespace NMessaging.Transport.Message.Outgoing.Data.Reporting
{
    public class MessageDataNotSentReport : IMessageDataReport
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly Guid _oMessageID = default(Guid);


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public MessageDataNotSentReport(Guid pMessageID)
        {
            _oMessageID = pMessageID;
        }

        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public Guid MessageID
        {
            get { return _oMessageID; }
        }

        //////////////////////////////
    }
}