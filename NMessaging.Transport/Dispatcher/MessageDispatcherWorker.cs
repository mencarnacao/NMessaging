using System;
using System.Collections.Concurrent;
using System.Threading;
using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Dispatcher
{
    public class MessageDispatcherWorker
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private MessageDispatcher _oMessageDispatcher = default(MessageDispatcher);
        private MessageToSendOnQueue _oMessageToProcess = default(MessageToSendOnQueue);
        private readonly AutoResetEvent _oAutoResetEvent = new AutoResetEvent(true);
        private MessageNotSentDelegate _oMessageNotSentDelegate = default(MessageNotSentDelegate);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDispatcherWorker(MessageDispatcher pMessageDispatcher, MessageNotSentDelegate pMessageNotSentDelegate)
        {
            _oMessageDispatcher = pMessageDispatcher;
            _oMessageNotSentDelegate = pMessageNotSentDelegate;
        }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        private void DoWork()
        {
            while (true)
            {
                _oAutoResetEvent.WaitOne();

                try
                {





                }
                catch (Exception exception)
                {
                    _oMessageNotSentDelegate(
                        new MessageDataNotSentError(MessageDataNotSentErrorType.NotExpectedException, DateTime.Now, _oMessageToProcess, exception));
                }

                _oMessageToProcess = default(MessageToSendOnQueue);
            }
        }

        //////////////////////////////

        public void Process(MessageToSendOnQueue pMessageToSendOnQueue)
        {
            _oMessageToProcess = pMessageToSendOnQueue;

            _oAutoResetEvent.Set();
        }

        //////////////////////////////
    }
}