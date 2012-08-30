using System;
using metitus.NMessaging.Public.Contracts.Message.Command;

namespace metitus.NMessaging.Public.Contracts.Message
{
    public interface IBusEnvelopeSettings
    {
        //////////////////////////////////
        //          PROPERTIES          //
        //////////////////////////////////

        CommandDeliveryAcknowledge CommandDeliveryAcknowledge { set; }

        Action<IBusMessageDelivery> BusMessageDelivery { set; }

        //////////////////////////////////
    }
}