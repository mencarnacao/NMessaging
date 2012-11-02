using System.Collections.Generic;
using NMessaging.Transport.Message.Outgoing.Data.MixedMessageDataTypes;

namespace NMessaging.Transport.Message.Data
{
    public interface IMessageDataMixed : IMessageData
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        new List<IMessageDataTypeField> Data { get; }

        //////////////////////////////
    }
}