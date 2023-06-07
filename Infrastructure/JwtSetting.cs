namespace TeachersPet.Infrastructure
{
    public class JwtSetting
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int MinutesToExpiration { get; set; }

        public TimeSpan Expiration => TimeSpan.FromMinutes(MinutesToExpiration);
    }
}