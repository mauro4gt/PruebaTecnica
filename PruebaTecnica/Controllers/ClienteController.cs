using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Datos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = _db.Cliente;

            return View(lista);
        }
        //Get
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Cliente.Add(cliente);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
        //Get Edit
        public IActionResult Editar(int? Id)
        {
            if (Id==null || Id==0)
            {
                return NotFound();
            }
            var obj = _db.Cliente.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Cliente.Update(cliente);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Cliente.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Cliente cliente)
        {
            if (cliente == null)
            {
                return NotFound();
            }
            _db.Cliente.Remove(cliente);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }
    }
}
