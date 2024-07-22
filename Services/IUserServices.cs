using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserServices
    {
        void AddNewUser(User user);
        User GetUserByCCCD(string cccd);
        User GetUserByEmail(string email);
        User GetUserById(int id);

        List<User> GetUserList();

        void DeleteUser(int id);

        List<User> SearchUser(string keyword);
        void UpdateUsers(User user);
    }
}
