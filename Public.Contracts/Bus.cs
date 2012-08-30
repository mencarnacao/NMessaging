using metitus.NMessaging.Public.Contracts.Message.Event;
using metitus.NMessaging.Public.Contracts.Message.Command;

namespace metitus.NMessaging.Public.Contracts
{
    public interface IBus
    {
        //////////////////////////////////
        //           METHODS            //
        //////////////////////////////////

        void Publish(IBusEvent pBusEvent);

        void Send(ICommand pCommand);

        //////////////////////////////////
    }
}