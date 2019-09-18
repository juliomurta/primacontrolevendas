using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prima.ControleVendas.Domain.Contracts;
using Prima.ControleVendas.Domain.Entities;
using Prima.ControleVendas.Web.Models.ViewModel;

namespace Prima.ControleVendas.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoRepository produtoRepository = null;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProdutoViewModel());
        }

        [HttpPost]
        public IActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existente = this.produtoRepository.Get(x => x.Nome.ToLower().Contains(produtoViewModel.Nome
                                                                                                              .Trim()
                                                                                                              .ToLower()));

                    if (existente != null)
                    {
                        ModelState.AddModelError("Nome", "Não é possível cadastrar o produto. Nome duplicado!");
                        return View(produtoViewModel);
                    }

                    this.produtoRepository.Create((Produto)produtoViewModel);

                    TempData["sucesso"] = "Cadastro realizado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    TempData["erro"] = $"Ocorreu um erro durante o processamento. Mensagem: {ex.Message}.";
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(produtoViewModel);
        }

        [HttpPost]
        public IActionResult List()
        {
            return Json(this.produtoRepository.List());
        }

        [HttpGet]
        public IActionResult AbrirModalAdicionarProduto()
        {
            return PartialView("~/Views/Produto/Partial/AdicionarItemVenda.cshtml");
        }
    }
}