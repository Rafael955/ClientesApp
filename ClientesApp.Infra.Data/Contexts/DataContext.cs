using ClientesApp.Domain.Entities;
using ClientesApp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("ClientesDB");
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDClientes;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionando as classes de mapeamento do projeto
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }

        /// <summary>
        /// Operações com cliente em memória
        /// </summary>
        //public DbSet<Cliente> Clientes { get; set; }
    }
}
