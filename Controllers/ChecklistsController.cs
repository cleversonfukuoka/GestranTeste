// Controllers/ChecklistsController.cs
using Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using GestranTeste.Services;
using GestranTeste.DTO;

[Route("api/[controller]")]
[ApiController]
public class ChecklistsController : ControllerBase
{
    private readonly ILogger<ChecklistsController> _logger;
    private IChecklistService _checklistService;

    public ChecklistsController(ILogger<ChecklistsController> logger, IChecklistService checklistService)
    {
        _logger = logger;
        _checklistService = checklistService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var checklists = _checklistService.FindAll();
        if (checklists == null)
        {
            return NotFound();
        }
        return Ok(checklists);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CheckListDTO checklistDTO)
    {
        _checklistService.Create(checklistDTO);
        return CreatedAtAction(nameof(Get), new { id = checklistDTO.Id }, checklistDTO);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, CheckListDTO checklistDTO)
    {
        if (id != checklistDTO.Id)
        {
            return BadRequest();
        }

        _checklistService.Update(checklistDTO);
        return NoContent();
    
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _checklistService.Delete(id);
        return NoContent();
    }
}
