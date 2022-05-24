using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoClientesController : ControllerBase
    {
        private readonly FacturaContext _context;

        public ConsumoClientesController(FacturaContext context)
        {
            _context = context;
        }
        //read

        [HttpGet("{fechaInicio}/{fechafin}/{monto}")]
        public async Task<ActionResult<IEnumerable<ConsumoCliente>>> GetFacturaItems(string fechaInicio, string fechaFin, int monto)
        {

            return await _context.ConsumoCliente.FromSqlRaw("exec dbo.Consulta_ConsumoClientes @fechaInico = " + fechaInicio + ", @fechaFin ="+ fechaFin + ", @monto =" + monto + "").ToListAsync();
        }

        //detalle
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Factura>> GetFacturaItem(int id)
        //{
        //    var facturaItem = await _context.FacturaItems.FindAsync(id);

        //    if(facturaItem == null)
        //    {
        //        return NotFound();
        //    }
        //    return facturaItem;                   
        //}

        //ENVIO
        //[HttpPost]
        //public async Task<ActionResult<Factura>> PostBook(Factura item)
        //{
        //    _context.FacturaItems.Add(item);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetFacturaItem), new { id = item.FacturaId}, item);
        //}

        ////Update
        //[HttpPut("{id}")]
        //public async Task<ActionResult> PutBook(int id, Factura item)
        //{
        //    if(id != item.FacturaId)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(item).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetFacturaItem), new { id = item.FacturaId }, item);
        //}

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEditorial(int id)
        {
            var facturaItem = await _context.FacturaItems.FindAsync(id);

            _context.Remove(facturaItem).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return Ok(facturaItem);
        }

    }
}
