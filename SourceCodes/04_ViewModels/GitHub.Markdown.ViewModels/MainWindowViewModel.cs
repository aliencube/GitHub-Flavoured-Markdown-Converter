using Aliencube.GitHub.Markdown.ViewModels.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Aliencube.GitHub.Markdown.ViewModels
{
    /// <summary>
    /// This represents the view model entity for the <c>MainWindow</c> class.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _markdownInput;

        /// <summary>
        /// Gets or sets the input text as a Markdown format.
        /// </summary>
        public string MarkdownInput
        {
            get { return this._markdownInput; }
            set
            {
                this._markdownInput = value;
                this.OnPropertyChanged();
            }
        }

        private string _htmlOutput;

        /// <summary>
        /// Gets or sets the output text as an HTML format.
        /// </summary>
        public string HtmlOutput
        {
            get { return this._htmlOutput; }
            set
            {
                this._htmlOutput = value;
                this.OnPropertyChanged();
            }
        }

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Events
    }
}