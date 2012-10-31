using System.Net;

namespace NMessaging.Transport.Message.Outgoing.Data
{
    public class MessageDataOutgoingSettings
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private IPAddress _oIPAddress = default(IPAddress);
        private int _iPort = default(int);
        private short _iNoTriesBeforeFailing = 1;
        private bool _ensureDelivery = default(bool);

        //////////////////////////////
    }
}
