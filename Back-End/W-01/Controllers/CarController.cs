using CarFactory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using System;

namespace CarFactory.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private IJWTAuthenticaionManager _jwtAuthenticationManager;

        private List<Car> _cars = new List<Car>()
        {
            new BMW(){BrandName="BMW",Doors="2",Engine="2",Tiers="6"},
            new MERCEDES(){BrandName="MERCEDES",Doors="2",Engine="2",Tiers="8"},
            new AUDI(){BrandName="AUDI",Doors="5",Engine="1",Tiers="4"}
        };

        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger,
            IJWTAuthenticaionManager jwtAuthenticaionManager)
        {
            _logger = logger;
            _jwtAuthenticationManager = jwtAuthenticaionManager;
        }


        [HttpGet("bmw")]

        public Car GetBMW()
        {
            
            var bmw = _cars.FirstOrDefault(x => x.BrandName == "BMW" || x.BrandName == "bmw");
            
            return bmw;
        }

        [HttpGet("audi")]

        public Car GetAUDI()
        {
           
            var audi = _cars.FirstOrDefault(x => x.BrandName == "AUDI" || x.BrandName == "audi");

            return audi;
        }

        [HttpGet("mercedes")]

        public Car GetMERCEDES()
        {
          
            var mercedes = _cars.FirstOrDefault(x => x.BrandName == "MERCEDES" || x.BrandName == "MERCEDES");

            return mercedes;
        }



        [AllowAnonymous]  //bu route altindaaki endpoint veya metodlari herkese erisilebilir yap

        [HttpPost("authenticate")]

        public IActionResult Authenticate([FromBody] UserCredential userCredential)
        {
            var token = _jwtAuthenticationManager.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }

    public class UserCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
