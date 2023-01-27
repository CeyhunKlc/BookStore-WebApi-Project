using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperation.Commands.DeleteAuthor
{ 
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDBContext  _Context;
        public int AuthorId {get; set;}

        public DeleteAuthorCommand(BookStoreDBContext Context)
        {
            _Context = Context;
        }

        public void Handle()
        { 
            var author = _Context.Books.SingleOrDefault(x => x.Id == AuthorId);
            if (author == null)
                throw new InvalidOperationException("Silinecek Yazar Bulunamadı!");


            _Context.Books.Remove(author);
            _Context.SaveChanges();  
        }
    }    
}        