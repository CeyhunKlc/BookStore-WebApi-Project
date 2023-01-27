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
        private readonly BookStoreDBContext _Context;
        private readonly IMapper _mapper;

        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(BookStoreDBContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _Context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar Bulunamadı");
            return _mapper.Map<AuthorDetailViewModel>(author);
        }


    }

    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
    }

}