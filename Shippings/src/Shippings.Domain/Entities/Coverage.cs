using System;
namespace Shippings.Domain.Entities
{
    public class Coverage : BaseEntity
    {
        public int CoverageId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public CoverageType CoverageType { get; set; }
        public string CoverageValue { get; set; }

        public string ExternalId { get; set; }
        public string ExternalName { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }

    public enum CoverageType
    {
        None = 0,
        CountryStateIdentifier = 1,
        ZipCode = 2,
        CustomPolygon = 3
    }
}
