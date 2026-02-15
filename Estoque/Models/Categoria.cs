using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Estoque.Models
{
    public class Categoria
    {

        [Key()]
        public int Id { get; set; }
        public string Desc { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Produto>? Produtos { get; set; } = new List<Produto>();
    }
}
