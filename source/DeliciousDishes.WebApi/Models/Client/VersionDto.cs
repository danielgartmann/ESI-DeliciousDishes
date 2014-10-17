namespace DeliciousDishes.WebApi.Models.Client
{
    public class VersionDto
    {
        public string ProductVersion { get; set; }
        public string BuildDateTime { get; set; }
        public string Build { get; set; }
        public string Configuration { get; set; }
    }
}