using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Recetas.Controllers
{
    public class IngredientesController : ApiController
    {
        // GET: api/Ingredientes
        private Recetas.RecetasEntities4 _context = new Recetas.RecetasEntities4();
        public IEnumerable<Recetas.Ingrediente> Get()
        {
            var list = _context.Ingredientes.ToList().Select(x => new Recetas.Ingrediente { Id_Ingredientes = x.Id_Ingredientes, Nombre = x.Nombre, Medida = x.Medida, Calorias = x.Calorias, Carbs = x.Carbs, Fat = x.Fat, Protein = x.Protein}).ToList();
            return list.AsEnumerable();
        }

        // GET: api/Ingredientes/5
        public HttpResponseMessage Get(int id)
        {

            var Inid = _context.Ingredientes.ToList().Select(x => new Recetas.Ingrediente { Id_Ingredientes = x.Id_Ingredientes, Nombre = x.Nombre, Medida = x.Medida, Calorias = x.Calorias, Carbs = x.Carbs, Fat = x.Fat, Protein = x.Protein }).ToList().Find(x => x.Id_Ingredientes == id);

            if (Inid != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Inid);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");
            }
        


    }

        // POST: api/Ingredientes
        public IHttpActionResult Post(Ingrediente ingredientes)
        {
            _context.Ingredientes.Add(ingredientes);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = ingredientes.Id_Ingredientes }, ingredientes);
        }

        // PUT: api/Ingredientes/5
        [HttpPut]
        [ResponseType(typeof(Ingrediente))]
        public HttpResponseMessage PutIngretient(int id, [FromBody] Ingrediente ingredientes)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");

            using (var ctx = new Recetas.RecetasEntities4())
            {
                var existingIngredient = ctx.Ingredientes.Where(s => s.Id_Ingredientes == ingredientes.Id_Ingredientes).FirstOrDefault<Ingrediente>();

                if (existingIngredient != null)
                {
                    existingIngredient.Id_Ingredientes = ingredientes.Id_Ingredientes;
                    existingIngredient.Nombre = ingredientes.Nombre;
                    existingIngredient.Medida = ingredientes.Medida;
                    existingIngredient.Calorias = ingredientes.Calorias;
                    existingIngredient.Carbs = ingredientes.Carbs;
                    existingIngredient.Fat = ingredientes.Fat;
                    existingIngredient.Protein = ingredientes.Protein;

                    ctx.SaveChanges();

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");
                }

                var InId = _context.Ingredientes.Find(id);


                return Request.CreateResponse(HttpStatusCode.OK, InId);

            }
        }

        // DELETE: api/Ingredientes/5
        [HttpDelete]
        [ResponseType(typeof(Ingrediente))]
        public IHttpActionResult Delete(int id)
        {
            Ingrediente ingredientes = _context.Ingredientes.Find(id);

            if (ingredientes == null)
            {
                return NotFound();

            }

            _context.Ingredientes.Remove(ingredientes);
            _context.SaveChanges();

            return Ok(ingredientes);
        }
    }
}
