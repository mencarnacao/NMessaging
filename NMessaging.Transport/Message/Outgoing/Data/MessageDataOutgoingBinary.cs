using System;
using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public class MessageDataOutgoingBinary : AMessageDataOutgoing<byte[]>, IMessageDataBinary
    {
        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected MessageDataOutgoingBinary(Guid pMessageID, short pVersion, byte[] pData)
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

        public new byte[] Data
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