using Microsoft.AspNetCore.Mvc;
using Projekt_Back_End.Repositories;

namespace Projekt_Back_End.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthContoller : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;
        public AuthContoller(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Models.DTO.LoginRequest loginRequest)
        {
            //validate request
            if (loginRequest == null)
            {
                return NotFound();
            }
            //check if user authenticated - check username and passwd

            var user = await userRepository.AutheticateAsync(loginRequest.username, loginRequest.password);



            if (user != null)
            {
                //generate jwt token
               var token =  await tokenHandler.CreateTokenAsync(user);
                return Ok(token);

            }

            return BadRequest("Username or password is incorrect");
        }
    }
}
