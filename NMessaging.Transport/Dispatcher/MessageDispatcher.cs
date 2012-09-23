using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NMessaging.Transport.Dispatcher.Queue;
using NMessaging.Transport.Dispatcher.Queue.OnError;
using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Dispatcher
{
    public delegate void MessageNotSentDelegate(MessageToSendOnQueue pMessageToSendOnQueue, MessageDataNotSentError pMessageDataNotSentError);
    public delegate void MessageSentDelegate(MessageToSendOnQueue pMessageToSendOnQueue);
    public delegate void MessageDispatcherWorkerIsFreeDelegate(MessageDispatcherWorker pMessageDispatcherWorker);

    public class MessageDispatcher
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private MessageDispatcherSettings _oMessageDispatcherSettings = default(MessageDispatcherSettings);
        private readonly Lazy<Queue<MessageDispatcherWorker>> _oWorkersQueue = new Lazy<Queue<MessageDispatcherWorker>>();
        private readonly Lazy<List<MessageDispatcherWorker>> _oWorkersInUseQueue = new Lazy<List<MessageDispatcherWorker>>();
        private readonly Lazy<Queue<MessageToSendOnQueue>> _oMessagesQueue = new Lazy<Queue<MessageToSendOnQueue>>();
        private readonly Lazy<Queue<MessageToSendOnQueueError>> _oMessagesQueueFailedMessages = new Lazy<Queue<MessageToSendOnQueueError>>();
        private Thread _oWorkDistributerThread = default(Thread);
        private readonly AutoResetEvent _oAutoResetEvent = new AutoResetEvent(true);
        private bool _bDoWork = true;


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDispatcher(MessageDispatcherSettings pMessageDispatcherSettings)
        {
            _oMessageDispatcherSettings = pMessageDispatcherSettings;

            for (var iCoreNumber = 0; iCoreNumber < (Environment.ProcessorCount * 2); iCoreNumber++)
            {
                _oWorkersQueue.Value.Enqueue(new MessageDispatcherWorker(this, this.MessageWasNotSent, this.MessageWasSent, WorkerIsFree));
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
            if (_bDoWork)
            {
                _oMessagesQueue.Value.Enqueue(new MessageToSendOnQueue(pMessageToSend, pMessageDataToSendSettings));
            }
        }

        //////////////////////////////

        private void DoDistributionWork()
        {
            while (_bDoWork)
            {
                var oMessageDispatcherWorker = _oWorkersQueue.Value.Dequeue();

                _oWorkersInUseQueue.Value.Add(oMessageDispatcherWorker);

                oMessageDispatcherWorker.Process(_oMessagesQueue.Value.Dequeue());
            }
        }

        //////////////////////////////

        private void MessageWasSent(MessageToSendOnQueue pMessageToSendOnQueue)
        {
            //var messageToSendOnQueueError = new MessageToSendOnQueueError(pMessageToSendOnQueue.MessageDataToSend, pMessageToSendOnQueue.MessageDataToSendSettings);

            //messageToSendOnQueueError.MessageDataSentFailures.Add(pMessageDataNotSentError);

            //_oMessagesQueueFailedMessages.Value.Enqueue(messageToSendOnQueueError);
        }

        //////////////////////////////

        private void MessageWasNotSent(MessageToSendOnQueue pMessageToSendOnQueue, MessageDataNotSentError pMessageDataNotSentError)
        {
            var messageToSendOnQueueError = new MessageToSendOnQueueError(pMessageToSendOnQueue.MessageDataToSend, pMessageToSendOnQueue.MessageDataToSendSettings);

            messageToSendOnQueueError.MessageDataSentFailures.Add(pMessageDataNotSentError);

            _oMessagesQueueFailedMessages.Value.Enqueue(messageToSendOnQueueError);
        }

        //////////////////////////////

        private void WorkerIsFree(MessageDispatcherWorker pMessageDispatcherWorker)
        {
            _oWorkersQueue.Value.Enqueue(pMessageDispatcherWorker);
        }

        //////////////////////////////

        public void StopDispatcher()
        {
            _bDoWork = false;

            while (_oWorkersQueue.Value.Count != (Environment.ProcessorCount*2))
            {
            }
        }

        //////////////////////////////
    }
}