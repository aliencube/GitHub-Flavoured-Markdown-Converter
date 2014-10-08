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
	    private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            this._settings = ConfigurationManager.GetSection("gitHubClientSettings") as GitHubClientSettings;
            this._helper = new GitHubClientHelper(this._settings);
            this._converter = new ConverterService(this._helper);
			this._viewModel = new MainViewModel(_converter);

	        // YoungjaeKim (2014-10-08 18:05:15): Refactor-at-will.
			// The recommendation in WPF world is to minimize code-behind as possible, so that 'Binding' syntax could be galore in XAML file in order to communicate between ViewModel and XAML.
			this.DataContext = _viewModel; 
        }

        private async void Convert_Click(object sender, RoutedEventArgs e)
        {
			// YoungjaeKim (2014-10-08 18:28:47): You can see the `Binding` syntax in `InputWordCount` and `OutputWordCount` TextBox control.
			// They just show examples of DataContext Binding that MainViewModel Properties have coupled with each XAML control.
			var output = await _viewModel.ConvertToMarkdown(this.Input.Text); 
			this.Output.NavigateToString(output);
        }
    }
}