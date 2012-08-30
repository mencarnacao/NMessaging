namespace metitus.NMessaging.Public.Contracts.Message.Command
{
    public interface ICommandVersion<T> where T : ICommand
    {
        //////////////////////////////////
        //          PROPERTIES          //
        //////////////////////////////////

        string Message { get; }

        //////////////////////////////////
    }
}