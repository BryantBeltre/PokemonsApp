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
    public class RegionService
    {
        private readonly PokemonRepository _pokemonRepository;
        private readonly RegionRepository _regionRepository;
        private readonly TipoRepository _typeRepository;

        public RegionService(ApplicationContext DbContext)
        {
            _pokemonRepository = new (DbContext);
            _regionRepository = new(DbContext);
            _typeRepository = new(DbContext);
        }

        public async Task<List<RegionViewModel>> GetAllRegioViewModel()
        {
            var regionlist = await _regionRepository.GetAllRegion();

            return regionlist.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Name = region.Name
            }).ToList();
        }

        public async Task UpdateRegion(SaveRegion sr)
        {
            Region region = new();
            region.Id = sr.Id;
            region.Name = sr.Name;

            await _regionRepository.UpdateRegionAsync(region);
        }

        public async Task AddRegion(SaveRegion sr)
        {
            Region region = new();
            region.Id = sr.Id;
            region.Name = sr.Name;

            await _regionRepository.AddRegionAsync(region);
        }

        public async Task DeleteRegion(int id)
        {
            var region = await _regionRepository.GetAsyncRegionCyId(id);
            await _regionRepository.DeleteRegionAsync(region);

        }

        public async Task<SaveRegion> GetRegionById(int id)
        {
            var region = await _regionRepository.GetAsyncRegionCyId(id);

            SaveRegion sr = new();

            sr.Id = region.Id;
            sr.Name = region.Name;

            return sr;
        } 

    }
}
