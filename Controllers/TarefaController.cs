using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiAgenda.Context;
using ApiAgenda.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiAgenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        // GET: api/Tarefa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
        {
            return await _context.Tarefas.ToListAsync();
        }
        
        // GET: api/Tarefa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        // GET: api/Tarefa/Titulo/{titulo}
        [HttpGet("Titulo/{titulo}")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefasPorTitulo(string titulo)
        {
            var tarefas = await _context.Tarefas.Where(t => t.Titulo.Contains(titulo)).ToListAsync();

            if (!tarefas.Any())
            {
                return NotFound();
            }

            return Ok(tarefas);
        }

        // GET: api/Tarefa/Data/{data}
        [HttpGet("Data/{data}")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefasPorData(DateTime data)
        {
            var tarefas = await _context.Tarefas.Where(t => t.Data.Date == data.Date).ToListAsync();

            if (!tarefas.Any())
            {
                return NotFound();
            }

            return Ok(tarefas);
        }

        // GET: api/Tarefa/Status/{status}
        [HttpGet("Status/{status}")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefasPorStatus(TarefaStatus status)
        {
            var tarefas = await _context.Tarefas.Where(t => t.Status == status).ToListAsync();

            if (!tarefas.Any())
            {
                return NotFound();
            }

            return Ok(tarefas);
        }
        
        // POST: api/Tarefa
        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
        }

        // PUT: api/Tarefa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // DELETE: api/Tarefa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }

    }
}