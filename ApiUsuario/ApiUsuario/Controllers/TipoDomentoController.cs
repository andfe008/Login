using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Controllers
{
    public class TipoDomentoController : Controller
    {
        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult List()
        {
            try
            {
                using (Models.CARVAJALContext db = new Models.CARVAJALContext())
                {
                    var lis = (from x in db.TipoDocumentos select x).ToList();
                    return Ok(lis);
                }
            }
            catch
            {
                return View();
            }
        }

       
        
    }
}
