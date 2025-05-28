using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NeosoftApi.Models;

[Table("Roles")]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] 
    [MaxLength(50)]
    public string Nombre { get; set; }
    
    public ICollection<User> Users { get; set; } = new List<User>();
}