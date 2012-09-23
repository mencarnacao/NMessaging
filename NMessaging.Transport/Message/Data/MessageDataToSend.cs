using System;
using NMessaging.Transport.Message.Data.Reporting;

namespace NMessaging.Transport.Message.Data
{
    public delegate void OnMessageSentDelegate(MessageDataSentReport pMessageDataSentReport);
    public delegate void OnMessageNotSentDelegate(MessageDataNotSentReport pMessageDataNotSentReport);

    public class MessageDataToSend : AMessageData
    {
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