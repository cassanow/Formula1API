using Formula1API.Model;
using Microsoft.EntityFrameworkCore;

namespace Formula1API.Repository;

public class PilotoRepository : IPilotoRepository
{
    private readonly Context _context;

    public PilotoRepository(Context context)
    {
        _context = context;
    }

    public async Task AdicionarPiloto(Piloto piloto)
    {
        _context.Add(piloto);
        await _context.SaveChangesAsync();
    }

    public async Task<Piloto> GetPilotoById(int id)
    {
        var piloto = await _context.Pilotos.FindAsync(id);
        
        return piloto;
    }

    public async Task<Piloto> RemoverPiloto(int id)
    {
        var piloto = await _context.Pilotos.FindAsync(id);
        
        _context.Pilotos.Remove(piloto);
        await _context.SaveChangesAsync();
        
        return piloto;
    }

    public async Task<IEnumerable<Piloto>> GetPilotos()
    {
       var pilotos = await _context.Pilotos.ToListAsync();
       
       return pilotos;
    }

    public async Task<Piloto> PutPiloto(int id, Piloto piloto)
    {
        var pilotoExistente = await _context.Pilotos.FindAsync(id);
        
        _context.Entry(pilotoExistente).CurrentValues.SetValues(piloto);
        await _context.SaveChangesAsync();
        
        return pilotoExistente;
    }
}