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
    public class SearchGameController : ApiController
    {
        private GameWebDbContext db = new GameWebDbContext();


        //Szukaj gre po nazwie X (POST)
        [ResponseType(typeof(Game))]
        public IHttpActionResult PostGame(Game game)
        {
            Game result = db.Games.FirstOrDefault(i => i.Name == game.Name);
            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.Id == id) > 0;
        }
    }
}