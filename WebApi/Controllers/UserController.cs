using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;
using WebApi.UserOperations.Commands.CreateToken;
using WebApi.UserOperations.Commands.CreateUser;
using static WebApi.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace WebApi.Controllers
{
    [ApiController]
  //  [Route("[controller]s")]
    public class UserController : ControllerBase
    {
         readonly BookStoreDBContext _context;
         readonly IMapper _mapper ;
         readonly IConfiguration _configuration ;
         readonly ILogger<UserController> _logger;
         public UserController(ILogger<UserController> logger, BookStoreDBContext context, IConfiguration configuration, IMapper mapper)
         {
             _context = context;
             _configuration = configuration;
             _mapper = mapper;
             _logger = logger;
         }

        // [HttpPost]
        // [Route("[controller]s")]
        // public IActionResult Create([FromBody] CreateUserModel newUser)
        // {
        //     CreateUserCommand command = new CreateUserCommand(_context, _mapper);
        //     command.Model = newUser;
        //     command.Handle();
        //     return Ok();
        // }

        [HttpPost]
        [Route("api/user/CreateToken")]
        public ActionResult<Token> CreateToken(CreateTokenModel login)
        {
            _logger.Log(LogLevel.Information, "connect token log.");

            return new Token {
                AccessToken = login.Email
            };

            // CreateTokenCommand command = new CreateTokenCommand(_context, _mapper,_configuration);
            // command.Model=login;
            // var token = command.Handle();
            // return token;
        }
    }
}