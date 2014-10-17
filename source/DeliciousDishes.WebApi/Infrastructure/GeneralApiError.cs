namespace DeliciousDishes.WebApi.Infrastructure
{
    class GeneralApiError : ApiError
    {
        public string Code { get; set; }
    }
}