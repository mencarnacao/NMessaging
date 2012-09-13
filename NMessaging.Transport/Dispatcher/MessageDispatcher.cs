using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Dispatcher
{
    public delegate void MessageNotSentDelegate(MessageDataNotSentError pMessageDataNotSentError);

    public class MessageDispatcher
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private MessageDispatcherSettings _oMessageDispatcherSettings = default(MessageDispatcherSettings);
        private readonly Lazy<Queue<MessageDispatcherWorker>> _oWorkers = new Lazy<Queue<MessageDispatcherWorker>>();
        private readonly Lazy<Queue<MessageToSendOnQueue>> _oMessagesQueue = new Lazy<Queue<MessageToSendOnQueue>>();
        private Thread _oWorkDistributerThread = default(Thread);
        private readonly AutoResetEvent _oAutoResetEvent = new AutoResetEvent(true);
        

        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDispatcher(MessageDispatcherSettings pMessageDispatcherSettings)
        {
            _oMessageDispatcherSettings = pMessageDispatcherSettings;

            for (var iCoreNumber = 0; iCoreNumber < Environment.ProcessorCount; iCoreNumber++)
            {
                _oWorkers.Value.Enqueue(new MessageDispatcherWorker(this));
            }
        }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        public void Start()
        {
            _oWorkDistributerThread = new Thread(this.DoDistributionWork);
        }

        //////////////////////////////

        public void Send(MessageDataToSend pMessageToSend, MessageDataToSendSettings pMessageDataToSendSettings)
        {
            _oMessagesQueue.Value.Enqueue(new MessageToSendOnQueue(pMessageToSend, pMessageDataToSendSettings));
        }

        //////////////////////////////

        private void DoDistributionWork()
        {
            while (true)
            {
                _oWorkers.Value.Dequeue().Process(_oMessagesQueue.Value.Dequeue());
            }
        }

        //////////////////////////////
    }
}