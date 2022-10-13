using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pockemons.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;

namespace Pockemons.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _pokemonServices;

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonServices = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonServices.GetAllViewModel());
        }

    }
}
