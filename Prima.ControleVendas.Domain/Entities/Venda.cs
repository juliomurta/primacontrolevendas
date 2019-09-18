using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prima.ControleVendas.Domain.Entities
{
    public class Venda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(TypeName = "integer")]
        public int Id { get; set; }

        [Column("Data", TypeName = "datetime")]
        public DateTime Data { get; set; }

        public Cliente Cliente { get; set; }

        public IList<ProdutoVenda> Itens { get; set; }
    }
}
