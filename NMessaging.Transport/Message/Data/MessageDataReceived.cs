using System;

namespace NMessaging.Transport.Message.Data
{
    public class MessageDataReceived : AMessageData
    {
        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDataReceived(Guid pMessageID, short pVersion)
            : base(pMessageID, pVersion)
        { }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public override MessageDataType MessageDataType
        {
            get { return MessageDataType.Received; }
        }

        //////////////////////////////
    }
}