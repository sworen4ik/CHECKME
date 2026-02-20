using CHECKME.Models;
using System.ComponentModel.DataAnnotations;

namespace CHECKME.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        // Внешний ключ
        public int TestId { get; set; }

        // Навигационное свойство
        public Test? Test { get; set; }

        // Связь с ответами
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}