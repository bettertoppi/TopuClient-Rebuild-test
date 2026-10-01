namespace TopuClient.Models
{
    public class Account
    {
        public string Username { get; set; } = string.Empty;
        public string Uuid { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public bool IsMicrosoft { get; set; }
    }
}
