using DueTalk.Desktop.Data;
using System.Configuration;

namespace DueTalk.Desktop
{
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            AppConstants.OpenAIKey = ConfigurationManager.AppSettings["OpenAIKey"];
            AppConstants.OrgID = ConfigurationManager.AppSettings["OrgID"];
            AppConstants.TemplateDataset = ConfigurationManager.AppSettings["TemplateDataset"];
            Core.Config.OPENAI_API_KEY = AppConstants.OpenAIKey;
            Core.Config.OPENAI_ORGANIZATION_ID = AppConstants.OrgID;
            Core.Config.OPENAI_ENGINE_ID = ConfigurationManager.AppSettings["Model"];

            Application.Run(new Form1());

           
        }
    }
}