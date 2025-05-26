using Formula1API.Model;
using Formula1API.Repository;

namespace Formula1API.Service;

public class PilotoService : IPilotoService
{
    private readonly IPilotoRepository _repository;

    public PilotoService(IPilotoRepository repository)
    {
        _repository = repository;
    }

    public async Task AdicionarPiloto(Piloto piloto)
    {
       await _repository.AdicionarPiloto(piloto);
    }

    public async Task<Piloto> GetPilotoById(int id)
    {
        return await _repository.GetPilotoById(id);
    }

    public async Task<Piloto> RemoverPiloto(int id)
    {
        return await _repository.RemoverPiloto(id);
    }

    public async Task<IEnumerable<Piloto>> GetAllPilotos()
    {
        return await _repository.GetPilotos();
    }

    public async Task<Piloto> PutPiloto(int id, Piloto piloto)
    {
        var pilotoAtualizado = await _repository.PutPiloto(id, piloto);
        
        return pilotoAtualizado;
    }
}