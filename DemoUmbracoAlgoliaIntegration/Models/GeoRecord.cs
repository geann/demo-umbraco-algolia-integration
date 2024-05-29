using Newtonsoft.Json;
using Umbraco.Cms.Integrations.Search.Algolia.Models;

namespace DemoUmbracoAlgoliaIntegration.Models;

public class GeoRecord(Record record) : Record(record)
{
    [JsonProperty(PropertyName = "_geoloc")]
    public required GeoLocation? GeoLocation { get; set; }
}