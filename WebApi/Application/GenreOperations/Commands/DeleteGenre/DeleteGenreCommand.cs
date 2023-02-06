using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace webApi.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        
        private readonly IBookStoreDbContext _context;
        public DeleteGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        { 
            var Genre =_context.Genres.SingleOrDefault(x=> x.Id==GenreId);
            if(Genre is null)
             throw new InvalidOperationException("Kitap Türü Bulunamadı!");

            _context.Genres.Remove(Genre);
            _context.SaveChanges(); 
        }
    }
}    