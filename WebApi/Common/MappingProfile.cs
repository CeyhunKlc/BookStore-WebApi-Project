using AutoMapper;
using webApi.Application.GenreOperations.Queries.GetGenreDetail;
using webApi.Application.GenreOperations.Queries.GetGenres;
using webApi.BookOperations.GetAuthors;
using WebApi.AuthorOperations.GetAuthorDetail;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book,BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=> src.Genre.Name));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=> src.Genre.Name));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<Author,AuthorDetailViewModel>();
            CreateMap<Author,AuthorsViewModel>();
        }
    }
}