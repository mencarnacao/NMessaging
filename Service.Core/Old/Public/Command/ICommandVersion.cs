using System.Collections.Generic;

namespace metitus.NMessaging.Contracts.Public.Command
{
    public interface ICommandVersion
    {
        //////////////////////////////////
        //           PROPERTIES         //
        //////////////////////////////////

        IList<IPublicCommandVersion> CommandVersions { get; }

        //////////////////////////////////
    }
}