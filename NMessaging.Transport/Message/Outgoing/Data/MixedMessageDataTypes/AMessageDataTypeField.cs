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
        private readonly string _strName = default(string);


        //////////////////////////////
        //        CONSTRUCTORS      //
        //////////////////////////////

        protected AMessageDataTypeField(T pType, string pName, object pData)
        {
            _strName = pName;
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

        public string Name
        {
            get { return _strName; }
        }

        //////////////////////////////
    }
}