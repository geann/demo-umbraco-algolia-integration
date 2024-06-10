This is a project demonstrating possible customisations for the library [Umbraco.Cms.Integrations.Search.Algolia](https://docs.umbraco.com/umbraco-dxp/integrations/algolia).

The project is currently based on 

- Umbraco 13.3.2
- Umbraco.Cms.Integrations.Search.Algolia 2.1.5

## Customisations:

### 1. Property converters

#### 🔗 **[DateTimeConverter](https://github.com/geann/demo-umbraco-algolia-integration/blob/main/DemoUmbracoAlgoliaIntegration/Converters/DateTimeConverter.cs)**

This class shows an example of property converter for the `Umbraco.DateTime` property editor. As Algolia works with dates in the Unix timestamp format, the method converts Umbraco properties to this format.

Additional information:
- [Date attributes in Algolia records](https://www.algolia.com/doc/guides/sending-and-managing-data/prepare-your-data/in-depth/what-is-in-a-record/#dates)
- [Filter by date](https://www.algolia.com/doc/guides/managing-results/refine-results/filtering/how-to/filter-by-attributes/#filter-by-date)
- [Sort by date](https://www.algolia.com/doc/guides/managing-results/refine-results/sorting/how-to/sort-an-index-by-date/)


### 2. Record builders

Record builders usually require two classes: a custom record class inherited from [Record](https://github.com/umbraco/Umbraco.Cms.Integrations/blob/main/src/Umbraco.Cms.Integrations.Search.Algolia/Models/Record.cs) and a record builder class implementing the interface [IRecordBuilder<TContentType>](https://github.com/umbraco/Umbraco.Cms.Integrations/blob/main/src/Umbraco.Cms.Integrations.Search.Algolia/Builders/IRecordBuilder.cs).

#### 🔗 **[ArticleRecordBuilder](https://github.com/geann/demo-umbraco-algolia-integration/blob/main/DemoUmbracoAlgoliaIntegration/Builders/ArticleRecordBuilder.cs)**

This is an example showing how to add a custom attribute to the record object and populate it from a standard IContent field. In this case, ParentPageId is defined as a separate attribute so that it can be used for filtering articles by parent page ID if they are stored in different areas of the content tree but based on the same Article document type.

#### 🔗 **[LocationRecordBuilder](https://github.com/geann/demo-umbraco-algolia-integration/blob/main/DemoUmbracoAlgoliaIntegration/Builders/LocationRecordBuilder.cs)**

### 3. Notification handler

#### 🔗 **[DemoAlgoliaNotificationHandler](https://github.com/geann/demo-umbraco-algolia-integration/blob/main/DemoUmbracoAlgoliaIntegration/Handlers/DemoAlgoliaNotificationHandler.cs)**
