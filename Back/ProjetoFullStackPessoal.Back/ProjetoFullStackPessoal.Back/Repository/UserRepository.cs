using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFullStackPessoal.Back.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFullStackPessoal.Back.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _data;
        public UserRepository(DatabaseContext data)
        {
            _data = data;
        }
        public User Authenticate(string name, string password)
        {
            var user = _data.Users.SingleOrDefault(x => x.Name == name && x.Password == password);
            //not found
            if (user == null)
                return null;
            //success
            return user;
        }

        public async Task<User> CreateUser(User user)
        {
           await _data.Users.AddAsync(user);
           await _data.SaveChangesAsync();
           return user;
        }

        public bool DeleteUser(int id)
        {
            User userDB = ListUserById(id);
            if (userDB == null)
                throw new System.Exception("Houve um erro na deleção do usuário");
            _data.Users.Remove(userDB);
            _data.SaveChanges();
            return true;
        }

        public User ListUserById(int id) 
        {
            return _data.Users.Find(id);
        }

        public async Task<bool> Login(string name, string password)
        {
            var login = _data.Users.Any(x => x.Name == "" && x.Password == "");
                if (login == null)
                throw new System.Exception("Houve um erro na deleção do usuário");
            return login;


        }

        public async Task<User> UpdateUser(User user)
        {
            User userDB = ListUserById(user.Id);
            if (userDB == null)
                throw new System.Exception("Houve um erro na deleção do contato");

            userDB.Name = user.Name;
            userDB.Password = user.Password;
            userDB.Role = user.Role;

            _data.Users.Update(userDB);
            _data.SaveChanges();
            return   userDB;
        }

        public async Task<IEnumerable<User>> UserList()
        {
            return await _data.Users.ToListAsync();
        }

        
    }
}
