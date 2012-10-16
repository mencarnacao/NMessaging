namespace NMessaging.Transport.Message.Data
{
    public interface IMessageData : IMessage
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        MessageContentType MessageContentType { get; }

        MessageDataType MessageDataType { get; }

        object Data { get; }

        //////////////////////////////
    }
}