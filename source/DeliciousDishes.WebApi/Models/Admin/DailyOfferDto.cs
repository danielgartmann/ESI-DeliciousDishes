using System;

namespace DeliciousDishes.WebApi.Models.Admin
{
    public class DailyOfferDto
    {
        public long DailyOfferId { get; set; }

        public DateTime Validity { get; set; }

        public long OfferId { get; set; }

        public int InitialStock { get; set; }

        public double? AdjustedPrice { get; set; }
    }
}