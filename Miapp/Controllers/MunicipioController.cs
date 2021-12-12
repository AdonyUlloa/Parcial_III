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
    /// Wed API para gestion de Municipios El Salvador
    ///</summary>
    [ApiController]
    [Route("[controller]")]
    public class MunicipioController: Controller
    {
        private DatabaseContext _context;

        public MunicipioController(DatabaseContext context)
        {
            _context=context;
        }

        /// <summary>
        /// Todos los Municipios
        ///</summary>
        ///<remarks>
        /// Aqui se optienen todos los Municipios guardados
        ///</remarks>
        /// <response code="200">Ok. Se devuelve el objeto solicitado</response>
        /// <response code="404">Error. No se encontro el objeto :c</response>
        [HttpGet]
        public async Task<ActionResult<List<Municipio>>> GetMunicipio()
        {
            var municipios = await _context.Municipios.ToListAsync();
            return municipios; 
        }

        /// <summary>
        /// Ver Municipios por ID
        ///</summary>
        ///<remarks>
        /// Aqui se optinen el municipio dependiendo del ID solicitado
        ///</remarks>
        /// <param name="id">ID (IdMunicipio) del objeto</param>
        /// <response code="200">Ok. Se devuelve el objeto solicitado</response>
        /// <response code="404">Error. No se encontro el objeto :c</response>
         [HttpGet("{id}")]
        public async Task<ActionResult<Municipio>> GetMunicipioID(int id)
        {
            var municipios = await _context.Municipios.FindAsync(id);
            if(municipios==null)
            {
                return NotFound();
            }
            return municipios;
        }

        /// <summary>
        /// Registro de nuevo municipio
        ///</summary>
        ///<remarks>
        /// Aqui puedes guardar un nuevo Municipio
        ///</remarks>
        /// <response code="200">Ok. Se devuelve el objeto solicitado</response>
        /// <response code="404">Error. No se encontro el objeto :c</response>
        [HttpPost]
        public async Task<ActionResult<Municipio>> PostMunicipio(Municipio municipio)
        {
            _context.Municipios.Add(municipio);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMunicipioID", new{id=municipio.municipioID}, municipio);
        }

        /// <summary>
        /// Editar un municipio ya guardado
        ///</summary>
        ///<remarks>
        /// Aqui puedes editar cualquier muncipio ya guadado (requiere ID)
        ///</remarks>
        
        /// <response code="200">Ok. Se devuelve el objeto solicitado</response>
        /// <response code="404">Error. No se encontro el objeto :c</response>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Municipio>> PutMunicipio(int id, Municipio municipio)
        {
            if(id != municipio.municipioID)
            {
                return BadRequest();
            }
            _context.Entry(municipio).State= EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!MunicipioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetMunicipioID", new{id=municipio.municipioID}, municipio);
        }

        /// <summary>
        /// Borrar un municipio
        ///</summary>
        ///<remarks>
        /// Se utiliza para borrar un municipio
        ///</remarks>
        /// <param name="id">ID (IdMunicipio) del objeto</param>
        /// <response code="200">Ok. Se devuelve el objeto solicitado</response>
        /// <response code="404">Error. No se encontro el objeto :c</response>
        [HttpDelete("id:int")]
         public async Task<ActionResult<Municipio>> DeleteMunicipio(int id)
         {
             var municipio = await _context.Municipios.FindAsync(id);
             if(municipio==null)
             {
                 return NotFound();
             }

             _context.Municipios.Remove(municipio);
             await _context.SaveChangesAsync();

             return municipio;
         }

        private bool MunicipioExists(int id)
        {
            return _context.Municipios.Any(d=>d.municipioID==id);
        }
    }
}