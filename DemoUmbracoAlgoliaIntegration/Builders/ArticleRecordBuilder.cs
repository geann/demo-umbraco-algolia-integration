using DemoUmbracoAlgoliaIntegration.Models;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Integrations.Search.Algolia.Builders;
using Umbraco.Cms.Integrations.Search.Algolia.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace DemoUmbracoAlgoliaIntegration.Builders;

public class ArticleRecordBuilder : IRecordBuilder<Article>
{
    public Record GetRecord(IContent content, Record record)
    {
        return new ArticleRecord(record)
        {
            ParentPageId = content.ParentId,
        };
    }
}