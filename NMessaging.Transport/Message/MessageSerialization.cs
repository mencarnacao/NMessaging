using System;
using System.Collections.Generic;
using NMessaging.Transport.Message.Outgoing.Data;

namespace NMessaging.Transport.Message
{
    public static class MessageSerialization
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        const int MessageIDSize = 36;
        const int VersionSize = 16;
        const int SenderIDSize = 25;
        const int SenderAddressSize = 23;
        const int MessageHashSize = 10;
        const int MessageTypeSize = 10;
        const int DateSentSize = 19;


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        public static byte[] Serialize(MessageDataBinary pMessage)
        {
            return (byte[])pMessage.Data;
        }

        //////////////////////////////

        public static byte[] Serialize(MessageDataMixed pMessage)
        {
            var oData = (Dictionary<Type, Dictionary<string, object>>) pMessage.Data;

            foreach (var oItem in oData)
            {
                if(oItem.Key == typeof(int))
                {

                }
                else if (oItem.Key == typeof(string))
                {

                }
                else if (oItem.Key == typeof(bool))
                {

                }
            }



            return null;
        }

        //////////////////////////////

        public static byte[] Serialize(MessageDataText pMessage)
        {
            var strData = (string) pMessage.Data;

            var oBytes = new byte[strData.Length * sizeof(char)];

            Buffer.BlockCopy(strData.ToCharArray(), 0, oBytes, 0, oBytes.Length);

            return oBytes;
        }

        //////////////////////////////
    }
}
