using DemoUmbracoAlgoliaIntegration.Builders;
using DemoUmbracoAlgoliaIntegration.Extensions;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Integrations.Search.Algolia.Builders;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace DemoUmbracoAlgoliaIntegration;

public class DemoUmbracoAlgoliaIntegrationComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddCustomAlgoliaConverters();
        
        builder.Services.AddScoped<IRecordBuilder<Article>, ArticleRecordBuilder>();
    }
}