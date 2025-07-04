using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);
        Console.WriteLine($"Filme adicionado com sucesso!");
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero);
    }

    [HttpGet]
    public List<Filme> ListaFilmes()
    {
        Console.WriteLine("Request de GET rodou");
        Console.WriteLine(filmes);

        return filmes;
    }
}