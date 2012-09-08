using System;

namespace NMessaging.Transport.Message.Data
{
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
    }
}