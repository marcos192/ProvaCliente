using Microsoft.AspNetCore.Mvc;
using Prova.Data;
using Prova.Models;

namespace Prova.Controllers
{
    public class ClientesController : Controller
    {
        public readonly AppCont _appCont;

        public ClientesController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            var alltask = _appCont.Clientes.ToList();
            return View(alltask);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Endereco,")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(cliente);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _appCont.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
    }
}
