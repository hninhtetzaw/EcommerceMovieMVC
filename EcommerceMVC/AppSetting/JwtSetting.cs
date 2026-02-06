namespace EcommerceMVC.AppSetting
{
    public class JwtSetting
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ExpireMinutes { get; set; }
    }
}
