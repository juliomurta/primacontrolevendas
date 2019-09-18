using Prima.ControleVendas.Domain.Contracts;
using Prima.ControleVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prima.ControleVendas.Repository
{
    public class VendaRepository : GenericRepository<Venda>, IVendaRepository
    {
        public VendaRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
