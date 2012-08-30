namespace metitus.NMessaging.Public.Contracts.Message
{
    public interface IBusMessage
    {
        //////////////////////////////////
        //           PROPERTIES         //
        //////////////////////////////////

        IBusEnvelopeSettings BusEnvelopeSettings { get; }

        string Message { get; }

        //////////////////////////////////
    }
}