using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metitus.NMessaging.Contracts
{
    public enum BusMessageAcknowledge
    {
        None = 0,
        Delivered = 1,
        DeliveredAndChecke = 3,
        Synchronized = 4
    }
}