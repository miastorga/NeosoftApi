using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosoftApi.Models;

[Table("Variables")]
public class Variable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)] 
    public string Nombre { get; set; }

    [Required]
    [MaxLength(100)] 
    public string Valor { get; set; }

    [Required]
    [AllowedValues("texto", "numerico","booleano")]
    public string Tipo { get; set; }
}