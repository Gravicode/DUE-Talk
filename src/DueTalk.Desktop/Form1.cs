using DueTalk.Core.Services;
using DueTalk.Desktop.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using OpenAI.GPT3.Extensions;

namespace DueTalk.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AppConstants.MainFrm = this;
            var services = new ServiceCollection();
            services.AddOpenAIService(settings => { settings.ApiKey = AppConstants.OpenAIKey; settings.Organization = AppConstants.OrgID; });
            services.AddSingleton<DueServices>();
            services.AddWindowsFormsBlazorWebView();
            services.AddMudServices(config => {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
            blazorWebView1.HostPage = "wwwroot\\index.html";
            blazorWebView1.Services = services.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<App>("#app");
            blazorWebView1.RootComponents.Add<HeadOutlet>("head::after");
            this.FormClosed += (a, b) => { Environment.Exit(0); };
        }
    }
}