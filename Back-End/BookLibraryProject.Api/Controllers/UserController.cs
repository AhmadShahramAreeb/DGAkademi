using LibraryProject.Api.Models;
using LibraryProject.Api.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJWTAuthenticaionManager jwtAuthenticationManager;

        public UserController(IJWTAuthenticaionManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]  //bu route altindaaki endpoint veya metodlari herkese erisilebilir yap

        [HttpPost("authenticate")]

        public IActionResult Authenticate([FromBody] UserCredential userCredential)
        {
            var token = this.jwtAuthenticationManager.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
    
}
