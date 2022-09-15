using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        // private static List<Filme> filmes = new List<Filme>();
        // private static int id = 1;

        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            // filme.Id = id++;
            // filmes.Add(filme);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new {id = filme.Id}, filme);           
 
        }
        [HttpGet]
        public IActionResult RecuperaFilmes(){
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id) 
        {
        // foreach (Filme filme in filmes){
        //        if (filme.Id == id){
        //            return filme;
        //        }         
        //    }
        //    return null; 

        //  Em c#
        //Para comentar Ctrl + / , linhas ou blocoss
 
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme != null){
                return Ok(filme);
            }
            return NotFound();
        }
    }
}