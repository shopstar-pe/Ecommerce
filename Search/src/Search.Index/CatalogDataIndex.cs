using System;
using Newtonsoft.Json;

namespace Search.Index
{
    public class CatalogDataIndex
    {
        [System.ComponentModel.DataAnnotations.Key]
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("skuId")]
        public string SkuId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("specialPrice")]
        public double SpecialPrice { get; set; }
        [JsonProperty("brand")]
        public int? Brand { get; set; }
        [JsonProperty("brandName")]
        public string BrandName { get; set; }
        [JsonProperty("store")]
        public int Store { get; set; }
        [JsonProperty("storeName")]
        public string StoreName { get; set; }
        [JsonProperty("stock")]
        public int Stock { get; set; }
    }
}
