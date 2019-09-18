using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prima.ControleVendas.Domain.Entities
{
    public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id", TypeName = "integer")]
        public int Id { get; set; }

        [Column("Nome", TypeName = "nvarchar(30)")]
        public string Nome { get; set; }
    }
}
