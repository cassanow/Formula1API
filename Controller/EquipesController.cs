using AutoMapper;
using Formula1API.DTO;
using Formula1API.Model;
using Formula1API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Formula1API.Controller;

[Route("api/[controller]")]
[ApiController]
public class EquipesController : ControllerBase
{
    private readonly IEquipeRepository _repository;
    private readonly IMapper _mapper;

    public EquipesController(IEquipeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] EquipeDTO equipe)
    {
        var adicionarEquipe = _mapper.Map<Equipe>(equipe);
        await _repository.Adicionar(adicionarEquipe);
        return Ok(equipe);
    }

    [HttpGet]
    public async Task<IEnumerable<Equipe>> GetAll()
    {
        return await _repository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Equipe>> GetById(int id)
    {
        var piloto  = await  _repository.GetById(id);
        return Ok(piloto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Equipe>> Atualizar(int id, Equipe equipe)
    {
        var equipeAtualizado = await _repository.Atualizar(id, equipe);
        return Ok(equipeAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var equipe = await _repository.GetById(id);
        await _repository.Remover(id);
        return Ok(equipe);
    }
}