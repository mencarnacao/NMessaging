using System;

namespace NMessaging.Transport.Message.Data
{
    public abstract class AMessageData : IMessageData
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly Guid _oMessageID = default(Guid);
        private readonly short _iVersion = default(short);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected AMessageData(Guid pMessageID, short pVersion)
        {
            this._oMessageID = pMessageID;
            this._iVersion = pVersion;
        }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public MessageType MessageType
        {
            get { return MessageType.Data; }
        }

        //////////////////////////////

        public abstract MessageDataType MessageDataType { get; }

        //////////////////////////////

        public Guid MessageID
        {
            get { return _oMessageID; }
        }

        //////////////////////////////

        public long Version
        {
            get { return _iVersion; }
        }

        //////////////////////////////
    }
}