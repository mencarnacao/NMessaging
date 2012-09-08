using System.Net;

namespace NMessaging.Transport.Message.Data
{
    public class MessageDataToSendSettings
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private IPAddress _oIPAddress = default(IPAddress);
        private short _iNoTriesBeforeFailing = 1;

        //////////////////////////////
    }
}
