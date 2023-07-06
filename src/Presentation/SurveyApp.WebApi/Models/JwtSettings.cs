namespace SurveyApp.WebApi.Models
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
    }
}
