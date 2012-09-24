namespace NMessaging.Transport.Dispatcher
{
    public class MessageDispatcherSettings
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly string _strEndpointName = default(string);
        private readonly long _iMessageTimeout = default(long);
        private readonly bool _bUseSecureTransport = false;
        //When subscribing to event, first make a TCP SSL connection and share the public key, then revert to normal TCP less overhead

        //////////////////////////////
        //       CONSTRUCTORS       //
        //////////////////////////////

        public MessageDispatcherSettings(string pEndpointName, long pMessageTimeout, bool pSecureTransport)
        {
            _strEndpointName = pEndpointName;
            _iMessageTimeout = pMessageTimeout;
            _bUseSecureTransport = pSecureTransport;
        }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public string EndpointName
        {
            get { return _strEndpointName; }
        }

        //////////////////////////////

        public long MessageTimeOut
        {
            get { return _iMessageTimeout; }
        }

        //////////////////////////////

        public bool UseSecureTransport
        {
            get { return _bUseSecureTransport; }
        }

        //////////////////////////////
    }
}
