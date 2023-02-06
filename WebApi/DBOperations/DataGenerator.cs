using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceprovider)
        {
            using (var context = new BookStoreDBContext(serviceprovider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Orhan Pamuk"
                    },
                    new Author
                    {
                        Name = "Yaşar Kemal"
                    },
                    new Author
                    {
                        Name = "Oğuz Atay"
                    },
                    new Author
                    {
                        Name = "Namık Kemal"
                    }
                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(
                    new Book
                    {
                        
                        Title = "Learn Startup",
                        GenreId = 1, 
                        PageCount = 200,
                        PublisDate = new DateTime(2001, 06, 12),
                    },
                    new Book
                    {
                        
                        Title = "Herland",
                        GenreId = 2, 
                        PageCount = 250,
                        PublisDate = new DateTime(2010, 05, 23),
                    },
                    new Book
                    {
                       
                        Title = "Dune",
                        GenreId = 1, 
                        PageCount = 540,
                        PublisDate = new DateTime(2001, 12, 21),
                    }
                );

                context.SaveChanges();
            }
        }
    }
}