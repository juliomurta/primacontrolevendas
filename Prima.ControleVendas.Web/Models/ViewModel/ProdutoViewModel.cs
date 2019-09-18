using Prima.ControleVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prima.ControleVendas.Web.Models.ViewModel
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(30, ErrorMessage = "O campo Nome pode ter no máximo 30 caracteres.")]
        [MinLength(3, ErrorMessage = "O campo Nome pode ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        public static explicit operator Produto(ProdutoViewModel viewModel)
        {
            return new Produto
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome.Trim()
            };
        }
    }
}
