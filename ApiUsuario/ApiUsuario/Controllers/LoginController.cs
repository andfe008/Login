using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Controllers
{

    [Route(("api/[controller]"))]
    [ApiController]

    public class LoginController : Controller
    {
        //porque recibe los mismos datos en un modelo ccomo parametros seprados¨?

        [HttpPost]
        public IActionResult Validate(Models.DTOModel.DTOlogin dTOloginq)
        {

            if (dTOloginq.Clave == null)
            {

                ModelState.AddModelError("Name", "Los datos no son validos");
                return BadRequest(ModelState);

            }
            try
            {

            var login = Models.CARVAJALContext.Login.Usuarios.FirstOrDefault(x => x.Usuario1 == dTOloginq.Usuario && x.Contraseña == dTOloginq.Clave);
                if (login == null)
                {

                    return NotFound();
                }

                return Ok(login);

            }
            catch (Exception)
            {

                throw;
            }

            
        }



    }
}
