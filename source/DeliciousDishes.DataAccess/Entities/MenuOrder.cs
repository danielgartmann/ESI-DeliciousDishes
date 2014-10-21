using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliciousDishes.DataAccess.Entities
{
    public class MenuOrder
    {
        public long Id { get; set; }

        [ForeignKey("DailyOffer")]
        public long DailyOfferId { get; set; }

        public DailyOffer DailyOffer { get; set; }

        public string OrderUser { get; set; }

        public string RecipientUser { get; set; }

        public string Remarks { get; set; }

        public bool IsCancelled { get; set; }

        public DateTime? CancellationDateTime { get; set; }

    }
}