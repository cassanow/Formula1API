using Formula1API.Model;

namespace Formula1API.Service;

public interface IEquipeService
{
    Task Adicionar(Equipe equipe);
    
    Task<Equipe> Atualizar(int id, Equipe equipe);
    
    Task<Equipe> GetById(int id);
    
    Task<Equipe> Remover(int id);
    
    Task<IEnumerable<Equipe>> GetAll();
}