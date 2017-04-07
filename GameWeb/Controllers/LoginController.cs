using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GameWeb.Models;
using GameWeb;

namespace GameWeb.Controllers
{
    public class LoginController : ApiController
    {
        private GameWebDbContext db = new GameWebDbContext();

        // Login (POST)
        /*
        Zwraca 200 gdy podane hasło i login są zgodne, w przeciwnym wypadku zwraca 403
        */ 
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            User item = db.Users.FirstOrDefault(i => i.Login == user.Login);
            if (item.Password == user.Password)
            {
                return Ok(item);
            }
            else
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}