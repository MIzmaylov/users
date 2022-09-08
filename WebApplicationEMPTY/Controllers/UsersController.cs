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
        private DBUsers dbUsers = new DBUsers();


        [HttpGet("/api/users/")]
        public async Task<IActionResult> GetListUsers()
        {
            return Json(dbUsers.GetListUsers());
           }


        [HttpGet("/api/users/{id:int}")]
        public async Task<IActionResult> GetUserId (int id)
        {
           return Json(dbUsers.GetUserId(id));
        }


        [HttpDelete("/api/users/{id:int}")] 
        public async Task<IActionResult> DeleteUser(int id)

        {
           return Json(dbUsers.DeleteUser(id));
        }




        [HttpPost("/users/api/")]
        public  async Task<IActionResult> PostUser ([FromBody]User user)
        {
            dbUsers.AddUser(user);
            return Json(user);
           
        }

        [HttpPut("users/api/users")]
        public async Task<IActionResult> PutUser([FromBody] User userData)
        {
            return Json(dbUsers.PutUser(userData));

        }
        public IActionResult crudusers()
        {
            
            return View();
        }













    }
}
