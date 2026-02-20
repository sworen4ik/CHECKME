using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CHECKME.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meditations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Technique = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meditations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    Interpretation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResults_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Meditations",
                columns: new[] { "Id", "AudioUrl", "Description", "Difficulty", "Duration", "Technique", "ThumbnailUrl", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { 1, "", "Базовая техника осознанного дыхания", "Начинающий", 5, "Дыхание", "/images/breathing.jpg", "Дыхательная медитация", "/videos/breathing.mp4" },
                    { 2, "", "Почувствуйте каждую часть тела", "Начинающий", 10, "Сканирование", "/images/body-scan.jpg", "Сканирование тела", "/videos/body-scan.mp4" },
                    { 3, "", "Развитие сострадания к себе и другим", "Средний", 15, "Любящая доброта", "/images/loving-kindness.jpg", "Медитация любящей доброты", "/videos/loving-kindness.mp4" },
                    { 4, "", "Создание безопасного места", "Средний", 12, "Визуализация", "/images/visualization.jpg", "Визуализация", "/videos/visualization.mp4" },
                    { 5, "", "Снятие острой тревоги", "Начинающий", 8, "Дыхание", "/images/anxiety-relief.jpg", "Медитация при тревоге", "/videos/anxiety-relief.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Личность", "Узнайте свой тип темперамента", "/images/temperament.jpg", "Тест на темперамент" },
                    { 2, "Стресс", "Оцените свой текущий уровень стресса", "/images/stress.jpg", "Уровень стресса" },
                    { 3, "Тревога", "Определите уровень тревожности", "/images/anxiety.jpg", "Шкала тревоги Бека" },
                    { 4, "Настроение", "Оценка симптомов депрессии", "/images/depression.jpg", "Тест на депрессию" },
                    { 5, "Эмоции", "Насколько хорошо вы понимаете эмоции", "/images/eq.jpg", "Тест на эмоциональный интеллект" },
                    { 6, "Личность", "Оценка уровня самооценки", "/images/selfesteem.jpg", "Тест на самооценку" },
                    { 7, "Работа", "Оценка профессионального выгорания", "/images/burnout.jpg", "Тест на выгорание" },
                    { 8, "Тревога", "Ситуативная и личностная тревожность", "/images/spilberger.jpg", "Тест на тревожность Спилбергера" },
                    { 9, "Стресс", "Как вы справляетесь со стрессом", "/images/coping.jpg", "Тест на копинг-стратегии" },
                    { 10, "Настроение", "Насколько вы счастливы", "/images/happiness.jpg", "Тест на уровень счастья" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_TestId",
                table: "TestResults",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Meditations");

            migrationBuilder.DropTable(
                name: "TestResults");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
