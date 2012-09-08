namespace NMessaging.Transport.Message.Data.Report
{
    public class MessageDataSentReportFail : IMessageDataReport
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        public MessageDataReportType MessageReportType
        {
            get { return MessageDataReportType.Fail; }
        }

        //////////////////////////////
    }
}
