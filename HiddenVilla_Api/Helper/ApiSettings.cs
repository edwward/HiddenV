namespace HiddenVilla_Api.Helper
{
    //stejne properties jako v appsettings.json
    public class ApiSettings
    {
        public string? SecretKey { get; set; }
        public string? ValidAudience { get; set; }
        public string? ValidIssuer { get; set; }
    }
}
