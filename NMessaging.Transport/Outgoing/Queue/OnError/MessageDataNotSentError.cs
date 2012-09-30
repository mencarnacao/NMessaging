using System;

namespace NMessaging.Transport.Outgoing.Queue.OnError
{
    public class MessageDataNotSentError
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private MessageDataNotSentErrorType _messageNotSentErrorType = default(MessageDataNotSentErrorType);
        private DateTime _oDateOperation = default(DateTime);
        private Exception _oException = default(Exception);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDataNotSentError()
        {}

        //////////////////////////////

        public MessageDataNotSentError(MessageDataNotSentErrorType pMessageNotSentErrorType, DateTime pDateOperation)
        {
            _messageNotSentErrorType = pMessageNotSentErrorType;
            _oDateOperation = pDateOperation;
        }

        //////////////////////////////

        public MessageDataNotSentError(MessageDataNotSentErrorType pMessageNotSentErrorType, DateTime pDateOperation, Exception pException)
        {
            _messageNotSentErrorType = pMessageNotSentErrorType;
            _oDateOperation = pDateOperation;
            _oException = pException;
        }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public MessageDataNotSentErrorType MessageNotSentErrorType
        {
            get { return _messageNotSentErrorType; }

            set { _messageNotSentErrorType = value; }
        }

        //////////////////////////////

        public DateTime DateOperation
        {
            get { return _oDateOperation; }

            set { _oDateOperation = value; }
        }

        //////////////////////////////

        public Exception Exception
        {
            get { return _oException; }

            set { _oException = value; }
        }

        //////////////////////////////
    }
}