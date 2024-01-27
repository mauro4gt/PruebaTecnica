using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Datos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServicioController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Servicio> lista = _db.Servicio;

            return View(lista);
        }
        //Get
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _db.Servicio.Add(servicio);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(servicio);
        }

        //Get Edit
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Servicio.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _db.Servicio.Update(servicio);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(servicio);
        }
        //Get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Servicio.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Servicio servicio)
        {
            if (servicio == null)
            {
                return NotFound();
            }
            _db.Servicio.Remove(servicio);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
