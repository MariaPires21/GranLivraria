using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranLivraria.Models
{
    public class Livro
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        // RELAÇÃO: Um livro pertence a um gênero
        public uint GeneroId { get; set; }
        public virtual Genero? Genero { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        public uint Estoque { get; set; }

        // NOVA PROPRIEDADE PARA A IMAGEM
        [StringLength(500)]
        public string? ImagemUrl { get; set; } = "/images/livros/capa-padrao.jpg";
    }
}