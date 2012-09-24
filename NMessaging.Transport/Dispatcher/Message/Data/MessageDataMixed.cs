using System;
using System.Collections.Generic;

namespace NMessaging.Transport.Dispatcher.Message.Data
{
    public class MessageDataMixed : AMessageData<Dictionary<string, Dictionary<string, object>>>
    {
        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected MessageDataMixed(Guid pMessageID, short pVersion, Dictionary<string, Dictionary<string, object>> pData)
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