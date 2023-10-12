using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Data; // Asegúrate de tener una clase HeladoData que interactúe con la base de datos.
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HeladoController : ApiController
    {
        // GET api/helado
        public List<Helado> Get()
        {
            return HeladoData.Listar(); // Llama al procedimiento almacenado para listar helados
        }

        // GET api/helado/5
        public Helado Get(int id)
        {
            return HeladoData.Obtener(id); // Llama al procedimiento almacenado para obtener un helado por ID
        }

        // POST api/helado
        public bool Post([FromBody] Helado oHelado)
        {
            // Llama al procedimiento almacenado para registrar un helado
            return HeladoData.Registrar(oHelado.Sabor, oHelado.Tamano, oHelado.Precio);
        }

        // PUT api/helado/5
        public bool Put(int id, [FromBody] Helado oHelado)
        {
            // Llama al procedimiento almacenado para modificar un helado
            return HeladoData.Modificar(id, oHelado.Sabor, oHelado.Tamano, oHelado.Precio);
        }

        // DELETE api/helado/5
        public bool Delete(int id)
        {
            // Llama al procedimiento almacenado para eliminar un helado por ID
            return HeladoData.Eliminar(id);
        }
    }
}
