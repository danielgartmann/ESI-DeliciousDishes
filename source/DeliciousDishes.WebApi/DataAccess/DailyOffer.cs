namespace DeliciousDishes.WebApi.DataAccess
{
    public class DailyOffer
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public long Stock { get; set; }

        public string ImageUrl { get; set; }
    }
}