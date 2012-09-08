using NMessaging.Transport.Message.Data;
using NMessaging.Transport.Message.Data.Report;

namespace NMessaging.Transport.Dispatcher
{
    public class MessageDispatcher
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private MessageDispatcherSettings _oMessageDispatcherSettings = default(MessageDispatcherSettings);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDispatcher(MessageDispatcherSettings pMessageDispatcherSettings)
        {
            _oMessageDispatcherSettings = pMessageDispatcherSettings;
        }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        public MessageDataSentReportFail Send(MessageDataToSend pMessageToSend, MessageDataToSendSettings pMessageDataToSendSettings)
        {
            return null;
        }

        //////////////////////////////

        public void SendAsync(MessageDataToSend pMessageToSend)
        {

        }

        //////////////////////////////
    }
}