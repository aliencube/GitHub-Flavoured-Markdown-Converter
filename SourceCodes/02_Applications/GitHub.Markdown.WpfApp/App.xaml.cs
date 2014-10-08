using System.Configuration;
using System.Windows;
using Aliencube.GitHub.Markdown.Configurations;
using Aliencube.GitHub.Markdown.Configurations.Interfaces;
using Aliencube.GitHub.Markdown.Services;
using Aliencube.GitHub.Markdown.Services.Interfaces;
using Autofac;

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

            var builder = new ContainerBuilder();

            builder.Register(p => ConfigurationManager.GetSection("gitHubClientSettings") as GitHubClientSettings).As<IGitHubClientSettings>().InstancePerLifetimeScope();
            builder.RegisterType<GitHubClientHelper>().As<IGitHubClientHelper>().InstancePerLifetimeScope();
            builder.RegisterType<ConverterService>().As<IConverterService>().PropertiesAutowired().InstancePerLifetimeScope();

            builder.Build();
        }
    }
}