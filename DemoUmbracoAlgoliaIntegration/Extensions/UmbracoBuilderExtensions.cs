using DemoUmbracoAlgoliaIntegration.Converters;
using Umbraco.Cms.Integrations.Search.Algolia.Extensions;

namespace DemoUmbracoAlgoliaIntegration.Extensions;

public static class UmbracoBuilderExtensions
{
    public static IUmbracoBuilder AddCustomAlgoliaConverters(this IUmbracoBuilder builder)
    {
        builder.AlgoliaConverters().Append<DateTimeConverter>();

        return builder;
    }
}