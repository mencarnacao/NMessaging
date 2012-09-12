using System;
using System.Collections.Concurrent;
using System.Threading;

namespace NMessaging.Transport.Dispatcher
{
    public class MessageDispatcherWorker
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly ConcurrentQueue<MessageToSendOnQueue> _oMessagesToSendOnQueue = default(ConcurrentQueue<MessageToSendOnQueue>);
        private MessageDispatcher _oMessageDispatcher = default(MessageDispatcher);
        private readonly AutoResetEvent _oAutoResetEvent = new AutoResetEvent(true);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDispatcherWorker(MessageDispatcher pMessageDispatcher, ConcurrentQueue<MessageToSendOnQueue> pMessageToSendOnQueues)
        {
            _oMessageDispatcher = pMessageDispatcher;
            _oMessagesToSendOnQueue = pMessageToSendOnQueues;
        }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        private void DoWork()
        {
            while (true)
            {
                try
                {
                    MessageToSendOnQueue oMessageToSendOnQueue = null;

                    while (true)
                    {
                        _oMessagesToSendOnQueue.TryDequeue(out oMessageToSendOnQueue);

                        if (oMessageToSendOnQueue != null)
                        {
                            break;
                        }

                        _oAutoResetEvent.WaitOne();
                    }

                    this.SendMessage(oMessageToSendOnQueue);
                }
                catch (Exception)
                {
                    //Restart the thread?
                }
            }
        }

        //////////////////////////////

        public void NotifyOfNewMessageOnQueue()
        {
            _oAutoResetEvent.Set();
        }

        //////////////////////////////

        private void SendMessage(MessageToSendOnQueue pMessageToSendOnQueue)
        {

        }

        //////////////////////////////
    }
}