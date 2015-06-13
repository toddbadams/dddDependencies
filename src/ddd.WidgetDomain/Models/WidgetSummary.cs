using ddd.Core.Entities.AddressDomain;
using ddd.Core.Entities.WidgetDomain;

namespace ddd.WidgetDomain.Models
{
    public class WidgetSummary
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Distance { get; set; }

        internal static WidgetSummary Create(Widget widget, Address address, decimal distance)
        {
            var distanceString = string.Format("{0} miles", distance.ToString("0.00"));
            var result = new WidgetSummary
            {
                Name = widget.DisplayName,
                Address = address.AddressLine1,
                ImageUrl = widget.ImageUrl,
                Distance = distanceString
            };
            return result;
        }

        internal static string BuildQuery()
        {
            var result = "SELECT * FROM dbo.ContactLogSummaries WHERE MaternalCaseID = " +
                         " ORDER BY ContactLogEntryID DESC";
            return result;
        }

        public struct Request
        {
            public decimal Longitude;
            public decimal Latitude;
            public decimal Distance;
            public int Start;
            public int Limit;
        }
    }

   
}
