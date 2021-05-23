using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }

        [Required]
        [Column("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CiudadOrigen { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string email { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}
