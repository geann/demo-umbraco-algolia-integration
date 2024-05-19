using DemoUmbracoAlgoliaIntegration.Extensions;
using Umbraco.Cms.Core.Composing;

namespace DemoUmbracoAlgoliaIntegration;

public class DemoUmbracoAlgoliaIntegrationComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddCustomAlgoliaConverters();
    }
}