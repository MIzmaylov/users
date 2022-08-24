using System.Collections.Generic;

namespace WebApplicationEMPTY.Model
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        

    }

    //public class UserRepository
    //{
    //    public List<User> GetUsers()
    //    {
    //        return new List<User>()
    //        {
    //            new User { Id = 1, Name = "Admin", PhoneNumber = "8-915-660-98-87" },
    //            new User { Id = 2, Name = "SomeAdmin", PhoneNumber = "8-916-666-96-86" }
    //        };
    //    }
    //}
}
