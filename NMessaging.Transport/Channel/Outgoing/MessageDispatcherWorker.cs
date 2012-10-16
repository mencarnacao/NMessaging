using System;
using System.Diagnostics;
using System.Threading;
using NMessaging.Transport.Channel.Outgoing.Queue;
using NMessaging.Transport.Channel.Outgoing.Queue.OnError;

namespace NMessaging.Transport.Channel.Outgoing
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
        private readonly MessageSentDelegate _oMessageSentDelegate = default(MessageSentDelegate);
        private readonly MessageDispatcherWorkerIsFreeDelegate _oMessageDispatcherWorkerIsFreeDelegate = default(MessageDispatcherWorkerIsFreeDelegate);
        private bool _bDoWork = true;


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDispatcherWorker(MessageDispatcher pMessageDispatcher, MessageNotSentDelegate pMessageNotSentDelegate, MessageSentDelegate pMessageSentDelegate, MessageDispatcherWorkerIsFreeDelegate pMessageDispatcherWorkerIsFreeDelegate)
        {
            _oMessageDispatcher = pMessageDispatcher;
            _oMessageNotSentDelegate = pMessageNotSentDelegate;
            _oMessageSentDelegate = pMessageSentDelegate;
            _oMessageDispatcherWorkerIsFreeDelegate = pMessageDispatcherWorkerIsFreeDelegate;
        }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        private void DoWork()
        {
            while (_bDoWork)
            {
                _oAutoResetEvent.WaitOne();

                var oStopwatch = new Stopwatch();

                oStopwatch.Start();

                if (_oMessageToProcess != null)
                {
                    try
                    {
                        if (this.ValidateMessage())
                        {
                            if (this.SerializeMessage())
                            {
                                this.SendMessage();

                                oStopwatch.Stop();

                                _oMessageToProcess.ProcessingTime = oStopwatch.ElapsedMilliseconds;

                                _oMessageSentDelegate(_oMessageToProcess);
                            }
                        }
                    }
                    //catch (NetworkException exception)
                    //{
                    //    _oMessageNotSentDelegate(_oMessageToProcess,
                    //                             new MessageDataNotSentError(
                    //                                 MessageDataNotSentErrorType.DestinationNotAvailable, DateTime.Now,
                    //                                 exception));
                    //}
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

            pMessageToSendOnQueue.MessageData.TraceStage.DateProcessingStarted = DateTime.UtcNow;

            _oAutoResetEvent.Set();
        }

        //////////////////////////////

        private void SendMessage()
        {
            
        }

        //////////////////////////////

        public void StopWorker()
        {
            _bDoWork = false;
        }

        //////////////////////////////
    }
}