using System;
using System.Collections.Concurrent;
using System.Threading;
using NMessaging.Transport.Dispatcher.Queue;
using NMessaging.Transport.Dispatcher.Queue.OnError;
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
        private readonly MessageNotSentDelegate _oMessageNotSentDelegate = default(MessageNotSentDelegate);


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

                if (_oMessageToProcess != null)
                {
                    try
                    {
                        if (this.ValidateMessage())
                        {
                            if (this.SerializeMessage())
                            {

                            }
                        }



                    }
                    catch (Exception exception)
                    {
                        _oMessageNotSentDelegate(_oMessageToProcess,
                                                 new MessageDataNotSentError(
                                                     MessageDataNotSentErrorType.NotExpectedException, DateTime.Now,
                                                     exception));
                    }
                }

                _oMessageToProcess = default(MessageToSendOnQueue);
            }
        }

        //////////////////////////////

        private bool ValidateMessage()
        {
            bool bValid = true;

            _oMessageNotSentDelegate(_oMessageToProcess, new MessageDataNotSentError(MessageDataNotSentErrorType.ParseException, DateTime.Now));

            return bValid;
        }

        //////////////////////////////

        private bool SerializeMessage()
        {
            bool bValid = true;

            _oMessageNotSentDelegate(_oMessageToProcess, new MessageDataNotSentError(MessageDataNotSentErrorType.SerializationError, DateTime.Now));

            return bValid;
        }

        //////////////////////////////

        public void Process(MessageToSendOnQueue pMessageToSendOnQueue)
        {
            _oMessageToProcess = pMessageToSendOnQueue;

            _oMessageNotSentDelegate(_oMessageToProcess, new MessageDataNotSentError(MessageDataNotSentErrorType.DestinationNotAvailable, DateTime.Now));

            _oAutoResetEvent.Set();
        }

        //////////////////////////////
    }
}