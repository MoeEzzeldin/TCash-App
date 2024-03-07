using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IUserDao
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);
        User CreateUser(string username, string password);
        IList<User> GetUsers();
<<<<<<< HEAD
        IList<User> GetDifferentUsers();
=======
        IList<User> GetDifferentUsers(string currentUsername); 
>>>>>>> bdab6f8fceaac1ed7865c632b2269ea7d89579f0
    }
}
