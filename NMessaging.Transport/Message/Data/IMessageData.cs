using System;

namespace NMessaging.Transport.Message.Data
{
    public interface IMessageData
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        Guid MessageID { get; }

        MessageType MessageType { get; }

        MessageDataType MessageDataType { get; }

        long Version { get; }

        //////////////////////////////
    }
}
