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
        /// Todos los Departamentos  
        ///</summary>
        ///<remarks>
        /// Aqui se optienen todos los Departamentos Guardados
        ///</remarks>
        /// <response code="200">Ok. Se devuelve el objeto solicitado</response>
        /// <response code="404">Error. No se encontro el objeto :c</response>

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamento()
        {
            var departamento = await _context.Departamentos.ToListAsync();
            return departamento; 
        }
          /// <summary>
        /// Ver Departamentos por ID
        ///</summary>
        ///<remarks>
        /// Aqui se optinen el Departamentos dependiendo del ID solicitado
        ///</remarks>
        /// <param name="id">ID (IdDepartamento) del objeto</param>
        /// <response code="200">Ok. Se devuelve el objeto solicitado</response>
        /// <response code="404">Error. No se encontro el objeto :c</response>

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
        /// Registro de nuevo Departamento
        ///</summary>
        ///<remarks>
        /// Aqui puedes guardar un nuevo Departamento
        ///</remarks>
        /// <response code="200">Ok. Se devuelve el objeto solicitado</response>
        /// <response code="404">Error. No se encontro el objeto :c</response>
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDepartamentoID", new{id=departamento.DepartamentoId}, departamento);
        }
       /// <summary>
        /// Editar un Departamentos ya guardado
        ///</summary>
        ///<remarks>
        /// Aqui puedes editar cualquier Departamento ya guadado (requiere ID)
        ///</remarks>
        
        /// <response code="200">Ok. Se devuelve el objeto solicitado</response>
        /// <response code="404">Error. No se encontro el objeto :c</response>
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
        /// Borrar un Departamento
        ///</summary>
        ///<remarks>
        /// Se utiliza para borrar un Departemento
        ///</remarks>
        /// <param name="id">ID (IdDepartamento) del objeto</param>
        /// <response code="200">Ok. Se devuelve el objeto solicitado</response>
        /// <response code="404">Error. No se encontro el objeto :c</response>
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