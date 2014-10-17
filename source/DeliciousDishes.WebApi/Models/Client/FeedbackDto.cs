namespace DeliciousDishes.WebApi.Models.Client
{
    public class FeedbackDto
    {
        public long FeedbackId { get; set; }

        public long DailyOfferId { get; set; }

        public int? Stars { get; set; }

        public string Comment { get; set; }
    }
}