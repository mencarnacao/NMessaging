namespace NMessaging.Transport.Message.Data
{
    public interface IMessageDataText : IMessageData
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        new string Data { get; }

        //////////////////////////////
    }
}