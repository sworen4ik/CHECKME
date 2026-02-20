using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CHECKME.Data;
using CHECKME.Models;
using System.Security.Claims;

namespace CHECKME.Controllers
{
    [Authorize] // Только для авторизованных пользователей
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Получаем все результаты пользователя
            var results = await _context.TestResults
                .Include(r => r.Test)
                .Where(r => r.UserId == userId)
                .OrderBy(r => r.CompletedDate)
                .ToListAsync();

            var viewModel = new DashboardViewModel();

            // Группируем по категориям для диаграмм
            foreach (var result in results)
            {
                var chartData = new ChartData
                {
                    Date = result.CompletedDate,
                    Value = result.PercentageScore > 0 ? result.PercentageScore :
                           (result.TotalScore / 100.0) // Примерное преобразование
                };

                switch (result.Test?.Category)
                {
                    case "Стресс":
                        chartData.Category = "Стресс";
                        viewModel.StressData.Add(chartData);
                        break;
                    case "Тревога":
                        chartData.Category = "Тревожность";
                        viewModel.AnxietyData.Add(chartData);
                        break;
                    case "Настроение":
                        chartData.Category = "Настроение";
                        viewModel.MoodData.Add(chartData);
                        break;
                }
            }

            viewModel.RecentResults = results.Take(5).ToList();

            return View(viewModel);
        }
    }
}