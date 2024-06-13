using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Api;

[Route("api/[controller]")]
[ApiController]
public class PersonController: ControllerBase
{
    private readonly PersonService _personService;

    public PersonController(PersonService personService)
    {
        _personService = personService;
    }
    
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        return Ok(_personService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var person = _personService.GetById(id);
        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody]PersonCreateRequest personCreateRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        var response = _personService.Create(personCreateRequest);
        
        return CreatedAtAction(nameof(GetById), new {id = response.Id}, response);
    }

    [HttpPatch("{id}")]
    public IActionResult Update(PersonUpdateRequest personUpdateRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var response = _personService.Update(personUpdateRequest);
        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _personService.Delete(id);

        return NoContent();
    }
}