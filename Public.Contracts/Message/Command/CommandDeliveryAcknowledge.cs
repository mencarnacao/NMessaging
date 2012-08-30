namespace metitus.NMessaging.Public.Contracts.Message.Command
{
    public enum CommandDeliveryAcknowledge
    {
        None = 0,
        Delivered = 1,
        DeliveredAndChecked = 3,
        Synchronized = 4,
        Asynchronous = 5
    }
}