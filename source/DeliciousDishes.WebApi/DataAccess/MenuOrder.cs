using System;
using DeliciousDishes.WebApi.Models.Client.Validation;
using FluentValidation.Attributes;

namespace DeliciousDishes.WebApi.Models.Client
{
    [Validator(typeof(MenuOrderValidator))]
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