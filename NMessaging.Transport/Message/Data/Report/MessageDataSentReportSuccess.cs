namespace NMessaging.Transport.Message.Data.Report
{
    public class MessageDataSentReportSuccess : IMessageDataReport
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public MessageDataReportType MessageReportType
        {
            get { return MessageDataReportType.Success; }
        }

        //////////////////////////////
    }
}