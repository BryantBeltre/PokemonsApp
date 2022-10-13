using Application.Services;
using Application.ViewModel;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pockemons.Controllers
{
    public class RegionController : Controller
    {

        private readonly RegionService _regionService;

        public RegionController(ApplicationContext DbContext)
        {
            _regionService = new(DbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _regionService.GetAllRegioViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveRegion", new SaveRegion());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRegion sr)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", sr);
            }

            await _regionService.AddRegion(sr);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await _regionService.GetRegionById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegion sr)
        {
            await _regionService.UpdateRegion(sr);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _regionService.GetRegionById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionService.DeleteRegion(id);
            return RedirectToRoute(new { controller = "Region", action = "Index" });

        }

        


    }
}