using System;

namespace NMessaging.Transport.Message.Outgoing.Data.Reporting
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