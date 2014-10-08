using Aliencube.GitHub.Markdown.Configurations;
using Aliencube.GitHub.Markdown.Services;
using System.Configuration;
using System.Windows;

namespace Aliencube.GitHub.Markdown.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var settings = (GitHubClientSettings)ConfigurationManager
                .GetSection("gitHubClientSettings");
            var helper = new GitHubClientHelper(settings);
            var converter = new ConverterService(helper);

            Application.Current.MainWindow = new MainWindow(settings, helper, converter);
            Application.Current.MainWindow.Show();
        }
    }
}