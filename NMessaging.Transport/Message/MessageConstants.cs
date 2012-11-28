namespace NMessaging.Transport.Message
{
    public static class MessageConstants
    {
        public static class Size
        {
            //////////////////////////////
            //          MEMBERS         //
            //////////////////////////////

            public const int MessageId = 36;
            public const int Version = 16;
            public const int EndPointName = 36;
            public const int EndPointIpAddress = 23;
            public const int DateSent = 14;
            public const int MessageDataType = 10;
            public const int MessageContentType = 10;
            public const int MessageHeaderCripto = 20;

            //////////////////////////////
        }

        public static class Structure
        {
            //////////////////////////////
            //          MEMBERS         //
            //////////////////////////////

            public static byte[] MessageMixedKeyValueSeparator = new byte[4] {30, 31, 30, 31};
            public static byte[] MessageMixedRecordSeparator = new byte[4] { 30, 31, 30, 31 };

            //////////////////////////////
        }
    }
}