using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Estoque.Models
{
    public class Produto
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int IdCategoria { get; set; }
        [JsonIgnore]
        public virtual Categoria? Categoria { get; set; }
    }
}
