using DemoUmbracoAlgoliaIntegration.Builders;
using DemoUmbracoAlgoliaIntegration.Extensions;
using DemoUmbracoAlgoliaIntegration.Handlers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Integrations.Search.Algolia.Builders;
using Umbraco.Cms.Integrations.Search.Algolia.Handlers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace DemoUmbracoAlgoliaIntegration;

public class DemoUmbracoAlgoliaIntegrationComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        //this is just for demonstration purposes, do not replace AlgoliaContentCacheRefresherHandler unless absolutely necessary
        //var serviceToRemove = builder.Services.FirstOrDefault(x => x.ImplementationType == typeof(AlgoliaContentCacheRefresherHandler));
        //if (serviceToRemove != null)
        //{
        //    builder.Services.Remove(serviceToRemove);
        //}
        //builder.AddNotificationAsyncHandler<ContentCacheRefresherNotification, DemoAlgoliaNotificationHandler>();
        
        builder.AddCustomAlgoliaConverters();
        
        builder.Services.AddScoped<IRecordBuilder<Article>, ArticleRecordBuilder>();
    }
}