using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NeosoftApi.Models;

[Table("Usuarios")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] 
    [MaxLength(100)] 
    public string Nombre { get; set; }

    [Required] 
    [MaxLength(200)] 
    [EmailAddress]
    public string Email { get; set; }

    [ForeignKey("RoleId")]
    public int RoleId { get; set; }
    
    public Role Role { get; set; }
}