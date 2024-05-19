using Umbraco.Cms.Integrations.Search.Algolia.Models;

namespace DemoUmbracoAlgoliaIntegration.Models;

public class ArticleRecord(Record record) : Record(record)
{
    public required int ParentPageId { get; set; }
}