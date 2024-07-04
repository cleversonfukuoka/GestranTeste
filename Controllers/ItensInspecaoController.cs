using GestranTeste.DTO;
using GestranTeste.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

[Route("api/[controller]")]
[ApiController]
public class ItensInspecaoController : ControllerBase
{
    private readonly ILogger<ItensInspecaoController> _logger;
    private IItensInspecaoService _itensinspecaoservice;

    public ItensInspecaoController(ILogger<ItensInspecaoController> logger, IItensInspecaoService itensinspecaoservice)
    {
        _logger = logger;
        _itensinspecaoservice = itensinspecaoservice;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var itensinspecao = _itensinspecaoservice.FindAll();
        if (itensinspecao == null)
        {
            return NotFound();
        }
        return Ok(itensinspecao);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_itensinspecaoservice.FindById(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] ItemInspecaoDTO itensInspecaoDTO)
    {
        _itensinspecaoservice.Create(itensInspecaoDTO);
        return CreatedAtAction(nameof(Get), new { id = itensInspecaoDTO.Id }, itensInspecaoDTO);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, ItemInspecaoDTO itensInspecaoDTO)
    {
        if (id != itensInspecaoDTO.Id)
        {
            return BadRequest();
        }

        _itensinspecaoservice.Update(itensInspecaoDTO);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _itensinspecaoservice.Delete(id);
        return NoContent();
    }

}
