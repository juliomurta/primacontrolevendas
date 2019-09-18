using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prima.ControleVendas.Domain.Entities
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(TypeName = "integer")]
        public int Id { get; set; }

        [Column("Cpf", TypeName = "bigint")]
        public long CPF { get; set; }

        [Column("Nome", TypeName = "nvarchar(30)")]
        public string Nome { get; set; }

        [Column("DataNascimento", TypeName = "datetime")]
        public DateTime DataNascimento { get; set; }

        [Column("Email", TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column("Telefone", TypeName = "nvarchar(50)")]
        public string Telefone { get; set; }
    }
}
