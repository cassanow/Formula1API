using AutoMapper;
using Formula1API.DTO;
using Formula1API.Model;
using Formula1API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Formula1API.Controller;

[Route("api/[controller]")]
[ApiController]
public class PilotosController : ControllerBase
{
    private readonly IPilotoService _service;
    private readonly IMapper _mapper;

    public PilotosController(IPilotoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
   
    [HttpPost]
    public async Task <ActionResult> AdicionarPiloto([FromBody] PilotoDTO piloto)
    {
        var pilotoAdicionar = _mapper.Map<Piloto>(piloto);
        await _service.AdicionarPiloto(pilotoAdicionar);
        return Ok(pilotoAdicionar);
    }
    
    [HttpGet]
    public async Task<IEnumerable<Piloto>> GetAllPilotos()
    {
        return await _service.GetAllPilotos();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Piloto>> GetPilotoById(int id)
    {
        var piloto = await _service.GetPilotoById(id);
        return Ok(piloto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Piloto>> PutPiloto(int id, Piloto piloto)
    {
        var pilotoAtualizado = await _service.PutPiloto(id, piloto);
        return Ok(pilotoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Piloto>> RemoverPiloto(int id)
    {
        var piloto = await _service.RemoverPiloto(id);
        return Ok(piloto);
    }
    
    
}