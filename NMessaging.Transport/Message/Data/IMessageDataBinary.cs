namespace NMessaging.Transport.Message.Data
{
    public interface IMessageDataBinary : IMessageData
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        new byte[] Data { get; }

        //////////////////////////////
    }
}