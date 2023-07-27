using api_a.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using api_a.Model;
using Microsoft.EntityFrameworkCore;

namespace api_a.Controllers
{
    //[ApiController]
    //[Route("usuario")]
    public class UsuarioController : Controller
    {
        private readonly DataContext _context;
        public UsuarioController(DataContext context) {
            this._context = context;
        
        }




        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> Post([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.id }, usuario);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAll(Usuario usuario)
        {
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Usuario>>> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {0
                return NotFound("Usuario não encontrado");
            }
            return Ok(await _context.Usuarios.ToListAsync());
        }





    }
}
