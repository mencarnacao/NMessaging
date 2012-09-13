using System;
using System.Collections.Generic;

namespace NMessaging.Transport.Message.Data
{
    public class MessageDataToSendOnTry
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly Lazy<ICollection<MessageDataNotSentError>> _oMessageNotSentErrors = new Lazy<ICollection<MessageDataNotSentError>>();
        private MessageDataToSend _oMessageDataToSend = default(MessageDataToSend);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageDataToSendOnTry(MessageDataToSend pMessageDataToSend)
        {
            _oMessageDataToSend = pMessageDataToSend;
        }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public ICollection<MessageDataNotSentError> MessageNotSentErrors
        {
            get
            {
                return new List<MessageDataNotSentError>(_oMessageNotSentErrors.Value);
            }
        }


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        public void Add(MessageDataNotSentError pMessageNotSentError)
        {
            _oMessageNotSentErrors.Value.Add(pMessageNotSentError);
        }

        //////////////////////////////
    }
}