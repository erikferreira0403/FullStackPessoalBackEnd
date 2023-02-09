using Microsoft.AspNetCore.Mvc;
using ProjetoFullStackPessoal.Back.Models;
using ProjetoFullStackPessoal.Back.Repository;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStackPessoal.Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers() {

            return await _userRepository.UserList();
        }
        [HttpGet("{id}")]
        public async Task<User> GetUserById(int id)
        {

            return _userRepository.ListUserById(id); 
        }
        [HttpPost]
        public async Task<User> CreateUser([FromBody] User user)
        {
            return await _userRepository.CreateUser(user);
        }
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        [HttpPut("{id}")]
        public async Task<User> DeleteUser([FromBody] User user, int id)
        {
            user.Id = id;
            return await _userRepository.UpdateUser(user);
        }
        [HttpPost("/login")]
        public ActionResult Login(User login)
        {
            var User = _userRepository.Authenticate(login.Name, login.Password);

            if (User == null)
                return BadRequest(new { message = "Esse usuário não aexiste" });

            return Ok(User);
        }
    }
}
