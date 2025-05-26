
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula1API.Model;

public class Piloto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Equipe { get; set; }
    
    public string Idade { get; set; }
    
    public string Nacionalidade { get; set; }
  
    public DateTime DataNascimento { get; set; }
}