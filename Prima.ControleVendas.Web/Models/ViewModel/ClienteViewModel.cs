using Prima.ControleVendas.Domain.Entities;
using Prima.ControleVendas.Web.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prima.ControleVendas.Web.Models.ViewModel
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo Nome pode ter no máximo 30 caracteres.")]
        [MinLength(3, ErrorMessage = "O campo Nome pode ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        public string DataNascimento { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public static explicit operator Cliente(ClienteViewModel viewmodel)
        {
            return new Cliente
            {
                Id = viewmodel.Id,
                CPF = FormatUtils.ConverterStringParaCPF(viewmodel.Cpf),
                Nome = viewmodel.Nome.Trim(),
                DataNascimento = viewmodel.DataNascimento != null ? Convert.ToDateTime(viewmodel.DataNascimento) : new DateTime(1753, 1, 1),
                Email = viewmodel.Email,
                Telefone = viewmodel.Telefone
            };
        }
    }
}
