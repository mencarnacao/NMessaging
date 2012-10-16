using System;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public class MessageDataText : AMessageData<string>
    {
        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected MessageDataText(Guid pMessageID, short pVersion, string pData)
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

        public override byte[] SerializedMessageContent
        {
            get { throw new NotImplementedException(); }
        }

        //////////////////////////////
    }
}