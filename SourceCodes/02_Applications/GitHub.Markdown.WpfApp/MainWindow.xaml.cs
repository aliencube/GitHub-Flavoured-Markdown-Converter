using Aliencube.GitHub.Markdown.Services.Interfaces;
using Aliencube.GitHub.Markdown.ViewModels;
using System;
using System.Windows;

namespace Aliencube.GitHub.Markdown.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IConverterService _converter;
        private readonly MainWindowViewModel _vm;

        /// <summary>
        /// Initialises a new instance of the <c>MainWindow</c> class.
        /// </summary>
        /// <param name="converter"><c>ConverterService</c> instance.</param>
        public MainWindow(IConverterService converter)
        {
            InitializeComponent();

            if (converter == null)
            {
                throw new ArgumentNullException("converter");
            }
            this._converter = converter;

            this._vm = new MainWindowViewModel();

            this.DataContext = this._vm;
        }

        /// <summary>
        /// Raises the Click event on clicking the "Convert" button.
        /// </summary>
        /// <param name="sender">Object that raises the event.</param>
        /// <param name="e">Event argument.</param>
        private async void Convert_Click(object sender, RoutedEventArgs e)
        {
            this._vm.HtmlOutput = await this._converter.ConvertAsync(this._vm.MarkdownInput);
            this.HtmlOutput.NavigateToString(this._vm.HtmlOutput);
        }
    }
}