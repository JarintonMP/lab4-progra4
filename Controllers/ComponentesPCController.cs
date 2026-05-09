using lab_4_Jarinton.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab_4_Jarinton.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentesPCController : ControllerBase
    {
        private static List<ComponentePC> componentes = new List<ComponentePC>
        {
            new ComponentePC
            {
                Id = 1,
                Nombre = "Ryzen 5 5600G",
                Categoria = "Procesador",
                Precio = 120000,
                Disponible = true
            },

            new ComponentePC
            {
                Id = 2,
                Nombre = "RTX 4060",
                Categoria = "Tarjeta Gráfica",
                Precio = 350000,
                Disponible = true
            },

            new ComponentePC
            {
                Id = 3,
                Nombre = "Corsair 16GB DDR4",
                Categoria = "Memoria RAM",
                Precio = 45000,
                Disponible = false
            }
        };

        // GET: api/ComponentesPC
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(componentes);
        }

        // GET por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var componente = componentes.FirstOrDefault(c => c.Id == id);

            if (componente == null)
            {
                return NotFound();
            }

            return Ok(componente);
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromBody] ComponentePC nuevoComponente)
        {
            componentes.Add(nuevoComponente);

            return Ok("Componente agregado correctamente");
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var componente = componentes.FirstOrDefault(c => c.Id == id);

            if (componente == null)
            {
                return NotFound();
            }

            componentes.Remove(componente);

            return Ok("Componente eliminado");
        }
    }
}
