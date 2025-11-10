using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranLivraria.Models
{
    public class Livro
    {
        [Key]
        public uint Id { get; set; }  

        [Required]
        [StringLength(60)]
        public string Titulo { get; set; } = string.Empty;  

        public uint GeneroId { get; set; }
        public virtual Genero? Genero { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }
    }
}