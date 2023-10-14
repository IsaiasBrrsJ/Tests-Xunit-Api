using Microsoft.AspNetCore.Mvc;
using WebApiAndTestsxUnit.Domain.Model.User;
using WebApiAndTestsxUnit.Infrastructure.Repositories;

namespace WebApiAndTestsxUnit.Controllers.Users
{
    [ApiController]
    [Route("Api/User")]
    public class UserController : Controller
    {

        private readonly UserRepository _userRepository;

        public UserController([FromServices] UserRepository repository)
        {
            _userRepository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> InsertUser([FromForm] User User)
        {
            _userRepository.Add(User);

            var user =  _userRepository.Get(User.Id);


            return Created("Created", new {User = user});
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            var user = _userRepository.Get(Id);    

            return Ok(new { Ok = user });
        }
    }
}
