using Application.Services;
using Application.ViewModel;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pockemons.Controllers
{
    public class TypeController : Controller
    {

        private readonly TypeService _typeservice;

        public TypeController(ApplicationContext dbContext)
        {

            _typeservice = new(dbContext);


        }

        public async Task<IActionResult> Index()
        {
            return View(await _typeservice.GetAllTypes()) ;
        }

        public IActionResult Create()
        {
            return View("SaveType", new SaveType());

        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveType st)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveType", st);
            }

            await _typeservice.AddType(st);

            return RedirectToRoute(new {controller="Type", action="Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveType", await _typeservice.GetTypeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveType st)
        {
            await _typeservice.UpdateType(st);
            return RedirectToRoute(new {controller ="Type", action="Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _typeservice.GetTypeById(id));
                   
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _typeservice.DeleteType(id);
            return RedirectToRoute(new { controller = "Type", action = "Index" });
        }



    }
}
