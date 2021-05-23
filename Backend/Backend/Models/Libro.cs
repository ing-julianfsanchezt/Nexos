using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    [Table("Libro")]
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Titulo { get; set; }

        [Required]
        public int Anio { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Genero { get; set; }

        [Required]
        public int NumPaginas { get; set; }

        [ForeignKey("Editorial")]
        public int IdEditorial { get; set; }

        public virtual Editorial Editorial { get; set; }

        [ForeignKey("Autor")]
        public int IdAutor { get; set; }

        public virtual Autor Autor { get; set; }

    }
}
