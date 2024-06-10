This is a project demonstrating possible customisations for the library [Umbraco.Cms.Integrations.Search.Algolia](https://docs.umbraco.com/umbraco-dxp/integrations/algolia).

The project is currently based on 

- Umbraco 13.3.2 
- Umbraco.Cms.Integrations.Search.Algolia 2.1.5

## Customisations

### 1. Property converters

Converters are the best way to extend the library if you need to customise how specific properties are stored in Algolia indexes. 

#### 🔗 **[DateTimeConverter](https://github.com/geann/demo-umbraco-algolia-integration/blob/main/DemoUmbracoAlgoliaIntegration/Converters/DateTimeConverter.cs)**

This class shows an example of property converter for the `Umbraco.DateTime` property editor. As Algolia works with dates in the Unix timestamp format, the method converts Umbraco properties to this format.

📖 Additional information:
- [Date attributes in Algolia records](https://www.algolia.com/doc/guides/sending-and-managing-data/prepare-your-data/in-depth/what-is-in-a-record/#dates)
- [Filter by date](https://www.algolia.com/doc/guides/managing-results/refine-results/filtering/how-to/filter-by-attributes/#filter-by-date)
- [Sort by date](https://www.algolia.com/doc/guides/managing-results/refine-results/sorting/how-to/sort-an-index-by-date/)


### 2. Record builders

Record builders usually require two classes: a custom record class inherited from [Record](https://github.com/umbraco/Umbraco.Cms.Integrations/blob/main/src/Umbraco.Cms.Integrations.Search.Algolia/Models/Record.cs) and a record builder class implementing the interface [IRecordBuilder<TContentType>](https://github.com/umbraco/Umbraco.Cms.Integrations/blob/main/src/Umbraco.Cms.Integrations.Search.Algolia/Builders/IRecordBuilder.cs).

#### 🔗 **[ArticleRecordBuilder](https://github.com/geann/demo-umbraco-algolia-integration/blob/main/DemoUmbracoAlgoliaIntegration/Builders/ArticleRecordBuilder.cs)**

This is an example showing how to add a custom attribute to the record object and populate it from a standard IContent field. In this case, ParentPageId is defined as a separate attribute so that it can be used for filtering articles by parent page ID if they are stored in different areas of the content tree but based on the same Article document type.

#### 🔗 **[LocationRecordBuilder](https://github.com/geann/demo-umbraco-algolia-integration/blob/main/DemoUmbracoAlgoliaIntegration/Builders/LocationRecordBuilder.cs)**

This record builder is required for document types that should support geographical search, for example office locations or offline shops. Algolia requires that geolocation data is stored in a special attribute called `_geoloc`. This attribute should be an object or an array of objects with two attributes: `lat` and `lng`. The GeoRecord class is a custom record with one geographical location, and the class LocationRecordBuilder shows how this record can be populated (assuming that latitude and longitude are stored as a comma-separated string in a property called `coordinates`. This is just an example and the format and name of the property can easily be changed.   

📖 Additional information:
- [Geolocation attribute in Algolia records](https://www.algolia.com/doc/guides/managing-results/refine-results/geolocation/#enabling-geo-search-by-adding-geolocation-data-to-records)
- [Geographical filtering and sorting](https://www.algolia.com/doc/guides/managing-results/refine-results/geolocation/#geographical-filtering-and-sorting)
- [Geographical ranking info](https://www.algolia.com/doc/guides/managing-results/refine-results/geolocation/how-to/geo-ranking-info/)

### 3. Notification handler

The out-of-the-box [AlgoliaContentCacheRefresherHandler](https://github.com/umbraco/Umbraco.Cms.Integrations/blob/main/src/Umbraco.Cms.Integrations.Search.Algolia/Handlers/AlgoliaContentCacheRefresherHandler.cs) is not built for inheritance, as none of its methods are virtual. It is still possible to create a custom class implementing INotificationAsyncHandler and define your own logic for retrieving updated entities and processing them, though be careful with this customisation and don't use it unless you absolutely have to because future library upgrades may become more difficult.

#### 🔗 **[DemoAlgoliaNotificationHandler](https://github.com/geann/demo-umbraco-algolia-integration/blob/main/DemoUmbracoAlgoliaIntegration/Handlers/DemoAlgoliaNotificationHandler.cs)**

This notification handler is copied from the standard one that comes with the library, the only change is in the `RebuildIndex()` method. It checks if the toggle property `hideFromSearch` is set for the current entity and if yes, it skips or deletes the entity from the index. This may be required in scenarios when some non-searchable pages should only be accessed via a direct link but not visible in search results or on listing pages. 

The class `DemoUmbracoAlgoliaIntegrationComposer` uses an extension method to remove the standard implementation of `AlgoliaContentCacheRefresherHandler` from the DI container. Please note that is code is commented out intentionally so that people who want to use it have to enable it implicitly. 
