using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace webApi.BookOperations.GetAuthors
{ 
    public class GetAuthorQuery
    { 
        private readonly BookStoreDBContext _Context;
        private readonly IMapper _mapper;
        
        public GetAuthorQuery(BookStoreDBContext Context, IMapper mapper)
        {
            _Context=Context;
            _mapper=mapper;
        }
        public List<AuthorsViewModel> Handle()
        { 
            var authors = _Context.Authors.OrderBy(x=> x.Id);
            List<AuthorsViewModel> returnObj = _mapper.Map<List<AuthorsViewModel>>(authors);
            return returnObj;
        }

    }

    public class AuthorsViewModel
    { 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
    }
}