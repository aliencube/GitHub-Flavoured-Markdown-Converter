using System.Configuration;

namespace Aliencube.GitHub.Markdown.Configurations
{
    /// <summary>
    /// This represents the proxy settings element entity.
    /// </summary>
    public class ProxyElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the name value.
        /// </summary>
        [ConfigurationProperty("useProxy", IsRequired = false, DefaultValue = false)]
        public bool UseProxy
        {
            get { return (bool)this["useProxy"]; }
            set { this["useProxy"] = value; }
        }

        /// <summary>
        /// Gets or sets the URL value.
        /// </summary>
        [ConfigurationProperty("url", IsRequired = false, DefaultValue = "")]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        /// <summary>
        /// Gets or sets the domain value.
        /// </summary>
        [ConfigurationProperty("domain", IsRequired = false, DefaultValue = "")]
        public string Domain
        {
            get { return (string)this["domain"]; }
            set { this["domain"] = value; }
        }

        /// <summary>
        /// Gets or sets the username value.
        /// </summary>
        [ConfigurationProperty("username", IsRequired = false, DefaultValue = "")]
        public string Username
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        /// <summary>
        /// Gets or sets the password value.
        /// </summary>
        [ConfigurationProperty("password", IsRequired = false, DefaultValue = "")]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }
    }
}