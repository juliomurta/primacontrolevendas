using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Prima.ControleVendas.Domain.Contracts;
using Prima.ControleVendas.Domain.Entities;
using Prima.ControleVendas.Web.Models.ViewModel;

namespace Prima.ControleVendas.Web.Controllers
{
    public class VendaController : Controller
    {
        IClienteRepository clienteRepository = null;
        IProdutoRepository produtoRepository = null;
        IVendaRepository vendaRepository = null;

        public VendaController(IClienteRepository clienteRepository, 
                               IProdutoRepository produtoRepository,
                               IVendaRepository vendaRepository)
        {
            this.clienteRepository = clienteRepository;
            this.produtoRepository = produtoRepository;
            this.vendaRepository = vendaRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new VendaViewModel());
        }

        [HttpPost]
        public IActionResult Create(VendaViewModel vendaViewModel)
        {
            try
            {
                var cpf = Convert.ToInt64(vendaViewModel.InfoClienteSelecionado.Split(new[] { '-' })[0].ToString());

                var venda = new Venda();
                venda.Cliente = this.clienteRepository.Get(x => x.CPF == cpf);                
                venda.Data = DateTime.Now;
                venda.Itens = new List<ProdutoVenda>();

                foreach (var item in vendaViewModel.AgrupamentoItens.Itens)
                {
                    var idProduto = Convert.ToInt32(item.DescricaoProduto.Split(new[] { '-' })[0]);

                    var produtoVenda = new ProdutoVenda();
                    produtoVenda.Produto = this.produtoRepository.Get(idProduto);
                    produtoVenda.Quantidade = item.Quantidade;
                    produtoVenda.Preco = item.PrecoUnitario;
                    venda.Itens.Add(produtoVenda);
                }

                this.vendaRepository.Create(venda);

                TempData["sucesso"] = "Cadastro realizado com sucesso!";
                return Json(Url.Action("Index", "Home"));
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Erro ao cadatrar venda. Mensagem: {ex.Message}";
                return Json(Url.Action("Index", "Home"));
            }
        }

        [HttpPost]
        public IActionResult AdicionarItemTabela(List<ItemViewModel> itens)
        {
            foreach (var item in itens)
            {
                item.PrecoTotal = item.Quantidade * item.PrecoUnitario;
            }

            var agrupamentoItens = new AgrupamentoItemViewModel();
            agrupamentoItens.Itens = itens;

            return PartialView("~/Views/Produto/Partial/TabelaProdutosSelecionados.cshtml", agrupamentoItens);
        }
    }
}