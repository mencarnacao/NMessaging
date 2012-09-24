using System;

namespace NMessaging.Transport.Dispatcher.Message.Data
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
    }
}