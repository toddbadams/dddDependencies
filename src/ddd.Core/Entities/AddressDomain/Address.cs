namespace ddd.Core.Entities.AddressDomain
{
    public class Address : LongEntity, IParentable
    {
        public long ParentId { get; set; }
        public ParentEntityType ParentEntityType { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string TownCity { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
    }
}
