using System;
using System.Collections.Generic;
using System.Linq;

using WebApplicationEMPTY.ApplicationContext1;

using WebApplicationEMPTY.Model;

namespace WebApplicationEMPTY.Repository
{
    public class DBUsers
    {
        private ApplicationContext db = new ApplicationContext();
        
        public List<User> GetListUsers()
        {
            var users = db.users.ToList();
            return users;
        }

        public void AddUser(User user)
        {
            db.users.Add(user);
            db.SaveChanges();
        }
        
        public User GetUserId(int id)
        {
            User user = db.users.FirstOrDefault(u => u.id == id);
            // если не найден, отправляем сообщение об ошибке
            if (user == null)  throw new NotImplementedException("Пользователь не найден");

            return user;
        }

        public User DeleteUser(int id)
        {
            User? user = db.users.FirstOrDefault(u => u.id == id);

            // если не найден, отправляем сообщение об ошибке
            if (user == null) throw new NotImplementedException("Пользователь не найден");

            // если пользователь найден, удаляем его
            db.users.Remove(user);
            db.SaveChanges();
            return user;
        }

        public User PutUser(User userData)
        {
            var user = db.users.FirstOrDefault(u => u.id == userData.id);

            // если не найден, отправляем  сообщение об ошибке
            if (user == null) throw new NotImplementedException("Пользователь не найден");

            // если пользователь найден, изменяем его данные и отправляем обратно клиенту
            user.phonenumber = userData.phonenumber;
            user.name = userData.name;
            db.SaveChanges();
            return user;
        }
    }


}
