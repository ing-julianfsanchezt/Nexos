using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    [Table("Editorial")]
    public class Editorial
    {
        [Key]
        public int IdEditorial { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Direccion { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Telefono { get; set; }

        [Required]
        public int MaxLibrosRegistrados { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}
