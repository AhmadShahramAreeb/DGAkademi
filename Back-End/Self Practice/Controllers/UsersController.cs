using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UsersManagement.Fake;
using UsersManagement.Models;

namespace UsersManagement.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private List<User> _users = FakeData.GetUsers(10);

        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(c => c.Id == id);
            return user;
        }
        [HttpPost]
        public User Post([FromBody]User user)
        {
            _users.Add(user);
            return user;
        }

        [HttpPut]
        public User Put([FromBody]User user)
        {
            var editedUser= _users.FirstOrDefault(c=>c.Id==user.Id);
            editedUser.FirstName=user.FirstName;
            editedUser.LastName=user.LastName;
            editedUser.Adress=user.Adress;
            return user;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var editedUser= _users.FirstOrDefault(c => c.Id ==id);
            _users.Remove(editedUser);
        }
    }
}
