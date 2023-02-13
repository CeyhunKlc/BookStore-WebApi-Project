using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using webApi.Application.GenreOperations.CreateGenre;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private BookStoreDBContext context;

        public CreateUserCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CreateUserCommand(BookStoreDBContext context)
        {
            this.context = context;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x=> x.Email == Model.Email);
            if(user is not null)
                throw new InvalidOperationException("Kullanıcı Zaten Mevcut.");

            user= _mapper.Map<User>(Model);    
          
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public class CreateUserModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

        }
    }
}