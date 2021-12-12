using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using webAPIParcial.Data;
using webAPIParcial.Models;


namespace webAPIParcial.Controllers
{

    /// <summary>
    /// Wed API para gestion de Departamentos de El Salvador
    ///</summary>
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController: Controller
    {
        private DatabaseContext _context;

        public DepartamentoController(DatabaseContext context)
        {
            _context=context;
        }
        /// <summary>
        /// Get de todos los Departamentos
        ///</summary>
        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamento()
        {
            var departamento = await _context.Departamentos.ToListAsync();
            return departamento; 
        }
        /// <summary>
        /// Get id para ver un Departamento
        ///</summary>
         [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamentoID(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if(departamento==null)
            {
                return NotFound();
            }
            return departamento;
        }
        /// <summary>
        /// Post para crear Departamento
        ///</summary>
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDepartamentoID", new{id=departamento.DepartamentoId}, departamento);
        }
        /// <summary>
        /// Put para editar Departamento
        ///</summary>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Departamento>> PutMunicipio(int id, Departamento departamento)
        {
            if(id != departamento.DepartamentoId)
            {
                return BadRequest();
            }
            _context.Entry(departamento).State= EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!DepartamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetMunicipioID", new{id=departamento.DepartamentoId}, departamento);
        }
        /// <summary>
        /// Delete para borrar Departamento
        ///</summary>
        [HttpDelete("id:int")]
         public async Task<ActionResult<Departamento>> DeleteDepartamento(int id)
         {
             var departamento = await _context.Departamentos.FindAsync(id);
             if(departamento==null)
             {
                 return NotFound();
             }

             _context.Departamentos.Remove(departamento);
             await _context.SaveChangesAsync();

             return departamento;
         }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(d=>d.DepartamentoId==id);
        }
    }
}