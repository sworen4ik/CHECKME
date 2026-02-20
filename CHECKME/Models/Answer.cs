using CHECKME.Models;
using System.ComponentModel.DataAnnotations;

namespace CHECKME.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        public int Points { get; set; }

        // Внешний ключ
        public int QuestionId { get; set; }

        // Навигационное свойство
        public Question? Question { get; set; }
    }
}