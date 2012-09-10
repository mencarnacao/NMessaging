using System.Collections.Concurrent;
using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Dispatcher
{
    public class MessageDispatcher
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private static ConcurrentQueue<MessageToSendOnQueue> MessagesToSendOnQueue = default(ConcurrentQueue<MessageToSendOnQueue>);
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

        public void Send(MessageDataToSend pMessageToSend, MessageDataToSendSettings pMessageDataToSendSettings)
        {
            MessagesToSendOnQueue.Enqueue(new MessageToSendOnQueue(pMessageToSend, pMessageDataToSendSettings));
        }

        //////////////////////////////
    }
}