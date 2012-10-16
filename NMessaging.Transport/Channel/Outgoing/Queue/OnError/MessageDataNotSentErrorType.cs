namespace NMessaging.Transport.Channel.Outgoing.Queue.OnError
{
    public enum MessageDataNotSentErrorType
    {
        ParseException = 0,
        DestinationNotAvailable = 1,
        MessageConfirmationNotReceived = 2,
        SerializationError = 3,
        NotExpectedException = 4
    }
}
