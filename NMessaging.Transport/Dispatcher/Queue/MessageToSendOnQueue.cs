using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Dispatcher.Queue
{
    public class MessageToSendOnQueue
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        protected readonly MessageDataToSendSettings _oMessageDataToSendSettings = default(MessageDataToSendSettings);
        protected readonly MessageDataToSend _oMessageDataToSend = default(MessageDataToSend);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageToSendOnQueue(MessageDataToSend pMessageDataToSend, MessageDataToSendSettings pMessageDataToSendSettings)
        {
            _oMessageDataToSend = pMessageDataToSend;
            _oMessageDataToSendSettings = pMessageDataToSendSettings;
        }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public MessageDataToSendSettings MessageDataToSendSettings
        {
            get { return _oMessageDataToSendSettings; }
        }

        //////////////////////////////

        public MessageDataToSend MessageDataToSend
        {
            get { return _oMessageDataToSend; }
        }

        //////////////////////////////
    }
}