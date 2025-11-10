using System.ComponentModel.DataAnnotations;

namespace GranLivraria.Models
{
    public class Genero
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Nome { get; set; } = string.Empty;

        public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}