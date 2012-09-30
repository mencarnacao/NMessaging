using System;

namespace NMessaging.Transport.Outgoing.Message.Data.Reporting
{
    public interface IMessageDataReport
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        Guid MessageID { get; }

        //////////////////////////////
    }
}