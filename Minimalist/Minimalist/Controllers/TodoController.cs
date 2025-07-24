using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Minimalist.Data;
using Minimalist.Data.Dtos;
using Minimalist.Models;

namespace Minimalist.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private TodoContext _context;
    private IMapper _mapper;

    public TodoController(TodoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddTodo([FromBody] CreateTodoDto todoDto)
    {
        Todo todo = _mapper.Map<Todo>(todoDto);

        _context.Todos.Add(todo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);

    }

    [HttpGet]
    public IEnumerable<ReadTodoDto> GetTodos([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _mapper.Map<List<ReadTodoDto>>(_context.Todos.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetTodoById(int id)
    {
        var todo = _context.Todos.FirstOrDefault(todo => todo.Id == id);
        if (todo == null) return NotFound();
        var todoDto = _mapper.Map<ReadTodoDto>(todo);
        return Ok(todoDto);
    }
}