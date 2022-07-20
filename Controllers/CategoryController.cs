using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Recetas.Controllers
{
    public class CategoryController : ApiController
    {
        // GET: api/Category
        private Recetas.RecetasEntities4 _context = new Recetas.RecetasEntities4();

        public IEnumerable<Recetas.Category> Get()
        {
            var list = _context.Categories.ToList().Select(x => new Recetas.Category { Id_Categoria = x.Id_Categoria, Nombre = x.Nombre }).ToList();

            return list.AsEnumerable();
        }


        // GET: api/Category/5
        public HttpResponseMessage Get(int id)
        {

            var CateId = _context.Categories.ToList().Select(x => new Recetas.Category { Id_Categoria = x.Id_Categoria, Nombre = x.Nombre }).ToList().Find(x => x.Id_Categoria == id);

            if (CateId != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, CateId);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");
            }
        }



        // POST: api/Category
        [HttpPost]
        public IHttpActionResult Post(Category categories)
        {
            _context.Categories.Add(categories);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = categories.Id_Categoria }, categories);

        }

        // PUT: api/Category/5
        [HttpPut]
        [ResponseType(typeof(Category))]
        public HttpResponseMessage PutCategory(int id, [FromBody] Category categories)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");

            using (var ctx = new Recetas.RecetasEntities4())
            {
                var existingCategory = ctx.Categories.Where(s => s.Id_Categoria == categories.Id_Categoria).FirstOrDefault<Category>();

                if (existingCategory != null)
                {
                    existingCategory.Id_Categoria = categories.Id_Categoria;
                    existingCategory.Nombre = categories.Nombre;

                    ctx.SaveChanges();

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");
                }

                var CaId = _context.Categories.Find(id);


                return Request.CreateResponse(HttpStatusCode.OK, CaId);

            }
        }

        // DELETE: api/Category/5
        [HttpDelete]
        [ResponseType(typeof(Category))]
        public IHttpActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }

    }
  
}

