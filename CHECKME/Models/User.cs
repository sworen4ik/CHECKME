using Microsoft.AspNetCore.Identity;

namespace CHECKME.Models
{
    // Расширяем стандартного пользователя Identity
    public class User : IdentityUser
    {
        // Добавляем дополнительные поля, если нужно
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}