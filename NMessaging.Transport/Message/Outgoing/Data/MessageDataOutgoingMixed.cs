using System;
using System.Collections.Generic;
using NMessaging.Transport.Message.Data;
using NMessaging.Transport.Message.Outgoing.Data.MixedMessageDataTypes;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public class MessageDataOutgoingMixed : AMessageDataOutgoing<List<IMessageDataTypeField>>, MessageDataMixed
    {
        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected MessageDataOutgoingMixed(Guid pMessageID, short pVersion, List<IMessageDataTypeField> pData)
            : base(pMessageID, pVersion, pData)
        { }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public override MessageDataType MessageDataType
        {
            get { return MessageDataType.Text; }
        }

        //////////////////////////////

        public new List<IMessageDataTypeField> Data
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