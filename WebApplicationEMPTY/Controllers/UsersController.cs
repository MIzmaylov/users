using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationEMPTY.Model;
using WebApplicationEMPTY.Repository;
using WebApplicationEMPTY.ApplicationContext1;
using Microsoft.EntityFrameworkCore;


namespace WebApplicationEMPTY.Controllers
{
   
    public class UsersController : Controller
    {
        ApplicationContext db;

        public UsersController(ApplicationContext context)
        {
            db = context;
        }
        // public Users _users;
   
        // public UsersController(Users users)
        // {
        //     _users = users;
        // }
        // public IActionResult Users()
        // {
        //     var usersRep = _users.GetUsers();
        //     return View(usersRep);
        // }

        //public async Task<IActionResult> Users()
        //{
        //    var users = _users.GetUsers();
        //    return View(await users);
        //}

        //[HttpGet("/users/")]
        //public IActionResult Users()
        //{
        //   var users = _users.GetUsers();
        //    return View(users);
        //}
        public IActionResult Create()
        {
           
            return View();
        }
        
         [HttpPost]
         public async Task<IActionResult> Create(User user)
         {
             await db.users.AddAsync(user);
             await db.SaveChangesAsync();
             return Ok();
         }
        //
        // [HttpPost]
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id != null)
        //     {
        //         User? user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
        //         if (user != null)
        //         {
        //             db.Users.Remove(user);
        //             await db.SaveChangesAsync();
        //             return RedirectToPage("~/home/Index.cshtml");
        //         }
        //     }
        //     return NotFound();
        // }
        //
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id != null)
        //     {
        //         User? user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
        //         if (user != null) return View(user);
        //     }
        //     return NotFound();
        // }
        // [HttpPost]
        // public async Task<IActionResult> Edit(User user)
        // {
        //     db.Users.Update(user);
        //     await db.SaveChangesAsync();
        //     return RedirectToPage("~/home/Index.cshtml");
        // }



        //public async Task<IActionResult> Users()
        //{
        //    var users = _users.GetUsers();
        //    return Json(users);
        //}

       
        [HttpGet("/api/users/")]
        public async Task<IActionResult> _Getempty(ApplicationContext db)
        {

            var GetDbItems = await db.users.ToListAsync();

            return Json(GetDbItems);
           
        }


        [HttpGet("/api/users/{id:int}")]
        public async Task<IActionResult> _Get (int id)
        {
            User user = db.users.FirstOrDefault(u => u.id == id);
            // если не найден, отправляем статусный код и сообщение об ошибке
            if (user == null) return NotFound(new { message = "Пользователь не найден" });

            // если пользователь найден, отправляем его
            return Json(user);
        }


        [HttpDelete("/api/users/{id:int}")] 
        public async Task<IActionResult> _Delete(int id, ApplicationContext db)

        {
            User? user = await db.users.FirstOrDefaultAsync(u => u.id == id);

            // если не найден, отправляем статусный код и сообщение об ошибке
            if (user == null) return NotFound(new { message = "Пользователь не найден" });

            // если пользователь найден, удаляем его
            db.users.Remove(user);
            await db.SaveChangesAsync();
            return Json(user);
        }




        [HttpPost("/users/api/")]
        public  async Task<IActionResult> _Post(User user)
        {
             db.users.Add(user);
             await db.SaveChangesAsync();
            return Json(user);
           
        }

        [HttpPut("users/api/users")]
        public async Task<IActionResult> _Put(User userData, ApplicationContext db)
        {
            var user = await db.users.FirstOrDefaultAsync(u => u.id == userData.id);

            // если не найден, отправляем статусный код и сообщение об ошибке
            if (user == null) return NotFound(new { message = "Пользователь не найден" });

            // если пользователь найден, изменяем его данные и отправляем обратно клиенту
            user.phonenumber = userData.phonenumber;
            user.name = userData.name;
            await db.SaveChangesAsync();
            return Json(user);

        }
        public IActionResult crudusers()
        {
            
            return View();
        }













    }
}
