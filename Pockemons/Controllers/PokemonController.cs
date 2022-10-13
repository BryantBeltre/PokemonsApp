using Application.Services;
using Application.ViewModel;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pockemons.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonServices;

        public PokemonController(ApplicationContext dbContext)
        {
            _pokemonServices = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonServices.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SavePokemon", new SavePokemon());
        }

        [HttpPost]
        public async Task <IActionResult> Create(SavePokemon sp)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon",sp);
            }

            await _pokemonServices.AddPokemon(sp);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });            
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SavePokemon", await _pokemonServices.GetByIdSavePokemon(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemon sp)
        {
            await _pokemonServices.UpdatePokemon(sp);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pokemonServices.GetByIdSavePokemon(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonServices.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

    }
}
