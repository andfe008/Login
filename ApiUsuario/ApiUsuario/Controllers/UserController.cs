using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            using (Models.CARVAJALContext db = new Models.CARVAJALContext())
            {
                var lis = (from x in db.Usuarios select x).ToList();
                return Ok(lis);
            }

        }


        [HttpPost]
        public IActionResult Post([FromBody] Models.Usuario model)
        {
            try
            {
                using (Models.CARVAJALContext db = new Models.CARVAJALContext())
                {

                    Models.Usuario user = new Models.Usuario();
                    user.Nombre = model.Nombre;
                    user.Apellido = model.Apellido;
                    user.Telefono = model.Telefono;
                    user.Correo = model.Correo;
                    user.Contraseña = model.Contraseña;
                    user.Usuario1 = model.Usuario1;
                    user.IdTipoDocumento = model.IdTipoDocumento;
                    db.Usuarios.Add(user);
                    db.SaveChanges();

                }

            }
            catch (Exception)
            {

                throw;
            }


            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromBody] Models.Usuario model)
        {

            try
            {

                using (Models.CARVAJALContext db = new Models.CARVAJALContext())
                {

                    Models.Usuario edit = db.Usuarios.Find(model.Id);
                    edit.Nombre = model.Nombre;
                    edit.Apellido = model.Apellido;
                    edit.Telefono = model.Telefono;
                    edit.Correo = model.Correo;
                    edit.Contraseña = model.Contraseña;
                    edit.Usuario1 = model.Usuario1;
                    edit.IdTipoDocumento = model.IdTipoDocumento;
                    db.Entry(edit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return Ok();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (Models.CARVAJALContext db = new Models.CARVAJALContext())
                {

                    Models.Usuario delete = db.Usuarios.Find(id);
                    db.Usuarios.Remove(delete);
                    db.SaveChanges();

                }

            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}
