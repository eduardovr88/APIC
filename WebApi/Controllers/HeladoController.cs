using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Data; 
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HeladoController : ApiController
    {
        // GET api/helado
        public List<Helado> Get()
        {
            return HeladoData.Listar();
        }

        // GET api/helado/5
        public Helado Get(int id)
        {
            return HeladoData.Obtener(id); 
        }

        // POST api/helado
        public bool Post([FromBody] Helado oHelado)
        {
            
            return HeladoData.Registrar(oHelado.Sabor, oHelado.Tamano, oHelado.Precio);
        }

        // PUT api/helado/5
        public bool Put(int id, [FromBody] Helado oHelado)
        {
    
            return HeladoData.Modificar(id, oHelado.Sabor, oHelado.Tamano, oHelado.Precio);
        }

        // DELETE api/helado/5
        public bool Delete(int id)
        {
           
            return HeladoData.Eliminar(id);
        }
    }
}
