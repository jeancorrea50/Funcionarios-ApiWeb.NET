using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Funcionario_ApiWeb.NET.Data;
using Funcionario_ApiWeb.NET.Models;

namespace Funcionario_ApiWeb.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioDbContext _context;

        public FuncionarioController(FuncionarioDbContext context)
        {
            _context = context;
        }

        // GET: api/Funcionario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioModel>>> GetFuncionarios()
        {
            return (await _context.Funcionarios.OrderBy(x => x.IdFuncionario).AsNoTracking().ToListAsync());
        }

        // GET: api/Funcionario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioModel>> GetFuncionarioModel(int id)
        {
            var funcionarioModel = await _context.Funcionarios.FindAsync(id);

            if (funcionarioModel == null)
            {
                return NotFound();
            }

            return funcionarioModel;
        }

        // PUT: api/Funcionario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionarioModel(int id, FuncionarioModel funcionarioModel)
        {
            if (id != funcionarioModel.IdFuncionario)
            {
                return BadRequest();
            }

            _context.Entry(funcionarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioModelExists(id))
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

        // POST: api/Funcionario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FuncionarioModel>> PostFuncionarioModel(FuncionarioModel funcionarioModel)
        {
            _context.Funcionarios.Add(funcionarioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionarioModel", new { id = funcionarioModel.IdFuncionario }, funcionarioModel);
        }

        // DELETE: api/Funcionario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionarioModel(int id)
        {
            var funcionarioModel = await _context.Funcionarios.FindAsync(id);
            if (funcionarioModel == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionarioModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioModelExists(int id)
        {
            return _context.Funcionarios.Any(e => e.IdFuncionario == id);
        }
    }
}
