using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliciousDishes.DataAccess.Entities
{
    public class DailyOffer
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long Stock { get; set; }

        [ForeignKey("Menu")]
        public long MenuId { get; set; }

        public Menu Menu { get; set; }
    }
}
