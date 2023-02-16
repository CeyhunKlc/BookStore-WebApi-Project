using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using webApi.Application.AuthorOperations.CreateAuthor;
using webApi.BookOperations.GetAuthors;
using WebApi.Application.AuthorOperation.Commands.DeleteAuthor;
using WebApi.AuthorOperations.GetAuthorDetail;
using WebApi.BookOperations.UpdateAuthor;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDBContext context , IMapper mapper)
        { 
            _context= context;
            _mapper = mapper;
        }

         [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery query = new GetAuthorQuery(_context, _mapper);
            var Obj = query.Handle();
            return Ok(Obj);
        }

         [HttpGet("{id}")]
        public IActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;
            GetAuthorDetailQueryValidator validations = new GetAuthorDetailQueryValidator();
            validations.ValidateAndThrow(query);
            var Obj = query.Handle();

            return Ok(Obj);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = newAuthor;

            CreateAuthorCommandValidator validations = new CreateAuthorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok ();
        }

         [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.Model = updatedAuthor;

            UpdateAuthorCommandValidator validations = new UpdateAuthorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

         [HttpDelete("{id}")]
         public IActionResult DeleteAuthor(int id)
         { 
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validations = new DeleteAuthorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok ();
         }
    }
}        