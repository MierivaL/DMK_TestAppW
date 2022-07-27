using DMK_TestAppW.Models;
using Microsoft.EntityFrameworkCore;

namespace DMK_TestAppW
{

    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("MyPersonalConnect");

            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book { BookId=1, Title="Властелин колец"},
                    new Book { BookId=2, Title="Гордость и предубеждение"},
                    new Book { BookId=3, Title="Тёмные начала"},
                    new Book { BookId=4, Title="Автостопом по галактике"},
                    new Book { BookId=5, Title="Гарри Поттер и Кубок огня"},
                    new Book { BookId=6, Title="Убить пересмешника"},
                    new Book { BookId=7, Title="Винни Пух"},
                    new Book { BookId=8, Title="1984"},
                    new Book { BookId=9, Title="Лев, колдунья и платяной шкаф"},
                    new Book { BookId=10, Title="Джейн Эйр"},
                    new Book { BookId=11, Title="Уловка-22"},
                    new Book { BookId=12, Title="Грозовой перевал"},
                    new Book { BookId=13, Title="Пение птиц"},
                    new Book { BookId=14, Title="Ребекка"},
                    new Book { BookId=15, Title="Над пропастью во ржи"},
                    new Book { BookId=16, Title="Ветер в ивах"},
                    new Book { BookId=17, Title="Большие надежды"},
                    new Book { BookId=18, Title="Маленькие женщины"},
                    new Book { BookId=19, Title="Мандолина капитана Корелли[en]"},
                    new Book { BookId=20, Title="Война и мир"},
                    new Book { BookId=21, Title="Унесённые ветром"},
                    new Book { BookId=22, Title="Гарри Поттер и философский камень"},
                    new Book { BookId=23, Title="Гарри Поттер и Тайная комната"},
                    new Book { BookId=24, Title="Гарри Поттер и узник Азкабана"},
                    new Book { BookId=25, Title="Хоббит, или Туда и обратно"},
                    new Book { BookId=26, Title="Тэсс из рода д’Эрбервиллей"},
                    new Book { BookId=27, Title="Миддлмарч[en]"},
                    new Book { BookId=28, Title="Молитва об Оуэне Мини"},
                    new Book { BookId=29, Title="Гроздья гнева"},
                    new Book { BookId=30, Title="Алиса в Стране чудес"},
                    new Book { BookId=31, Title="Дневник Трейси Бикер[en]"},
                    new Book { BookId=32, Title="Сто лет одиночества"},
                    new Book { BookId=33, Title="Столпы Земли"},
                    new Book { BookId=34, Title="Дэвид Копперфильд"},
                    new Book { BookId=35, Title="Чарли и шоколадная фабрика"},
                    new Book { BookId=36, Title="Остров сокровищ"},
                    new Book { BookId=37, Title="Город как Элис[en]"},
                    new Book { BookId=38, Title="Доводы рассудка"},
                    new Book { BookId=39, Title="Дюна"},
                    new Book { BookId=40, Title="Эмма"},
                });
            modelBuilder.Entity<User>()
                .HasMany<Book>(s => s.Books)
                .WithMany(c => c.Users)
                .UsingEntity(j => j.ToTable("UserBooks"));
        }
    }
}