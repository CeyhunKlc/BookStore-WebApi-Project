using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperation.Commands.DeleteAuthor
{ 
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDBContext  _dbContext;
        public int AuthorId {get; set;}

        public DeleteAuthorCommand(BookStoreDBContext dBContext, BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        { 
            var author = _dbContext.Books.SingleOrDefault(x => x.Id == AuthorId);
            if (author == null)
                throw new InvalidOperationException("Silinecek Yazar Bulunamadı!");


            _dbContext.Books.Remove(author);
            _dbContext.SaveChanges();  
        }
    }    
}        