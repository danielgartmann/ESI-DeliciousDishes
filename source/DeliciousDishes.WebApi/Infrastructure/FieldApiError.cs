namespace DeliciousDishes.WebApi.Infrastructure
{
    class FieldApiError : ApiError
    {
        public string FieldName { get; set; }
    }
}