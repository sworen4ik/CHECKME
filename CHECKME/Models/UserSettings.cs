namespace CHECKME.Models
{
    public class UserSettings
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Theme { get; set; } = "light";

        public bool NotificationsEnabled { get; set; } = true;

        public string Language { get; set; } = "ru";
    }
}