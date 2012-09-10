using System;
using NMessaging.Transport.Message.Data.Report;

namespace NMessaging.Transport.Message.Data
{
    public class MessageDataToSend : AMessageData
    {
        public delegate void OnMessageSentDelegate(MessageDataSentReportSuccess pMessageSentReportSuccess);
        public delegate void OnMessageNotSentDelegate(MessageDataSentReportFail pMessageSentReportFail);

        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDataToSend(Guid pMessageID, short pVersion)
            : base(pMessageID, pVersion)
        { }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public override MessageDataType MessageDataType
        {
            get { return MessageDataType.ToSend; }
        }

        //////////////////////////////

        private event OnMessageSentDelegate OnMessageSent;

        //////////////////////////////

        private event OnMessageNotSentDelegate OnMessageNotSent;

        //////////////////////////////
    }
}