using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMessaging.Transport.Outgoing.Message.Data.Serialization
{
    public static class MessageDataSerialization
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private const int MessageIDSize = 36;
        private const int VersionSize = 16;
        private const int SenderIDSize = 25;
        private const int SenderAddressSize = 23;
        private const int MessageHashSize = 10;
        private const int MessageTypeSize = 10;
        private const int DateSentSize = 19;


        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        public static byte[] Serialize(IMessageData<> pMessageData)
        {
            pMessageData.TraceStage.DateMessageSerializationStarted = DateTime.UtcNow;

            long iArraySize = MessageIDSize + VersionSize + SenderIDSize + SenderAddressSize + MessageHashSize +
                              MessageTypeSize + DateSentSize;

            byte[] oData = new byte[1];

            


            //header size       
            //MessageID         
            //Version               16
            //sender ID             25
            //sender address        23
            //message hash
            //date time sent
            //message type
            //content length
            //content


            pMessageData.TraceStage.DateMessageSerializationFinished = DateTime.UtcNow;

            return null;
        }

        //////////////////////////////

        private static byte[] SerializeContent(MessageDataBinary pMessageData)
        {
            return null;
        }

        //////////////////////////////

        private static byte[] SerializeContent(MessageDataMixed pMessageData)
        {
            return null;
        }

        //////////////////////////////

        private static byte[] SerializeContent(MessageDataText pMessageData)
        {
            return null;
        }

        //////////////////////////////
    }
}