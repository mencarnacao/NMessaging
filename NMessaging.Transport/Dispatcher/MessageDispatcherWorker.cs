﻿using System;
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

                if (_oMessageToProcess != null)
                {
                    try
                    {
                        if (this.ValidateMessage())
                        {
                            if (this.SerializeMessage())
                            {
                                this.SendMessage();
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

        private void SendMessage()
        {
            _oMessageSentDelegate(_oMessageToProcess);
        }

        //////////////////////////////

        public void StopWorker()
        {
            _bDoWork = false;
        }

        //////////////////////////////
    }
}