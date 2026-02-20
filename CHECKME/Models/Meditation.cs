using System.ComponentModel.DataAnnotations;

namespace CHECKME.Models
{
    public class Meditation
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string VideoUrl { get; set; } = string.Empty;

        public string AudioUrl { get; set; } = string.Empty;

        public int Duration { get; set; }

        public string Difficulty { get; set; } = string.Empty;

        public string ThumbnailUrl { get; set; } = string.Empty;

        public string Technique { get; set; } = string.Empty;
    }
}