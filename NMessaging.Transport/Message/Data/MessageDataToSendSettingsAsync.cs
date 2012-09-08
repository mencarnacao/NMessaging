using NMessaging.Transport.Message.Data.Report;

namespace NMessaging.Transport.Message.Data
{
    public delegate void OnMessageSentDelegate(MessageDataSentReportSuccess pMessageSentReportSuccess);
    public delegate void OnMessageNotSentDelegate(MessageDataSentReportFail pMessageSentReportFail);

    public class MessageDataToSendSettingsAsync : MessageDataToSendSettings
    {
        //////////////////////////////
        //         PROPERTIES       //
        //////////////////////////////

        private event OnMessageSentDelegate OnMessageSent;
        private event OnMessageNotSentDelegate OnMessageNotSent;

        //////////////////////////////
    }
}
