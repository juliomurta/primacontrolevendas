using Prima.ControleVendas.Domain.Contracts;
using Prima.ControleVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prima.ControleVendas.Repository
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context): base(context)
        {
                
        }
    }
}
