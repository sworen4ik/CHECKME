namespace CHECKME.Models
{
    public class DashboardViewModel
    {
        // Диаграмма стресса
        public List<ChartData> StressData { get; set; } = new();

        // Диаграмма тревожности
        public List<ChartData> AnxietyData { get; set; } = new();

        // Диаграмма настроения
        public List<ChartData> MoodData { get; set; } = new();

        // Последние результаты
        public List<TestResult> RecentResults { get; set; } = new();
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}