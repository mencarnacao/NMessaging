using System;

namespace metitus.NMessaging.Contracts.Public.Command
{
    [System.AttributeUsage(System.AttributeTargets.Method | System.AttributeTargets.Class, AllowMultiple = true)]
    public class CommandVersionImplementation : Attribute
    {
        //////////////////////////////////
        //            MEMBERS           //
        //////////////////////////////////

        private readonly string _strVersionIdentifier = string.Empty;
        private readonly Type _oCommandType = default(Type);


        //////////////////////////////////
        //          CONSTRUCTORS        //
        //////////////////////////////////

        public PubicCommandVersionImplementation(string pVersionIdentifier, Type pType)
        {
            _strVersionIdentifier = pVersionIdentifier;
            _oCommandType = pType;
        }


        //////////////////////////////////
        //          PROPERTIES          //
        //////////////////////////////////

        public string VersionIdentifier
        {
            get { return _strVersionIdentifier; }
        }

        //////////////////////////////////

        public Type PublicCommandType
        {
            get { return _oCommandType; }
        }

        //////////////////////////////////
    }
}