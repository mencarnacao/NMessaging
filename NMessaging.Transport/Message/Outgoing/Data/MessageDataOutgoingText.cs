using System;
using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public class MessageDataOutgoingText : AMessageDataOutgoing<string>, IMessageDataText
    {
        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected MessageDataOutgoingText(Guid pMessageID, short pVersion, string pData)
            : base(pMessageID, pVersion, pData)
        { }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public override MessageDataType MessageDataType
        {
            get { return MessageDataType.Text;}
        }

        //////////////////////////////

        public new string Data
        {
            get { throw new NotImplementedException(); }
        }

        //////////////////////////////

        public override byte[] SerializedMessageContent
        {
            get { throw new NotImplementedException(); }
        }

        //////////////////////////////
    }
}