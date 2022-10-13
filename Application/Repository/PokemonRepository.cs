using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class PokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonRepository(ApplicationContext dbContext) { 
            
            _dbContext = dbContext;
   
        }

        public async Task AddAsync(Pokemons pokemons)
        {
            await _dbContext.Pokemons.AddAsync(pokemons);
            await _dbContext.SaveChangesAsync();
        
        }

        public async Task UpdateAsync(Pokemons pokemons)
        {
            _dbContext.Entry(pokemons).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemons pokemons)
        {
            _dbContext.Set<Pokemons>().Remove(pokemons);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pokemons>> GetAllAsync()
        {
            return await _dbContext.Set<Pokemons>().ToListAsync();
        }

        public async Task<Pokemons> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Pokemons>().FindAsync(id);
        }


    }
}
