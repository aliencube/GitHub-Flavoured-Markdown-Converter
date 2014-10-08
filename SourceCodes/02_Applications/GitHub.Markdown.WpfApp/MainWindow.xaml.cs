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
        public MainWindow()
        {
            InitializeComponent();
        }

        public IConverterService Converter { get; set; }

        private async void Convert_Click(object sender, RoutedEventArgs e)
        {
            var input = this.Input.Text;
            var output = await this.Converter.ConvertAsync(input);
            this.Output.NavigateToString(output);
        }
    }
}