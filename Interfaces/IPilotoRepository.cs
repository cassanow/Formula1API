using Formula1API.Model;

namespace Formula1API.Repository;

public interface IPilotoRepository
{
    Task AdicionarPiloto(Piloto piloto);
    
    Task<Piloto> GetPilotoById(int id);
    
    Task<Piloto> RemoverPiloto(int id);
    
    Task<IEnumerable<Piloto>> GetPilotos();
    
    Task<Piloto> PutPiloto(int id, Piloto piloto);
}