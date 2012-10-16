using System;

namespace NMessaging.Transport.Message.Outgoing.Data.MixedMessageDataTypes
{
    public interface IMessageDataTypeField
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        Type Type { get; }

        //////////////////////////////

        byte[] Content { get; }

        //////////////////////////////
    }
}