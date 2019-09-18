using Prima.ControleVendas.Domain.Contracts;
using Prima.ControleVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prima.ControleVendas.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
