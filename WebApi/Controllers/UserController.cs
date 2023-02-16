using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;
using WebApi.UserOperations.Commands.CreateToken;
using WebApi.UserOperations.Commands.CreateUser;
using static WebApi.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
         readonly IBookStoreDbContext _context;
         readonly IMapper _mapper ;
         readonly IConfiguration _configuration ;
        
         public UserController( BookStoreDBContext context, IConfiguration configuration, IMapper mapper)
         {
            _context = context;
            _mapper = mapper; 
            _configuration = configuration;  
         }


         [HttpPost]
         public IActionResult Create([FromBody] CreateUserModel newUser)
         {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = newUser;
            command.Handle();
            return Ok();
         }

         [HttpPost]
         public ActionResult<Token> CreateToken([FromBody]CreateTokenModel login)
         {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper,_configuration);
            command.Model=login;
            var token = command.Handle();
            return token;
         }

    }
}