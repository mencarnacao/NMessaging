using System;

namespace NMessaging.Transport.Message
{
    public interface IMessage
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        Guid MessageID { get; }

        MessageOnTransportType MessageOnTransportType { get; }

        long Version { get; }

        //////////////////////////////
    }
}