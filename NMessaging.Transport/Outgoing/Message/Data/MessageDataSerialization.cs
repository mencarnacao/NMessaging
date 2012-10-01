using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMessaging.Transport.Outgoing.Message.Data
{
    public static class MessageDataSerialization
    {
        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        public static byte[] Serialize(IMessageData pMessageData)
        {
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