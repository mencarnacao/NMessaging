using System;

namespace NMessaging.Transport.Message.Data
{
    public class MessageDataNotSentError
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private MessageDataNotSentErrorType _messageNotSentErrorType = default(MessageDataNotSentErrorType);
        private DateTime _oDateOperation = default(DateTime);
        private MessageDataToSend _oMessageDataToSend = default(MessageDataToSend);
        private Exception _oException = default(Exception);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDataNotSentError()
        {}

        //////////////////////////////

        public MessageDataNotSentError(MessageDataNotSentErrorType pMessageNotSentErrorType, DateTime pDateOperation, MessageDataToSend pMessageDataToSend)
        {
            _messageNotSentErrorType = pMessageNotSentErrorType;
            _oDateOperation = pDateOperation;
            _oMessageDataToSend = pMessageDataToSend;
        }

        //////////////////////////////

        public MessageDataNotSentError(MessageDataNotSentErrorType pMessageNotSentErrorType, DateTime pDateOperation, MessageDataToSend pMessageDataToSend, Exception pException)
        {
            _messageNotSentErrorType = pMessageNotSentErrorType;
            _oDateOperation = pDateOperation;
            _oMessageDataToSend = pMessageDataToSend;
            _oException = pException;
        }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        private MessageDataNotSentErrorType MessageNotSentErrorType
        {
            get { return _messageNotSentErrorType; }

            set { _messageNotSentErrorType = value; }
        }

        //////////////////////////////

        private DateTime DateOperation
        {
            get { return _oDateOperation; }

            set { _oDateOperation = value; }
        }

        //////////////////////////////

        private MessageDataToSend MessageDataToSend
        {
            get { return _oMessageDataToSend; }

            set { _oMessageDataToSend = value; }
        }

        //////////////////////////////

        private Exception Exception
        {
            get { return _oException; }

            set { _oException = value; }
        }

        //////////////////////////////
    }
}