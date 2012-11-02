using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using NMessaging.Transport.Message.Outgoing.Data;

namespace NMessaging.Transport.Message
{
    public static class MessageSerialization
    {
        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        public static byte[] Serialize(MessageDataOutgoingBinary pMessage)
        {
            return (byte[])pMessage.Data;
        }

        //////////////////////////////

        public static byte[] Serialize(MessageDataOutgoingMixed pMessage)
        {
            var oSerializedMessage = new List<byte>();

            foreach (var oDataField in pMessage.Data)
            {
                oSerializedMessage.AddRange(Encoding.ASCII.GetBytes(oDataField.Name.ToString(CultureInfo.InvariantCulture)));
                //message 
                oSerializedMessage.AddRange(Encoding.ASCII.GetBytes(oDataField.Type.ToString()));

                //oSerializedMessage.
            }


            return null;
        }

        //////////////////////////////

        private static byte[] Serialize(MessageDataOutgoingText pMessage)
        {
            var strData = (string)pMessage.Data;

            var oBytes = new byte[strData.Length * sizeof(char)];

            Buffer.BlockCopy(strData.ToCharArray(), 0, oBytes, 0, oBytes.Length);

            return oBytes;
        }

        //////////////////////////////

        private static IEnumerable<byte> CalculateMessageCrypto(byte[] pMessageContent)
        {
            var cryptography = new SHA1CryptoServiceProvider();

            return cryptography.ComputeHash(pMessageContent);
        }

        //////////////////////////////

        private static byte[] Serialize(IMessageDataOutgoing pMessage)
        {
            //if file is large than should save to disk and return a stream reader, the caller needs to have a setting to decide if, based
            //the message can be saved to ram or if it need to be saved to disk
            //validate and if not valid throw exception

            var oMessageContent = MessageSerialization.Serialize(pMessage);
            var oMessage =
                new List<byte>(MessageConstants.SizeMessageCripto + MessageConstants.SizeMessageID + MessageConstants.SizeVersion +
                               MessageConstants.SizeSenderName + MessageConstants.SizeSenderIpAddress +
                               MessageConstants.SizeMessageType + MessageConstants.SizeDateSent + MessageConstants.SizeDateSent +
                               oMessageContent.Length);

            //message size
            oMessage.AddRange(pMessage.MessageID.ToByteArray());
            oMessage.AddRange(Encoding.ASCII.GetBytes(pMessage.Version.ToString(CultureInfo.InvariantCulture)));
            oMessage.AddRange(Encoding.ASCII.GetBytes(Settings.EndPointName));
            oMessage.AddRange(Encoding.ASCII.GetBytes(Settings.EndPointIpAddress));
            oMessage.AddRange(Encoding.ASCII.GetBytes(pMessage.MessageDataType.ToString()));
            oMessage.AddRange(Encoding.ASCII.GetBytes(DateTime.UtcNow.ToString("yyyyMMddHHmmss")));
            oMessage.AddRange(oMessageContent);

            oMessage.InsertRange(0, MessageSerialization.CalculateMessageCrypto(oMessage.ToArray()));
            oMessage.InsertRange(0, Encoding.ASCII.GetBytes(oMessage.LongCount().ToString(CultureInfo.InvariantCulture)));

            return oMessage.ToArray();
        }

        //////////////////////////////
    }
}