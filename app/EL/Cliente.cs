
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EL
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [MaxLength(200)][Required]
        public string Nombre { get; set; } = string.Empty;
         [MaxLength(200)][Required]
         public string Correo { get; set; }
         [MaxLength(10)][Required]
         public string Telefono { get; set; }

    }
}