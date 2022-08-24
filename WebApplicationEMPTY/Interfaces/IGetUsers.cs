using System.Collections.Generic;
using WebApplicationEMPTY.Model;

namespace WebApplicationEMPTY.Interfaces
{
    public interface IGetUsers
    {
        public List<User> GetUsers();
        public User GetUserId(int UserId);
        
    }
}
