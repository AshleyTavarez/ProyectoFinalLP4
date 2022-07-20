using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Recetas.Controllers
{
    public class FavoritesController : ApiController
    {

        private Recetas.RecetasEntities4 _context = new Recetas.RecetasEntities4();

        // GET: api/Favorites
        public IEnumerable<Recetas.Favorite> Get()
        {
            var list = _context.Favorites.ToList().Select(x => new Recetas.Favorite { Id_Fav = x.Id_Fav, Id_recipe = x.Id_recipe, Id_User = x.Id_User}).ToList();
            return list.AsEnumerable();
        }

        // GET: api/Favorites/5
        public HttpResponseMessage Get(int id)
        {

            var FavId = _context.Favorites.ToList().Select(x => new Recetas.Favorite { Id_Fav = x.Id_Fav, Id_recipe = x.Id_recipe }).ToList().Find(x => x.Id_Fav == id);

            if (FavId != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, FavId);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");
            }


        }

        // POST: api/Favorites
        public IHttpActionResult Post(Favorite favorites)
        {
            _context.Favorites.Add(favorites);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = favorites.Id_Fav }, favorites);
        }

        // PUT: api/Favorites/5
        [HttpPut]
        [ResponseType(typeof(Favorite))]
        public HttpResponseMessage PutIngretient(int id, [FromBody] Favorite favorites)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");

            using (var ctx = new Recetas.RecetasEntities4())
            {
                var existingFav = ctx.Favorites.Where(s => s.Id_Fav == favorites.Id_Fav).FirstOrDefault<Favorite>();

                if (existingFav != null)
                {
                    existingFav.Id_Fav = favorites.Id_Fav;
                    existingFav.Id_recipe = favorites.Id_recipe;
                    existingFav.Id_User = favorites.Id_User;
                    
                    

                    ctx.SaveChanges();

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");
                }

                var FavId = _context.Favorites.Find(id);


                return Request.CreateResponse(HttpStatusCode.OK, FavId);

            }
        }

        // DELETE: api/Favorites/5
        [HttpDelete]
        [ResponseType(typeof(Favorite))]
        public IHttpActionResult Delete(int id)
        {
            Favorite favorites = _context.Favorites.Find(id);

            if (favorites == null)
            {
                return NotFound();

            }

            _context.Favorites.Remove(favorites);
            _context.SaveChanges();

            return Ok(favorites);
        }
    }
}
