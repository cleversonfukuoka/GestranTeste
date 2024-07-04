using GestranTeste.DTO;
using GestranTeste.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

[Route("api/[controller]")]
[ApiController]
public class VeiculosController : ControllerBase
{
    private readonly ILogger<ChecklistsController> _logger;
    private IVeiculosService _veiculoservice;

    public VeiculosController(ILogger<ChecklistsController> logger, IVeiculosService veiculoservice)
    {
        _logger = logger;
        _veiculoservice = veiculoservice;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var veiculo = _veiculoservice.FindAll();
        if (veiculo == null)
        {
            return NotFound();
        }
        return Ok(veiculo);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_veiculoservice.FindById(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] VeiculoDTO veiculoDTO)
    {
        _veiculoservice.Create(veiculoDTO);
        return CreatedAtAction(nameof(Get), new { id = veiculoDTO.Id }, veiculoDTO);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, VeiculoDTO veiculoDTO)
    {
        if (id != veiculoDTO.Id)
        {
            return BadRequest();
        }

        _veiculoservice.Update(veiculoDTO);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _veiculoservice.Delete(id);
        return NoContent();
    }

}
