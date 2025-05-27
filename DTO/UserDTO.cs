using System.ComponentModel.DataAnnotations;

namespace Formula1API.DTO;

public class UserDTO
{
    [Required]
    public string? Usuario { get; set; }
    
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    
    public string? Senha { get; set; }
    
}