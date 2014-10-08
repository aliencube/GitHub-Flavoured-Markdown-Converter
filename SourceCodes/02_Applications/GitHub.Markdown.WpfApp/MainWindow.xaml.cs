using Aliencube.GitHub.Markdown.Configurations;
using Aliencube.GitHub.Markdown.Configurations.Interfaces;
using Aliencube.GitHub.Markdown.Services;
using Aliencube.GitHub.Markdown.Services.Interfaces;
using System.Configuration;
using System.Windows;

namespace Aliencube.GitHub.Markdown.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IGitHubClientSettings _settings;
        private readonly IGitHubClientHelper _helper;
        private readonly IConverterService _converter;

        public MainWindow()
        {
            InitializeComponent();

            this._settings = ConfigurationManager.GetSection("gitHubClientSettings") as GitHubClientSettings;
            this._helper = new GitHubClientHelper(this._settings);
            this._converter = new ConverterService(this._helper);
        }

        private async void Convert_Click(object sender, RoutedEventArgs e)
        {
            var input = this.Input.Text;
            var output = await this._converter.ConvertAsync(input);
            this.Output.NavigateToString(output);
        }
    }
}