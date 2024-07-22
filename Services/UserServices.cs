using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : IUserServices
    {
        public void AddNewUser(User user)
        => UserDAO.AddNewUser(user);

        public void DeleteUser(int id)
        => UserDAO.DeleteUser(id);

        public User GetUserByCCCD(string cccd)
        => UserDAO.GetUserByCCCD(cccd);

        public User GetUserByEmail(string email)
       => UserDAO.GetUserByEmail(email);

        public User GetUserById(int id)
        => UserDAO.GetUserById(id);

        public List<User> GetUserList()
        => UserDAO.GetUserList();

        public List<User> SearchUser(string keyword)
        => UserDAO.SearchUser(keyword);

        public void UpdateUsers(User user)
        => UserDAO.UpdateUsers(user);
    }
}
