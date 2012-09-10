using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Dispatcher
{
    public class MessageToSendOnQueue
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly MessageDataToSendSettings _oMessageDataToSendSettings = default(MessageDataToSendSettings);
        private readonly MessageDataToSend _oMessageDataToSend = default(MessageDataToSend);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        private MessageToSendOnQueue()
        { }

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