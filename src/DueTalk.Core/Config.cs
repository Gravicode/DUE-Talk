using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DueTalk.Core
{
    public class Config
    {
        public static string OPENAI_ORGANIZATION_ID = "";
        public static string OPENAI_API_KEY = "";
        public static string OPENAI_ENGINE_ID = "code-davinci-002";

        public static (string model,string apiKey,string orgId) GetSettings()
        {
            return (OPENAI_ENGINE_ID, OPENAI_API_KEY, OPENAI_ORGANIZATION_ID);
        }
    }
}
