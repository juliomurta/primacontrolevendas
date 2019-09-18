
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prima.ControleVendas.Domain.Entities
{
    public class ProdutoVenda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id", TypeName = "integer")]
        public int Id { get; set; }

        public Produto Produto { get; set; }

        [Column("Preco", TypeName = "numeric")]
        public decimal Preco { get; set; }

        [Column("Quantidade", TypeName = "integer")]
        public int Quantidade { get; set; }
    }
}
