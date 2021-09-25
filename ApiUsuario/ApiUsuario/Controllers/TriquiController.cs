using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Controllers
{
    public class TriquiController : Controller
    {
        [Route("api/[controller]")]
        [HttpPost]
        public ActionResult Winer(Models.Triqui Triqui)
        {

            if (Triqui.winer == null) { 
             
                ModelState.AddModelError("Name", "Debe ingresar el nombre del jugador");
                return BadRequest(ModelState);
            }

            try
            {
                Models.Triqui winer = new Models.Triqui();
                winer.winer = Triqui.winer;
                Models.CARVAJALContext.winer.Add(winer);
                Models.CARVAJALContext.winer.SaveChanges();

            }
            catch
            {
                return View();
            }
            return Ok();
        }

        
    }
}
