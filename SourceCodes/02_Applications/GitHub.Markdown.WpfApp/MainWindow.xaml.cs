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

        public MainWindow(
            IGitHubClientSettings settings,
            IGitHubClientHelper helper,
            IConverterService converter)
        {
            InitializeComponent();

            this._settings = settings;
            this._helper = helper;
            this._converter = converter;
        }

        private async void Convert_Click(object sender, RoutedEventArgs e)
        {
            var input = this.Input.Text;
            var output = await this._converter.ConvertAsync(input);
            this.Output.NavigateToString(output);
        }
    }
}