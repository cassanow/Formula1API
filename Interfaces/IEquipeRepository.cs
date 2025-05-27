using Formula1API.Model;

namespace Formula1API.Repository;

public interface IEquipeRepository
{
    Task Adicionar(Equipe equipe);
    
    Task<Equipe> Atualizar(int id, Equipe equipe);
    
    Task<IEnumerable<Equipe>> GetAll();
    
    Task<Equipe> GetById(int id);
    
    Task<Equipe> Remover(int id);
}