using Application.Repository;
using Application.ViewModel;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonService
    {
        private readonly PokemonRepository _PokemonRepository;
        private readonly RegionRepository _RegionRepository;
        private readonly TipoRepository _TypeRepository;

        public PokemonService(ApplicationContext dbContext)
        {
            _PokemonRepository = new(dbContext);
            _RegionRepository = new(dbContext);
            _TypeRepository = new(dbContext);
        }


        public async Task UpdatePokemon(SavePokemon sp)
        {
            Pokemons pokemon = new();
            pokemon.Id = sp.Id;
            pokemon.Name = sp.Name;
            pokemon.UrlImg = sp.UrlImg;
            pokemon.IdRegion = sp.IdRegion;
            pokemon.IdTipo = sp.IdType;

            await _PokemonRepository.UpdateAsync(pokemon);
        }

        public async Task AddPokemon(SavePokemon sp)
        {
            Pokemons pokemon = new();
            pokemon.Name = sp.Name;
            pokemon.UrlImg = sp.UrlImg;
            pokemon.IdRegion = sp.IdRegion;
            pokemon.IdTipo = sp.IdType;

            await _PokemonRepository.AddAsync(pokemon);
        }

        public async Task Delete(int id)
        {
            var pokemon = await _PokemonRepository.GetByIdAsync(id);
            await _PokemonRepository.DeleteAsync(pokemon);

        }

        public async Task<SavePokemon> GetByIdSavePokemon(int id)
        {
            var pokemons = await _PokemonRepository.GetByIdAsync(id);

            SavePokemon sv = new();
            sv.Id = pokemons.Id;
            sv.Name = pokemons.Name;
            sv.UrlImg = pokemons.UrlImg;
            sv.IdRegion = pokemons.IdRegion;
            sv.IdType = pokemons.IdTipo;

            return sv;

        }

        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonsList = await _PokemonRepository.GetAllAsync();

            return pokemonsList.Select(pokemon => new PokemonViewModel
            {
                Name = pokemon.Name,
                UrlImg = pokemon.UrlImg,
                Id = pokemon.Id,
                IdRegion = pokemon.IdRegion,
                IdType = pokemon.IdTipo


            }).ToList();
        }

      /*  public async Task<List<PokemonViewModel>> GetAllViewModelRegion()
        {
            var RegionList = await _RegionRepository.GetAllRegion();
         

            return RegionList.Select(region => new PokemonViewModel
            {
                Region = region.Name,
                RegionId = region.Id,

            }).ToList();

  
        }*/


    }
}
