using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Messages;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Search.Index;

namespace Search.Worker.Processors
{
    public class ProductCreatedProcessor : QueueWorker<ProductCreated>
    {
        public ProductCreatedProcessor(IConfiguration configuration, ILogger<ProductCreatedProcessor> logger)
            : base(configuration, logger, Constants.ProductCreated)
        {
        }

        protected override async Task ProcessMessage(ProductCreated product, string messageId, Message.SystemPropertiesCollection systemProperties, IDictionary<string, object> userProperties, CancellationToken cancellationToken)
        {
            var serviceName = this._configuration["AzureSearchIndex:ServiceName"];
            var serviceKey = this._configuration["AzureSearchIndex:ServiceAdminKey"];
            var indexName = this._configuration["AzureSearchIndex:CatalogIndex"];

            var serviceClient = new SearchServiceClient(serviceName, new SearchCredentials(serviceKey));
            var indexClient = serviceClient.Indexes.GetClient(indexName);

            var actions = new IndexAction<CatalogDataIndex>[]
            {
                IndexAction.Upload(
                    new CatalogDataIndex
                    {
                       Id = product.ProductId.ToString(),
                       Name = product.Name,
                       Description = product.Description,
                       Brand = product.BrandId,
                       BrandName = product.BrandName,
                       Price = Convert.ToDouble(product.BasePrice),
                       SpecialPrice = Convert.ToDouble(product.SpecialPrice),
                       Stock = product.Stock,
                       Store = product.SellerId,
                       StoreName = product.SellerName,
                    }
                ),
            };

            var batch = IndexBatch.New(actions);

            try
            {
                await indexClient.Documents.IndexAsync(batch);
            }
            catch (IndexBatchException e)
            {
                // When a service is under load, indexing might fail for some documents in the batch. 
                // Depending on your application, you can compensate by delaying and retrying. 
                // For this simple demo, we just log the failed document keys and continue.
                this._logger.LogError(
                    "Failed to index some of the documents: {0}",
                    String.Join(", ", e.IndexingResults.Where(r => !r.Succeeded).Select(r => r.Key)));
            }
            catch (Exception e)
            {
                this._logger.LogError(e.ToString());
            }
        }

    }
}
