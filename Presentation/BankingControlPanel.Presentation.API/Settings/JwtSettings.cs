namespace BankingControlPanel.Presentation.API.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double ExpirationMinutes { get; set; }
    }
}