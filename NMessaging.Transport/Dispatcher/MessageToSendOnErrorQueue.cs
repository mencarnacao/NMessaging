using NMessaging.Transport.Message.Data;

namespace NMessaging.Transport.Dispatcher
{
    public class MessageToSendOnErrorQueue : MessageToSendOnQueue
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////




        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        public MessageToSendOnErrorQueue(MessageDataToSend pMessageDataToSend, MessageDataToSendSettings pMessageDataToSendSettings):base(pMessageDataToSend, pMessageDataToSendSettings)
        { }


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