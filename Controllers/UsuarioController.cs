using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_a.Data;
using System.Runtime.InteropServices;
using api_a.Model;
using Microsoft.EntityFrameworkCore;

namespace api_a.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DataContext _context;
        public UsuarioController(DataContext context) {
            this._context = context;
        
        }
        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]        
        public async Task<ActionResult<List<Usuario>>> AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(await _context.Usuarios.ToListAsync());


        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAll(Usuario usuario)
        {
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Usuario>>> Get(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return BadRequest("Usuario não encontrado");
            }


            return Ok(await _context.Usuarios.ToListAsync());
        }



        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
