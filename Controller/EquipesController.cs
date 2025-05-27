using AutoMapper;
using Formula1API.DTO;
using Formula1API.Model;
using Formula1API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Formula1API.Controller;

[Route("api/[controller]")]
[ApiController]
public class EquipesController : ControllerBase
{
    private readonly IEquipeService _service;
    private readonly IMapper _mapper;

    public EquipesController(IEquipeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] EquipeDTO equipe)
    {
        var adicionarEquipe = _mapper.Map<Equipe>(equipe);
        await _service.Adicionar(adicionarEquipe);
        return Ok(equipe);
    }

    [HttpGet]
    public async Task<IEnumerable<Equipe>> GetAll()
    {
        return await _service.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Equipe>> GetById(int id)
    {
        var piloto  = await  _service.GetById(id);
        return Ok(piloto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Equipe>> Atualizar(int id, Equipe equipe)
    {
        var equipeAtualizado = await _service.Atualizar(id, equipe);
        return Ok(equipeAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var equipe = await _service.GetById(id);
        await _service.Remover(id);
        return Ok(equipe);
    }
}