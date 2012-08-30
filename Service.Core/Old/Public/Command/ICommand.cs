using System.Collections.Generic;

namespace metitus.NMessaging.Contracts.Public.Command
{
    public interface ICommand : IBusMessage
    {
        //////////////////////////////////
        //           PROPERTIES         //
        //////////////////////////////////

        IList<IPublicCommandVersion> CommandVersions { get; set; }

        //////////////////////////////////
    }
}