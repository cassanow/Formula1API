using AutoMapper;
using Formula1API.DTO;
using Formula1API.Model;
using Formula1API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Formula1API.Controller;

[Route("api/[controller]")]
[ApiController]
public class PilotosController : ControllerBase
{
    private readonly IPilotoRepository _repository;
    private readonly IMapper _mapper;

    public PilotosController(IPilotoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
   
    [HttpPost]
    public async Task <ActionResult> AdicionarPiloto([FromBody] PilotoDTO piloto)
    {
        var pilotoAdicionar = _mapper.Map<Piloto>(piloto);
        await _repository.AdicionarPiloto(pilotoAdicionar);
        return Ok(pilotoAdicionar);
    }
    
    [HttpGet]
    public async Task<IEnumerable<Piloto>> GetAllPilotos()
    {
        return await _repository.GetPilotos();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Piloto>> GetPilotoById(int id)
    {
        var piloto = await _repository.GetPilotoById(id);
        return Ok(piloto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Piloto>> PutPiloto(int id, Piloto piloto)
    {
        var pilotoAtualizado = await _repository.PutPiloto(id, piloto);
        return Ok(pilotoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Piloto>> RemoverPiloto(int id)
    {
        var piloto = await _repository.RemoverPiloto(id);
        return Ok(piloto);
    }
    
    
}