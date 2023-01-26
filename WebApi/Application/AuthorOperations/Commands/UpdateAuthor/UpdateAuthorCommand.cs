using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.BookOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDBContext _context;
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }

        public UpdateAuthorCommand(BookStoreDBContext context)
        { 
            _context = context;
        }

        public void Handle()
        { 
            var author = _context.Authors.SingleOrDefault(x=>x.Id == AuthorId);

            if(author is null)
                throw new InvalidOperationException("Yazar Bulunamadı.");

            author.Name = Model.Name == default? author.Name: Model.Name;
            author.Surname=Model.Surname==default?author.Surname:Model.Surname;
            author.DateOfBirth=Convert.ToDateTime(Model.DateOfBirth);

            _context.Authors.Update(author);
            _context.SaveChanges();   

        }

    }

    public class UpdateAuthorModel
    { 
        public string Name {get; set;}
        public string Surname{get; set;}
        public string DateOfBirth{get; set;}
    }
}