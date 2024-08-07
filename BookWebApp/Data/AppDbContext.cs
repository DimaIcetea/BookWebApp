﻿using BookWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        // Коннект таблиц
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<PublishersAuthors> PublishersAuthors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("authors");
            var authors = Enumerable.Range(1, 500).Select(i => new Author { Id = i, Name = "Автор " + i });
            var publishers = new Publisher[]
            {
                new() { Id = 1, Name = "Издательство ООО \"Beautiful\"" },
                new() { Id = 2, Name = "Издательство ООО \"Summer\"" }
            };
            modelBuilder.Entity<Author>(b =>
            {
                b.HasKey(a => a.Id);
                b.HasIndex(b => b.Name).IsUnique();
                b.HasData(authors);

                b.HasMany(a => a.Books)
                    .WithOne(b => b.Author);
            });
            modelBuilder.Entity<Book>(b =>
            {
                b.HasData(
                    new()
                    {
                        Id = 3,
                        AuthorId = 1,
                        Title = "Первая книга Васи",
                        ImageUrl = "123",
                        Description = "Биографическое описание жизни",

                    },
                    new()
                    {
                        Id = 4,
                        AuthorId = 1,
                        Title = "Вторая книга Васи",
                        ImageUrl = "123",
                        Description = "Фантастическая книга о приключениях",
                    },
                    new()
                    {
                        Id = 5,
                        AuthorId = 1,
                        Title = "Третья книга Васи",
                        ImageUrl = "123",
                        Description = "Историческая книга",

                    },
                    new()
                    {
                        Id = 6,
                        AuthorId = 2,
                        Title = "Первая книга Пети",
                        ImageUrl = "123",
                        Description = "Фентази об эльфах",
                    },
                    new()
                    {
                        Id = 7,
                        AuthorId = 2,
                        Title = "Вторая книга Пети",
                        ImageUrl = "123",
                        Description = "Научная литература, докозательство 3-й теорему Фихтенгольца",
                    },
                    new()
                    {
                        Id = 8,
                        AuthorId = 2,
                        Title = "Третья книга Пети",
                        ImageUrl = "123",
                        Description = "Научная фантастика и приключение героя в далёком космосе",

                    });
                modelBuilder.Entity<BookDetails>(b =>
                {
                    b.HasKey(d => d.BookId);
                    b.HasOne(d => d.Book);
                    b.HasData(
                      new()
                      {
                          BookId = 3,
                          Year = new DateTime(2000, 1, 1),
                          Genre = GenreEnum.historical,
                          HardcoverCost = 100,
                          Illustrator = "МИКЕЛАНДЖЕЛО",
                          Editor = "Не известен",
                          Language = LanguageEnum.ru,
                          PageCount = 100,
                          ReadingAge = 18,
                          Rank = 7.112
                      },
                      new()
                      {
                          BookId = 4,
                          Year = new DateTime(2001, 1, 1),
                          Genre = GenreEnum.fantastic,
                          HardcoverCost = 110,
                          Illustrator = "ЙОХАННЕС ВЕРМЕЕР",
                          Editor = "Не известен",
                          Language = LanguageEnum.ua,
                          PageCount = 200,
                          ReadingAge = 12,
                          Rank = 4.343
                      },
                      new()
                      {
                          BookId = 5,
                          Year = new DateTime(2002, 1, 1),
                          Genre = GenreEnum.historical,
                          HardcoverCost = 120,
                          Illustrator = "ПАБЛО ПИКАССО",
                          Editor = "Не известен",
                          Language = LanguageEnum.ru,
                          PageCount = 300,
                          ReadingAge = 10,
                          Rank = 9.2
                      },
                      new()
                      {
                          BookId = 6,
                          Year = new DateTime(2003, 1, 1),
                          Genre = GenreEnum.fantasy,
                          HardcoverCost = 130,
                          Illustrator = "ВИНСЕНТ ВАН ГОГ",
                          Editor = "Не известен",
                          Language = LanguageEnum.ua,
                          PageCount = 400,
                          ReadingAge = 5,
                          Rank = 8.345
                      },
                      new()
                      {
                          BookId = 7,
                          Year = new DateTime(2004, 1, 1),
                          Genre = GenreEnum.scientific,
                          HardcoverCost = 140,
                          Illustrator = "РЕМБРАНДТ ВАН РЕЙН",
                          Editor = "Не известен",
                          Language = LanguageEnum.en,
                          PageCount = 500,
                          ReadingAge = 10,
                          Rank = 1
                      },
                      new()
                      {
                          BookId = 8,
                          Year = new DateTime(2005, 1, 1),
                          Genre = GenreEnum.fantastic,
                          HardcoverCost = 150,
                          Illustrator = "ЛЕОНАРДО ДА ВИНЧИ",
                          Editor = "Не известен",
                          Language = LanguageEnum.ua,
                          PageCount = 600,
                          ReadingAge = 18,
                          Rank = 5
                      }
                      );
                });
                modelBuilder.Entity<Publisher>(b =>
                {
                    b
                        .HasMany(p => p.Authors)
                        .WithMany(a => a.Publishers)
                        .UsingEntity<PublishersAuthors>(
                            author => author
                                .HasOne(pa => pa.Author)
                                .WithMany(a => a.PublishersAuthors)
                                .HasForeignKey(pa => pa.AuthorId),
                            publisher => publisher
                                .HasOne(pa => pa.Publisher)
                                .WithMany(p => p.PublishersAuthors)
                                .HasForeignKey(pa => pa.PublisherId)
                        );

                    b.HasData(publishers);
                });
                modelBuilder.Entity<PublishersAuthors>(b =>
                {
                    b.HasData(
                        new() { PublisherId = 1, AuthorId = 1 },
                        new() { PublisherId = 1, AuthorId = 2 },
                        new() { PublisherId = 2, AuthorId = 1 }
                    );
                });
            });
        }
    }
}
