using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using NMessaging.Transport.Message.Outgoing.Data;

namespace NMessaging.Transport.Message.Outgoing
{
    public static class MessageSerialization
    {
        //////////////////////////////
        //          METHODS         //
        //////////////////////////////

        public static byte[] Serialize(MessageDataOutgoingBinary pMessage)
        {
            var oMessage = GenerateMessageHeader(pMessage, pMessage.Data);

            return oMessage.ToArray();
        }

        //////////////////////////////

        public static byte[] Serialize(MessageDataOutgoingMixed pMessage)
        {
            var oSerializedMessage = new List<byte>();

            foreach (var oDataField in pMessage.Data)
            {
                oSerializedMessage.AddRange(Encoding.ASCII.GetBytes(oDataField.Name.ToString(CultureInfo.InvariantCulture)));
                oSerializedMessage.AddRange(MessageConstants.Structure.MessageMixedKeyValueSeparator);
                oSerializedMessage.AddRange(Encoding.ASCII.GetBytes(oDataField.Type.ToString()));
                oSerializedMessage.AddRange(MessageConstants.Structure.MessageMixedRecordSeparator);
            }

            var oMessage = GenerateMessageHeader(pMessage, oSerializedMessage.ToArray());

            return oMessage.ToArray();
        }

        //////////////////////////////

        private static byte[] Serialize(MessageDataOutgoingText pMessage)
        {
            var strData = (string)pMessage.Data;
            var oBytes = new byte[strData.Length * sizeof(char)];

            Buffer.BlockCopy(strData.ToCharArray(), 0, oBytes, 0, oBytes.Length);

            var oMessage = GenerateMessageHeader(pMessage, oBytes);

            return oMessage.ToArray();
        }

        //////////////////////////////

        private static IEnumerable<byte> GenerateMessageCrypto(byte[] pMessageContent)
        {
            var cryptography = new SHA1CryptoServiceProvider();

            return cryptography.ComputeHash(pMessageContent);
        }

        //////////////////////////////

        private static List<byte> GenerateMessageHeader(IMessageDataOutgoing pMessage, byte[] pMessageContent)
        {
            const int iMessageSize = MessageConstants.Size.MessageId + MessageConstants.Size.Version +
                                     MessageConstants.Size.EndPointName + MessageConstants.Size.EndPointIpAddress +
                                     MessageConstants.Size.DateSent + MessageConstants.Size.MessageDataType +
                                     MessageConstants.Size.MessageContentType + MessageConstants.Size.MessageHeaderCripto;

            var oHeader = new List<byte>(iMessageSize);

            oHeader.AddRange(pMessage.MessageID.ToByteArray());
            oHeader.AddRange(Encoding.ASCII.GetBytes(pMessage.Version.ToString(CultureInfo.InvariantCulture)));
            oHeader.AddRange(Encoding.ASCII.GetBytes(Settings.EndPointName));
            oHeader.AddRange(Encoding.ASCII.GetBytes(Settings.EndPointIpAddress));
            oHeader.AddRange(Encoding.ASCII.GetBytes(DateTime.UtcNow.ToString("yyyyMMddHHmmss")));
            oHeader.AddRange(Encoding.ASCII.GetBytes(pMessage.MessageDataType.ToString()));
            oHeader.AddRange(Encoding.ASCII.GetBytes(pMessage.MessageContentType.ToString()));
            oHeader.AddRange(GenerateMessageCrypto(pMessageContent));

            return oHeader;
        }

        //////////////////////////////
    }
}