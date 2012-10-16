using System;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public class MessageDataBinary : AMessageData<byte[]>
    {
        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected MessageDataBinary(Guid pMessageID, short pVersion, byte[] pData)
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