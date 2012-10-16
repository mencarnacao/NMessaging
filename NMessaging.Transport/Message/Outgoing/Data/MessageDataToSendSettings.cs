using System.Net;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public class MessageDataToSendSettings
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private IPAddress _oIPAddress = default(IPAddress);
        private short _iNoTriesBeforeFailing = 1;
        private bool _ensureDelivery = default(bool);

        //////////////////////////////
    }
}
