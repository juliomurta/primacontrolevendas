using Microsoft.AspNetCore.Mvc;
using Prima.ControleVendas.Domain.Contracts;
using Prima.ControleVendas.Domain.Entities;
using Prima.ControleVendas.Web.Models.ViewModel;
using Prima.ControleVendas.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prima.ControleVendas.Web.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteRepository clienteRepository = null;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ClienteViewModel());
        }

        [HttpPost]
        public IActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cpf = FormatUtils.ConverterStringParaCPF(clienteViewModel.Cpf);
                    var existente = this.clienteRepository.Get(x => x.CPF == cpf);

                    if (existente != null)
                    {
                        ModelState.AddModelError("Cpf", "Não é possível cadastrar cliente. CPF duplicado!");
                        return View(clienteViewModel);
                    }

                    this.clienteRepository.Create((Cliente) clienteViewModel);

                    TempData["sucesso"] = "Cadastro realizado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    TempData["erro"] = $"Ocorreu um erro durante o processamento. Mensagem: {ex.Message}.";
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(clienteViewModel);
        }

        public IActionResult AbrirModalProcurarCliente()
        {
            return PartialView("~/Views/Cliente/Partial/ProcurarClienteModel.cshtml");
        }

        [HttpGet]
        public IActionResult Pesquisar(string cpf, string nome)
        {
            var clientes = this.clienteRepository.List();

            if (!string.IsNullOrEmpty(cpf))
            {
                clientes = clientes.Where(x => x.CPF == FormatUtils.ConverterStringParaCPF(cpf)).ToList();
            }

            if (!string.IsNullOrEmpty(nome))
            {
                clientes = clientes.Where(x => x.Nome.ToLower().Contains(nome.ToLower().Trim())).ToList();
            }

            var clientesViewModel = new List<SelecaoClienteViewModel>();
            if (clientes != null)
            {
                foreach (var item in clientes)
                {
                    clientesViewModel.Add(new SelecaoClienteViewModel
                    {
                        Cpf = item.CPF.ToString(),
                        Nome = item.Nome,
                        IsSelecionado = false
                    });
                }
            }

            return PartialView("~/Views/Cliente/Partial/ListagemSelecaoCliente.cshtml", clientesViewModel);
        }
    }
}