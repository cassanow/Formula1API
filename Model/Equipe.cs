using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula1API.Model;

public class Equipe
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Motor { get; set; }
    
    public string Nacionalidade { get; set; }
}