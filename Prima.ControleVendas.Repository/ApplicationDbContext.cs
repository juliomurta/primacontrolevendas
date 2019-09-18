using Microsoft.EntityFrameworkCore;
using Prima.ControleVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prima.ControleVendas.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Venda> Vendas { get; set; }
    }
}
