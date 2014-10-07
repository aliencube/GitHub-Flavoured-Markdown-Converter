using System.Configuration;

namespace Aliencube.GitHub.Markdown.Configurations
{
    /// <summary>
    /// This represents the production information element entity.
    /// </summary>
    public class ProductInformationElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the name value.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
    }
}