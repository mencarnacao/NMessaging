using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly Lazy<IList<Thread>> _oWorkers = new Lazy<IList<Thread>>() ;


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDispatcher(MessageDispatcherSettings pMessageDispatcherSettings)
        {
            _oMessageDispatcherSettings = pMessageDispatcherSettings;

            for (var iCoreNumber = 0; iCoreNumber < Environment.ProcessorCount; iCoreNumber++)
            {
                _oWorkers.Value.Add(new Thread(delegate() { }));
            }
        }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        public void Send(MessageDataToSend pMessageToSend, MessageDataToSendSettings pMessageDataToSendSettings)
        {
            Task.Factory.StartNew(() => MessagesToSendOnQueue.Enqueue(new MessageToSendOnQueue(pMessageToSend,
                                                                                               pMessageDataToSendSettings)));
        }

        //////////////////////////////
    }
}