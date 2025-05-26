using Formula1API.Model;
using Formula1API.Repository;

namespace Formula1API.Service;

public class EquipeService : IEquipeService
{
    private readonly IEquipeRepository _repository;

    public EquipeService(IEquipeRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Equipe> GetById(int id)
    {
        var equipe = await _repository.GetById(id);
        return equipe;
    }

    public async Task<IEnumerable<Equipe>> GetAll()
    {
        var equipes = await _repository.GetAll();
        return equipes;
    }

    public async Task Adicionar(Equipe equipe)
    {
        await _repository.Adicionar(equipe);
    }

    public async Task<Equipe> Atualizar(int id, Equipe equipe)
    {
        var equipeAtualizada = await _repository.Atualizar(id, equipe);
        
        return equipeAtualizada;
    }

    public async Task<Equipe> Remover(int id)
    {
        return await _repository.Remover(id);
    }
}