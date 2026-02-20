using System.ComponentModel.DataAnnotations;

namespace CHECKME.Models
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        // Навигационное свойство для связи с вопросами
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}