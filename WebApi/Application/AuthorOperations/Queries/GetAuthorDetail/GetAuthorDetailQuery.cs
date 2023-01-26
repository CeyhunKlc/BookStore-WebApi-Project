using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(BookStoreDBContext dBContext, IMapper mapper, BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle();
        { 
            var author = _dbContext.Authors.Include(x=>x.)

        }
    }

    public class AuthorDetailViewModel
    { 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
    }     

}