using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMK_TestAppW.Migrations
{
    public partial class idNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BooksBookId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_BookUser_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Title" },
                values: new object[,]
                {
                    { 1, "Властелин колец" },
                    { 2, "Гордость и предубеждение" },
                    { 3, "Тёмные начала" },
                    { 4, "Автостопом по галактике" },
                    { 5, "Гарри Поттер и Кубок огня" },
                    { 6, "Убить пересмешника" },
                    { 7, "Винни Пух" },
                    { 8, "1984" },
                    { 9, "Лев, колдунья и платяной шкаф" },
                    { 10, "Джейн Эйр" },
                    { 11, "Уловка-22" },
                    { 12, "Грозовой перевал" },
                    { 13, "Пение птиц" },
                    { 14, "Ребекка" },
                    { 15, "Над пропастью во ржи" },
                    { 16, "Ветер в ивах" },
                    { 17, "Большие надежды" },
                    { 18, "Маленькие женщины" },
                    { 19, "Мандолина капитана Корелли[en]" },
                    { 20, "Война и мир" },
                    { 21, "Унесённые ветром" },
                    { 22, "Гарри Поттер и философский камень" },
                    { 23, "Гарри Поттер и Тайная комната" },
                    { 24, "Гарри Поттер и узник Азкабана" },
                    { 25, "Хоббит, или Туда и обратно" },
                    { 26, "Тэсс из рода д’Эрбервиллей" },
                    { 27, "Миддлмарч[en]" },
                    { 28, "Молитва об Оуэне Мини" },
                    { 29, "Гроздья гнева" },
                    { 30, "Алиса в Стране чудес" },
                    { 31, "Дневник Трейси Бикер[en]" },
                    { 32, "Сто лет одиночества" },
                    { 33, "Столпы Земли" },
                    { 34, "Дэвид Копперфильд" },
                    { 35, "Чарли и шоколадная фабрика" },
                    { 36, "Остров сокровищ" },
                    { 37, "Город как Элис[en]" },
                    { 38, "Доводы рассудка" },
                    { 39, "Дюна" },
                    { 40, "Эмма" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UsersUserId",
                table: "BookUser",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
