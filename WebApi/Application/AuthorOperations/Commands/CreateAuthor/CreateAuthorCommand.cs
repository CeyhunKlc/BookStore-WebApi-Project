using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace webApi.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDBContext _Context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDBContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author =_Context.Authors.SingleOrDefault(x=>x.Name== Model.Name && x.Surname==Model.Surname);
            if (author is not null)
                throw new InvalidOperationException("Bu Yazar Zaten Mevcut.");

            author=_mapper.Map<Author>(Model);
            _Context.Authors.Add(author);
            _Context.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
    }
}