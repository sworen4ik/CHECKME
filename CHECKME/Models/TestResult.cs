using System;

namespace CHECKME.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int TestId { get; set; }
        public Test? Test { get; set; }
        public int TotalScore { get; set; }
        public string Interpretation { get; set; } = string.Empty;
        public DateTime CompletedDate { get; set; }

        // Категория результата (Стресс, Тревога, Настроение и т.д.)
        public string Category { get; set; } = string.Empty;

        // Процентный результат (для диаграмм)
        public double PercentageScore { get; set; }
    }
}