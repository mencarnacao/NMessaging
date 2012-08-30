using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metitus.NMessaging.Contracts
{
    public interface IBusMessage
    {
        //////////////////////////////////
        //           PROPERTIES         //
        //////////////////////////////////

        IBusMessageVersion BusMessageVersion { get; set; }

        //////////////////////////////////
    }
}