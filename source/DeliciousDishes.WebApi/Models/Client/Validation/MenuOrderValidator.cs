using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace DeliciousDishes.WebApi.Models.Client.Validation
{
    public class MenuOrderValidator : AbstractValidator<MenuOrderDto>
    {
        public MenuOrderValidator()
        {
            RuleFor(x => x.OrderUserId).NotEmpty();
            RuleFor(x => x.DailyOfferId).NotEmpty();
        }
    }
}