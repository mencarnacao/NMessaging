using System;
using System.Collections.Generic;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public class MessageDataMixed : AMessageData<Dictionary<Type, Dictionary<string, object>>>
    {
        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected MessageDataMixed(Guid pMessageID, short pVersion, Dictionary<Type, Dictionary<string, object>> pData)
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
            get
            {
                throw new NotImplementedException();
            }
        }

        //////////////////////////////
    }
}