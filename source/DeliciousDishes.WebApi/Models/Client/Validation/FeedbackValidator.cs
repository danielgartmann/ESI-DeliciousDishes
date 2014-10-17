using FluentValidation;

namespace DeliciousDishes.WebApi.Models.Client.Validation
{
    public class FeedbackValidator : AbstractValidator<FeedbackDto>
    {
        public FeedbackValidator()
        {
            RuleFor(x => x.DailyOfferId).NotEmpty();
            
            RuleFor(x => x.Stars).NotEmpty();
            RuleFor(x => x.Stars).InclusiveBetween(0, 5);
        }
    }
}