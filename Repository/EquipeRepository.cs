using AutoMapper;
using Formula1API.Model;
using Microsoft.EntityFrameworkCore;

namespace Formula1API.Repository;

public class EquipeRepository : IEquipeRepository
{
    private readonly Context _context;

    public EquipeRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<Equipe> GetById(int id)
    {
        var equipe = await _context.Equipes.FindAsync(id);
        
        return equipe;
    }

    public async Task<IEnumerable<Equipe>> GetAll()
    {
        var equipes = await _context.Equipes.ToListAsync();
        return equipes;
    }

    public async Task Adicionar(Equipe equipe)
    {
        _context.Equipes.Add(equipe);
        await _context.SaveChangesAsync();
    }

    public async Task<Equipe> Atualizar(int id, Equipe equipe)
    {
        var equipeAtualizar = await _context.Equipes.FindAsync(id);
        
        _context.Entry(equipeAtualizar).CurrentValues.SetValues(equipe);
        await _context.SaveChangesAsync();
       
        return equipeAtualizar;
    }

    public async Task<Equipe> Remover(int id)
    {
        var equipe = await _context.Equipes.FindAsync(id);
        
        _context.Equipes.Remove(equipe);
        await _context.SaveChangesAsync();
        
        return equipe;
    }
}