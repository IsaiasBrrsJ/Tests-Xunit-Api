using Microsoft.AspNetCore.Mvc;
using WebApiAndTestsxUnit.Domain.Model.User;

namespace WebApiAndTestsxUnit.Controllers.Auth
{
    [ApiController]
    [Route("Login/Auth")]
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm] User user)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if(user.UserName == "isaias" && user.Password == "1234")
            {
                var key = Application.Services.GenerateToke();

                return Ok(new { Key = key });
            }

            else
            {
                return BadRequest();    
            }

         


        }
    }
}
