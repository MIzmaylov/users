using System.Collections.Generic;
using System.Linq;
using WebApplicationEMPTY.ApplicationContext1;
using WebApplicationEMPTY.Interfaces;
using WebApplicationEMPTY.Model;

namespace WebApplicationEMPTY.Repository
{
    public class DBUsers
    {
        private ApplicationContext db = new ApplicationContext();
        
        public List<User> GetUsers()
        {
            var users = db.users.ToList();
            return users;


            
        }

        public void AddUser(User user)
        {
            db.users.AddRange(user);
            db.SaveChanges();
        }



        public User GetUserId(int UserId)
        {
           

            User _user = null;
            for (int i = 0; i < GetUsers().Count; i++)
            {
                
                if (GetUsers()[i].id == UserId)
                {
                    return GetUsers()[i];
                } 
                GetUsers()[i] = _user;



            }

            return _user;

        }

       
    }


}
