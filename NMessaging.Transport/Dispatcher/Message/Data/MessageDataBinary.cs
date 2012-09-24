using System;

namespace NMessaging.Transport.Dispatcher.Message.Data
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
    }
}