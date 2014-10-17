using System;

namespace DeliciousDishes.WebApi.Models.Client
{
    public class MenuOrderDto
    {
        public long MenuOrderId { get; set; }

        public long DailyOfferId { get; set; }

        public string OrderUserId { get; set; }

        public string RecipientUserId { get; set; }

        public string Remarks { get; set; }

        public bool? IsCancelled { get; set; }

        public DateTime? CancellationDateTime { get; set; }

    }
}