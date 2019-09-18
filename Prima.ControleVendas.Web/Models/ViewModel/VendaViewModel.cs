using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prima.ControleVendas.Web.Models.ViewModel
{
    public class VendaViewModel
    {
        public string InfoClienteSelecionado { get; set; }

        public AgrupamentoItemViewModel AgrupamentoItens { get; set; } = new AgrupamentoItemViewModel();
    }

    public class AgrupamentoItemViewModel
    {
        public IList<ItemViewModel> Itens { get; set; }

        public decimal Total
        {
            get
            {
                return (this.Itens != null && this.Itens.Count > 0) ? this.Itens.Sum(x => x.PrecoTotal) : 0;
            }
        }
    }

    public class ItemViewModel
    {
        public int ProdutoId { get; set; }

        public string DescricaoProduto { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public decimal PrecoTotal { get; set; }
    }
}
