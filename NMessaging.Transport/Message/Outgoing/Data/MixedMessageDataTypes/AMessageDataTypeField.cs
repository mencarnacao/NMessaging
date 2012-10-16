using System;

namespace NMessaging.Transport.Message.Outgoing.Data.MixedMessageDataTypes
{
    public abstract class AMessageDataTypeField<T> : IMessageDataTypeField where T : Type
    {
        //////////////////////////////
        //          MEMBERS         //
        //////////////////////////////

        private readonly T _oType = default(T);
        private readonly object _oData = default(object);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected AMessageDataTypeField(T pType, object pData)
        {
            _oType = pType;
            _oData = pData;
        }


        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public Type Type
        {
            get { return _oType; }
        }

        //////////////////////////////

        public byte[] Content
        {
            get { return MessageDataTypeFieldFactory.Serialize(_oType, _oData); }
        }

        //////////////////////////////
    }
}