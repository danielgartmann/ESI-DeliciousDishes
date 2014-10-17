namespace DeliciousDishes.WebApi.Models.Client
{
    /// <summary>
    /// This is a dto only used by the ordering client b'cause it increases complexity & makes general no sense to share dtos 
    /// between order client and backend, we can design the dto for order client without any limitations.
    /// </summary>
    public class DailyOfferDto
    {
        public long DailyOfferId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public long Stock { get; set; }

        public string ImageUrl { get; set; }
    }
}