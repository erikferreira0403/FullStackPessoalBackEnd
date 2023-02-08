using ProjetoFullStackPessoal.Back.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStackPessoal.Back.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> UserList();
        User ListUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user );
        bool DeleteUser(int id);
        Task<bool> Login(string name, string password);
    }
}
