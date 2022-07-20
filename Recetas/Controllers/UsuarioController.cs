using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Recetas.Controllers
{
    public class UsuarioController : ApiController
    {

        private Recetas.RecetasEntities4 _context = new Recetas.RecetasEntities4();
        // GET: api/Usuario
        public IEnumerable<Recetas.Usuario> Get()
        {
            return _context.Usuarios;
        }

        // GET: api/Usuario/5
        public HttpResponseMessage Get(int id)
        {

            var UserId = _context.Usuarios.Find(id);



            if (UserId != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, UserId);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");
            }


        }

        // POST: api/Usuario
        public IHttpActionResult Post(Usuario usuarios)
        {
            _context.Usuarios.Add(usuarios);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = usuarios.Id_user }, usuarios);
        }

        // PUT: api/Usuario/5
        [HttpPut]
        [ResponseType(typeof(Usuario))]
        public HttpResponseMessage PutIngretient(int id, [FromBody] Usuario usuarios)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");

            using (var ctx = new Recetas.RecetasEntities4())
            {
                var existingUser = ctx.Usuarios.Where(s => s.Id_user == usuarios.Id_user).FirstOrDefault<Usuario>();

                if (existingUser != null)
                {
                    existingUser.Id_user = usuarios.Id_user;
                    existingUser.Nombre = usuarios.Nombre;
                    existingUser.Apellido = usuarios.Apellido;
                    existingUser.Email = usuarios.Email;
                    existingUser.Password = usuarios.Password;
                    

                    ctx.SaveChanges();

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Code or Member Not Found");
                }

                var UserId = _context.Usuarios.Find(id);


                return Request.CreateResponse(HttpStatusCode.OK, UserId);

            }
        }

        // DELETE: api/Usuario/5
        [HttpDelete]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Delete(int id)
        {
            Usuario usuarios = _context.Usuarios.Find(id);

            if (usuarios == null)
            {
                return NotFound();

            }

            _context.Usuarios.Remove(usuarios);
            _context.SaveChanges();

            return Ok(usuarios);
        }
    }
}
