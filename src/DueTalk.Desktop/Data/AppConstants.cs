using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueTalk.Desktop.Data {
    public class AppConstants {
        public static string OPENAI_ENGINE_ID = "code-davinci-002";

        public static long MaxAllowedFileSize = 4 * 1024000;
        public static Form1 MainFrm { get; set; }
        public static string OpenAIKey = "";
        public static string OrgID = "";
        public static string TemplateDataset = "";
    }
    public class FineTuneData
    {
        public string Prompt { get; set; }
        public string Completion { get; set; }
    }
    public enum FineTuneCases
    {
        ClassificationSentiment,
        ClassificationYesNo,
        ClassificationNumericalCategory,
        GenerationWriteAds,
        GenerationEntityExtraction,
        GenerationCustomerSupport,
        GenerationProductDesc
    }
    public enum MessageSources
    {
        System, User, Assistant
    }
    public class ChatItem
    {
        public MessageSources Source { get; set; }
        public string Message { get; set; }
    }

}
