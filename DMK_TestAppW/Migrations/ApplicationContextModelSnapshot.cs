﻿// <auto-generated />
using DMK_TestAppW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DMK_TestAppW.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookUser", b =>
                {
                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("BooksBookId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("UserBooks", (string)null);
                });

            modelBuilder.Entity("DMK_TestAppW.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Title = "Властелин колец"
                        },
                        new
                        {
                            BookId = 2,
                            Title = "Гордость и предубеждение"
                        },
                        new
                        {
                            BookId = 3,
                            Title = "Тёмные начала"
                        },
                        new
                        {
                            BookId = 4,
                            Title = "Автостопом по галактике"
                        },
                        new
                        {
                            BookId = 5,
                            Title = "Гарри Поттер и Кубок огня"
                        },
                        new
                        {
                            BookId = 6,
                            Title = "Убить пересмешника"
                        },
                        new
                        {
                            BookId = 7,
                            Title = "Винни Пух"
                        },
                        new
                        {
                            BookId = 8,
                            Title = "1984"
                        },
                        new
                        {
                            BookId = 9,
                            Title = "Лев, колдунья и платяной шкаф"
                        },
                        new
                        {
                            BookId = 10,
                            Title = "Джейн Эйр"
                        },
                        new
                        {
                            BookId = 11,
                            Title = "Уловка-22"
                        },
                        new
                        {
                            BookId = 12,
                            Title = "Грозовой перевал"
                        },
                        new
                        {
                            BookId = 13,
                            Title = "Пение птиц"
                        },
                        new
                        {
                            BookId = 14,
                            Title = "Ребекка"
                        },
                        new
                        {
                            BookId = 15,
                            Title = "Над пропастью во ржи"
                        },
                        new
                        {
                            BookId = 16,
                            Title = "Ветер в ивах"
                        },
                        new
                        {
                            BookId = 17,
                            Title = "Большие надежды"
                        },
                        new
                        {
                            BookId = 18,
                            Title = "Маленькие женщины"
                        },
                        new
                        {
                            BookId = 19,
                            Title = "Мандолина капитана Корелли[en]"
                        },
                        new
                        {
                            BookId = 20,
                            Title = "Война и мир"
                        },
                        new
                        {
                            BookId = 21,
                            Title = "Унесённые ветром"
                        },
                        new
                        {
                            BookId = 22,
                            Title = "Гарри Поттер и философский камень"
                        },
                        new
                        {
                            BookId = 23,
                            Title = "Гарри Поттер и Тайная комната"
                        },
                        new
                        {
                            BookId = 24,
                            Title = "Гарри Поттер и узник Азкабана"
                        },
                        new
                        {
                            BookId = 25,
                            Title = "Хоббит, или Туда и обратно"
                        },
                        new
                        {
                            BookId = 26,
                            Title = "Тэсс из рода д’Эрбервиллей"
                        },
                        new
                        {
                            BookId = 27,
                            Title = "Миддлмарч[en]"
                        },
                        new
                        {
                            BookId = 28,
                            Title = "Молитва об Оуэне Мини"
                        },
                        new
                        {
                            BookId = 29,
                            Title = "Гроздья гнева"
                        },
                        new
                        {
                            BookId = 30,
                            Title = "Алиса в Стране чудес"
                        },
                        new
                        {
                            BookId = 31,
                            Title = "Дневник Трейси Бикер[en]"
                        },
                        new
                        {
                            BookId = 32,
                            Title = "Сто лет одиночества"
                        },
                        new
                        {
                            BookId = 33,
                            Title = "Столпы Земли"
                        },
                        new
                        {
                            BookId = 34,
                            Title = "Дэвид Копперфильд"
                        },
                        new
                        {
                            BookId = 35,
                            Title = "Чарли и шоколадная фабрика"
                        },
                        new
                        {
                            BookId = 36,
                            Title = "Остров сокровищ"
                        },
                        new
                        {
                            BookId = 37,
                            Title = "Город как Элис[en]"
                        },
                        new
                        {
                            BookId = 38,
                            Title = "Доводы рассудка"
                        },
                        new
                        {
                            BookId = 39,
                            Title = "Дюна"
                        },
                        new
                        {
                            BookId = 40,
                            Title = "Эмма"
                        });
                });

            modelBuilder.Entity("DMK_TestAppW.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.HasOne("DMK_TestAppW.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DMK_TestAppW.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
