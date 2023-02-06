using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using webApi.Application.GenreOperations.CreateGenre;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private BookStoreDBContext context;

        public CreateBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CreateBookCommand(BookStoreDBContext context)
        {
            this.context = context;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book is not null)
                throw new InvalidOperationException("Kitap Zaten Mevcut.");

            book =_mapper.Map<Book>(Model);  
          
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }

            public static implicit operator CreateBookModel(CreateGenreModel v)
            {
                throw new NotImplementedException();
            }
        }
    }
}
