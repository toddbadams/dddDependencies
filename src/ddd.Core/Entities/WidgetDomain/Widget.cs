using System.ComponentModel.DataAnnotations;

namespace ddd.Core.Entities.WidgetDomain
{
    public class Widget : LongEntity
    {
        public string WidgetNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [MaxLength(255)]
        public string EMail { get; set; }
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        [MaxLength(50)]
        public string ImageMimeType { get; set; }
        [MaxLength(255)]
        public string ImageDescription { get; set; }

        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)]
        //public DbGeography Location
        //{
        //    get
        //    {
        //        return DbGeography.FromText(string.Format("Point({0} {1})", Latitude, Longitude));
        //    }
        //    private set { }
        //}
    }
}
