using GestranTeste.DTO;
using GestranTeste.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ILogger<UsuariosController> _logger;
    private IUsuariosService _usuarioservice;

    public UsuariosController(ILogger<UsuariosController> logger, IUsuariosService usuarioservice)
    {
        _logger = logger;
        _usuarioservice = usuarioservice;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var usuarios = _usuarioservice.FindAll();
        if (usuarios == null)
        {
            return NotFound();
        }
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_usuarioservice.FindById(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] UsuarioDTO usuarioDTO)
    {
        _usuarioservice.Create(usuarioDTO);
        return CreatedAtAction(nameof(Get), new { id = usuarioDTO.Id }, usuarioDTO);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UsuarioDTO usuarioDTO)
    {
        if (id != usuarioDTO.Id)
        {
            return BadRequest();
        }

        _usuarioservice.Update(usuarioDTO);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _usuarioservice.Delete(id);
        return NoContent();
    }

}
