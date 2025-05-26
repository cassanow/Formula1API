using Formula1API.Model;

namespace Formula1API.Service;

public interface IPilotoService
{
    Task AdicionarPiloto(Piloto piloto);
    
    Task<Piloto> GetPilotoById(int id);
    
    Task<Piloto> RemoverPiloto(int id);
    
    Task<IEnumerable<Piloto>> GetAllPilotos();
    
    Task<Piloto> PutPiloto(int id, Piloto piloto);
}