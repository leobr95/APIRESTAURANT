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
    public class VentaMeserosController : ControllerBase
    {
        private readonly FacturaContext _context;

        public VentaMeserosController(FacturaContext context)
        {
            _context = context;
        }
        //read

        [HttpGet("{fechaInicio}/{fechafin}")]
        public async Task<ActionResult<IEnumerable<VentaMesero>>> GetFacturaItems(string fechaInicio, string fechaFin)
        {

            return await _context.VentaMesero.FromSqlRaw("exec dbo.Consulta_VentaMesero @fechaInico = " + fechaInicio + ", @fechaFin ="+ fechaFin + "").ToListAsync();
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
