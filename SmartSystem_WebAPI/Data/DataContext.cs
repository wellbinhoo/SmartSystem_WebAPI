using Microsoft.EntityFrameworkCore;
using SmartSystem_WebAPI.Models;
using System.Collections.Generic;

namespace SmartSystem_WebAPI.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
           

            builder.Entity<Departamento>()
                .HasData(new List<Departamento>(){
                    new Departamento(1, "Escritorio","Esc"),
                    new Departamento(2, "Cozinha","COZ"),
                    new Departamento(3, "Oficina","OFC"),
                   
                });

           

            builder.Entity<Funcionario>()
                .HasData(new List<Funcionario>(){
                    new Funcionario(1, "Naruto", "Foto", 102030, 1),
                    new Funcionario(2, "Goku", "Foto", 301020,2),
                    new Funcionario(3, "Yoga", "Foto", 203010,3),
                   
                });

           
        }
    }
}
