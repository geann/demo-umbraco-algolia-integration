using DemoUmbracoAlgoliaIntegration.Models;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Integrations.Search.Algolia.Builders;
using Umbraco.Cms.Integrations.Search.Algolia.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace DemoUmbracoAlgoliaIntegration.Builders;

public class LocationRecordBuilder : IRecordBuilder<Location>
{
    public Record GetRecord(IContent content, Record record)
    {
        return new GeoRecord(record)
        {
            GeoLocation = GetCoordinates(content)
        };
    }
    
    private GeoLocation? GetCoordinates(IContent content)
    {
        var propertyValue = content.Properties["coordinates"]?.Values.FirstOrDefault()?.PublishedValue?.ToString();
        if (!string.IsNullOrEmpty(propertyValue))
        {
            var coordinates = propertyValue.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (coordinates.Length == 2)
            {
                decimal? latitude = null;
                decimal? longitude = null;
                if (decimal.TryParse(coordinates[0], out var parsedLatitude))
                {
                    latitude = parsedLatitude;
                }
                if (decimal.TryParse(coordinates[1], out var parsedLongitude))
                {
                    longitude = parsedLongitude;
                }

                if (latitude.HasValue && longitude.HasValue)
                {
                    return new GeoLocation
                    {
                        Lat = latitude.Value,
                        Lng = longitude.Value
                    };
                }

            }
        }

        return null;
    }
}