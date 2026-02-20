using CHECKME.Data;
using Microsoft.EntityFrameworkCore;

namespace CHECKME.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Если база уже заполнена - выходим
                if (context.Tests.Any())
                {
                    return;
                }

                // Добавляем тесты
                context.Tests.AddRange(
                    new Test { Title = "Тест на темперамент", Description = "Узнайте свой тип темперамента", Category = "Личность" },
                    new Test { Title = "Уровень стресса", Description = "Оцените свой текущий уровень стресса", Category = "Стресс" }
                );

                // Добавляем медитации
                context.Meditations.AddRange(
                    new Meditation { Title = "Дыхательная медитация", Description = "Базовая техника осознанного дыхания", Duration = 5, Difficulty = "Начинающий", Technique = "Дыхание" }
                );

                context.SaveChanges();
            }
        }
    }
}