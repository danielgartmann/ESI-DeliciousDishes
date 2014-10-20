using System;

namespace DeliciousDishes.DataAccess.Entities
{
    public class DailyOffer
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long Stock { get; set; }

        public Menu Menu { get; set; }
    }
}
