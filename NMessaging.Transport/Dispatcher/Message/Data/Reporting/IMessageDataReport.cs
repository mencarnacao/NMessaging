using System;

namespace NMessaging.Transport.Dispatcher.Message.Data.Reporting
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