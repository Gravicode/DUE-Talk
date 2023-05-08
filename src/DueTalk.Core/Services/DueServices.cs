using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SemanticKernel.SemanticFunctions;
using Microsoft.SemanticKernel.Orchestration;

namespace DueTalk.Core.Services
{
    public class DueServices
    {
        const int maxPromptLength = 6000;//3200;

        public Context context { get; set; }
        public ContentFiltering detectSensitiveContent { get; set; }
        public string SkillName { get; set; } = "DueSkill";
        public string FunctionName { set; get; } = "Due";
        int MaxTokens { set; get; }
        double Temperature { set; get; }
        double TopP { set; get; }
        public bool IsProcessing { get; set; } = false;

        Dictionary<string, ISKFunction> ListFunctions = new Dictionary<string, ISKFunction>();
        
        IKernel kernel { set; get; }
        HttpClient client;
        public DueServices()
        {
            detectSensitiveContent = new ContentFiltering();
            context = new Context(BaseContext.baseContext);
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("OpenAI-Organization", Config.OPENAI_ORGANIZATION_ID);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Config.OPENAI_API_KEY}");

            kernel = KernelBuilder.Create();
        
            // Configure AI backend used by the kernel
            kernel.Config.AddOpenAITextCompletionService("davinci", Config.OPENAI_ENGINE_ID, Config.OPENAI_API_KEY, Config.OPENAI_ORGANIZATION_ID);

            SetupSkill();
        }

        public void SetupSkill(int MaxTokens = 2000, double Temperature = 0, double TopP = 1)
        {
            this.MaxTokens = MaxTokens;
            this.Temperature = Temperature;
            this.TopP = TopP;

            string skPrompt = """
{{$input}}
""";
           
            var promptConfig = new PromptTemplateConfig
            {
                Completion =
    {
        MaxTokens = this.MaxTokens,
        Temperature = this.Temperature,
        TopP = this.TopP,  
        StopSequences=new List<string>(){ "/*" }
    }
            };

            var promptTemplate = new PromptTemplate(
    skPrompt,                        // Prompt template defined in natural language
    promptConfig,                    // Prompt configuration
    kernel                           // SK instance
);


            var functionConfig = new SemanticFunctionConfig(promptConfig, promptTemplate);

            var DueFunction = kernel.RegisterSemanticFunction(SkillName, FunctionName, functionConfig);
            ListFunctions.Add(FunctionName, DueFunction);
        }

        public async Task<string> GenerateCode(string command, bool AddToInteraction = false)
        {
            string Result = string.Empty;
            try
            {
              
                if (IsProcessing) return Result;
                IsProcessing = true;
                var prompt = context.getPrompt(command);

                if (prompt.Length > maxPromptLength)
                {
                    context.trimContext(maxPromptLength - command.Length + 6); // The max length of the prompt, including the command, comment operators and spacing.
                }
                var Due = await kernel.RunAsync(prompt, ListFunctions[FunctionName]);

                if (!Due.ErrorOccurred)
                {
                    Console.WriteLine(Due);

                    string code = Due.Result;

                    var sensitiveContentFlag = await detectSensitiveContent.detectSensitiveContent(command + "\n" + code);

                    // The flag can be 0, 1 or 2, corresponding to 'safe', 'sensitive' and 'unsafe'
                    if (sensitiveContentFlag > 0)
                    {
                        Console.WriteLine(
                            sensitiveContentFlag == 1
                            ? "Your message or the model's response may have contained sensitive content."
                            : "Your message or the model's response may have contained unsafe content."
                        );

                        code = String.Empty;
                    }
                    else
                    {
                        //only allow safe interactions to be added to the context history
                        if (AddToInteraction)
                            context.addInteraction(command, code);
                    }

                    Result = code;
                }
                else
                {
                    Console.WriteLine(Due.LastErrorDescription);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                IsProcessing = false;
            }
            return Result;
        }
        

    }
}