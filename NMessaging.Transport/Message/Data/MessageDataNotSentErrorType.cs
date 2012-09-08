namespace NMessaging.Transport.Message.Data
{
    public enum MessageDataNotSentErrorType
    {
        ParseException = 0,
        DestinationNotAvailable = 1,
        MessageConfirmationNotReceived = 2,
        NotExpectedException = 3
    }
}
