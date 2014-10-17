namespace DeliciousDishes.WebApi
{
    public class MenuOrderDto
    {
        public long MenuOrderId { get; set; }

        public long DailyMenuId { get; set; }

        public string OrderUserId { get; set; }

        public string RecipientUserId { get; set; }

        public string Remarks { get; set; }

    }
}