using Algolia.Search.Utils;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Integrations.Search.Algolia.Converters;

namespace DemoUmbracoAlgoliaIntegration.Converters;

public class DateTimeConverter : IAlgoliaIndexValueConverter
{
    public string Name =>  Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.DateTime;

    public object ParseIndexValues(IProperty property, IEnumerable<object> indexValues)
    {
        return (indexValues.FirstOrDefault() as DateTime?)?.ToUnixTimeSeconds();
    }
}