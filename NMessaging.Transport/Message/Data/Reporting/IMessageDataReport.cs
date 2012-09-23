using System;

namespace NMessaging.Transport.Message.Data.Reporting
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