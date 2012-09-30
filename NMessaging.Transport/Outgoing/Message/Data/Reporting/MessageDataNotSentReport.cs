using System;

namespace NMessaging.Transport.Outgoing.Message.Data.Reporting
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