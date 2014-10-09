using Aliencube.GitHub.Markdown.Configurations;
using Aliencube.GitHub.Markdown.Configurations.Interfaces;
using Aliencube.GitHub.Markdown.Services;
using Aliencube.GitHub.Markdown.Services.Interfaces;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using System.Configuration;
using System.Windows;

namespace Aliencube.GitHub.Markdown.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initialises a new instance of the <c>App</c> class.
        /// </summary>
        public App()
        {
            this.Startup += App_Startup;
        }

        /// <summary>
        /// Raises the Startup event that is fired when an application is starting. This event is raised by the OnStartup method.
        /// </summary>
        /// <param name="sender">Object that raises the event.</param>
        /// <param name="e">Event argument.</param>
        private void App_Startup(object sender, StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.Register(p => GitHubClientSettings.CreateInstance()).As<IGitHubClientSettings>().InstancePerLifetimeScope();
            builder.RegisterType<GitHubClientHelper>().As<IGitHubClientHelper>().InstancePerLifetimeScope();
            builder.RegisterType<ConverterService>().As<IConverterService>().InstancePerLifetimeScope();

            var container = builder.Build();

            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);

            Current.MainWindow = new MainWindow(ServiceLocator.Current.GetInstance<IConverterService>());
            Current.MainWindow.Show();
        }
    }
}