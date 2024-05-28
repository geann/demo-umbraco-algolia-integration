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

    public static IUmbracoBuilder RemoveImplementation(this IUmbracoBuilder builder, Type implementationType)
    {
        var serviceToRemove = builder.Services.FirstOrDefault(x => x.ImplementationType == implementationType);
        if (serviceToRemove != null)
        {
            builder.Services.Remove(serviceToRemove);
        }

        return builder;
    }
}