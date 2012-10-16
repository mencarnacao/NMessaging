namespace NMessaging.Transport.Message.Data
{
    public interface MessageDataText : IMessageData
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        new string Data { get; }

        //////////////////////////////
    }
}