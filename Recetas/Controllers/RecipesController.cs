using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Recetas.Controllers
{
    public class RecipesController : ApiController
    {
        // GET: api/Recipes

        private Recetas.RecetasEntities4 _context = new Recetas.RecetasEntities4();

        public IEnumerable<Recetas.Recipe> Get()
        {
            var list = _context.Recipes.ToList().Select(x => new Recetas.Recipe { Id_recipe = x.Id_recipe, Nombre = x.Nombre, Descripcion = x.Descripcion, Id_Categoria = x.Id_Categoria, Id_Ingredientes = x.Id_Ingredientes, Calories = x.Calories, Carbs = x.Carbs, Fat = x.Fat, Protein = x.Protein, Ingredientes = x.Ingredientes }).ToList();
            return list.AsEnumerable();
        }

        // GET: api/Recipes/5
        [ResponseType(typeof(Recipe))]
        public HttpResponseMessage GetById(int id)
        {
            var ReId = _context.Recipes.ToList().Select(x => new Recetas.Recipe { Id_recipe = x.Id_recipe, Nombre = x.Nombre, Descripcion = x.Descripcion, Id_Categoria = x.Id_Categoria, Id_Ingredientes = x.Id_Ingredientes, Calories = x.Calories, Carbs = x.Carbs, Fat = x.Fat, Protein = x.Protein }).ToList().Find(x => x.Id_recipe == id);

            if (ReId != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ReId);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");
            }
        }

        // POST: api/Recipes
        [HttpPost]

        [ResponseType(typeof(Recipe))]
        public IHttpActionResult Post(Recipe recipes)
        {
            _context.Recipes.Add(recipes);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = recipes.Id_recipe }, recipes);
        }
    

        // PUT: api/Recipes/5
        [HttpPut]
        [ResponseType(typeof(Recipe))]
        public HttpResponseMessage Put(int id, [FromBody] Recipe recipes)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");

            using (var ctx = new Recetas.RecetasEntities4())
            {
                var existingRecipe = ctx.Recipes.Find(id);

                if (existingRecipe != null)
                {
                    existingRecipe.Id_recipe = recipes.Id_recipe;
                    existingRecipe.Nombre = recipes.Nombre;
                    existingRecipe.Descripcion = recipes.Descripcion;
                    existingRecipe.Id_Categoria = recipes.Id_Categoria;
                    existingRecipe.Id_Ingredientes = recipes.Id_Ingredientes;
                    existingRecipe.Preptime = recipes.Preptime;
                    existingRecipe.Cooktime = recipes.Cooktime;
                    existingRecipe.ReadyIn = recipes.ReadyIn;
                    
                    existingRecipe.Calories = recipes.Calories;
                    existingRecipe.Fat = recipes.Fat;
                    existingRecipe.Carbs = recipes.Carbs;
                    existingRecipe.Protein = recipes.Protein;

                    ctx.SaveChanges();

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");

                }

                var ReId = _context.Recipes.Find(id);

                return Request.CreateResponse(HttpStatusCode.OK, ReId);
            }
        }

        // DELETE: api/Recipes/5
        [HttpDelete]
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult Delete(int id)
        {
            Recipe recipes = _context.Recipes.Find(id);

            if (recipes == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipes);
            _context.SaveChanges();

            return Ok(recipes);


        }
    }
}
