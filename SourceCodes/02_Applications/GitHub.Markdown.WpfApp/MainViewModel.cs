using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Aliencube.GitHub.Markdown.Services;
using Aliencube.GitHub.Markdown.Services.Interfaces;
using Aliencube.GitHub.Markdown.WpfApp.Annotations;

namespace Aliencube.GitHub.Markdown.WpfApp
{
	/// <summary>
	/// Viewmodel Basement. (Refactor-at-will)
	/// </summary>
	public class MainViewModel : INotifyPropertyChanged
	{
		public MainViewModel(IConverterService converter)
		{
			_converter = converter;
		}

		private string _input;
		private string _markdownOutput;
		private readonly IConverterService _converter;

		/// <summary>
		/// Get latest given input through <see cref="ConvertToMarkdown"/> method.
		/// </summary>
		public string Input
		{
			get { return _input; }
			private set
			{
				_input = value; 
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Get Markdownized string through <see cref="ConvertToMarkdown"/> method.
		/// </summary>
		public string MarkdownOutput
		{
			get { return _markdownOutput; }
			private set
			{
				_markdownOutput = value;
				OnPropertyChanged();
			}
		}

		/// <summary>
		/// Convert to Markdown text.
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task<string> ConvertToMarkdown(string input)
		{
			if(_converter == null)
				throw new NullReferenceException("_converter");

			Input = input;
            MarkdownOutput = await this._converter.ConvertAsync(input);
			return MarkdownOutput;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
