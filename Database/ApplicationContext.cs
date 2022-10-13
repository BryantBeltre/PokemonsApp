using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Pokemons> Pokemons { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Tipo> Tipo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api

            #region tablas
            modelBuilder.Entity<Pokemons>()
                .ToTable("Pokemons");

            modelBuilder.Entity<Region>()
                .ToTable("Regions");

            modelBuilder.Entity<Tipo>()
                .ToTable("Type");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Pokemons>()
                .HasKey(pokemons => pokemons.Id);

            modelBuilder.Entity<Region>()
                .HasKey(region => region.Id);

            modelBuilder.Entity<Tipo>()
                .HasKey(tipo => tipo.Id);
            #endregion

            #region "RelationShips"
            modelBuilder.Entity<Region>()
                .HasMany<Pokemons>(region => region.Pokemons)
                .WithOne(pokemons => pokemons.region)
                .HasForeignKey(pokemon => pokemon.IdRegion)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tipo>()
                .HasMany<Pokemons>(region => region.pokemons)
                .WithOne(pokemons => pokemons.Tipo)
                .HasForeignKey(pokemon => pokemon.IdTipo)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion

            #region "Popety Configuration"


            #region pokemons
            modelBuilder.Entity<Pokemons>()
                .Property(pokemon => pokemon.Name)
                .IsRequired();
            modelBuilder.Entity<Pokemons>()
                .Property(pokemon => pokemon.UrlImg)
                .IsRequired();

            #endregion


            #region region
            modelBuilder.Entity<Region>()
                .Property(region => region.Name)
                .IsRequired();
            #endregion


            #region tipo
            modelBuilder.Entity<Tipo>()
                .Property(tipo => tipo.Name)
                .IsRequired();
            #endregion

            #endregion

        }

    }
}
