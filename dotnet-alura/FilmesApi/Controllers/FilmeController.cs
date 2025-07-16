using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine($"Filme adicionado com sucesso!");
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero);
    }

    [HttpGet]
    public IEnumerable<Filme> ListaFilmes([FromQuery] int skip = 0,[FromQuery] int take = 5)
    {
        Console.WriteLine(filmes);

        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public Filme? RecuperaFilmePorIdId(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}