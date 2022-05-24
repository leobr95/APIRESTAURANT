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
    public class ClientesController : ControllerBase
    {
        private readonly FacturaContext _context;

        public ClientesController(FacturaContext context)
        {
            _context = context;
        }
        //read
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetEditorialItems()
        {
           
            return await _context.ClienteItems.ToListAsync();
        
        
        }

        //detalle
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetEditorialItem(int id)
        {
            var clienteItem = await _context.ClienteItems.FindAsync(id);

            if(clienteItem == null)
            {
                return NotFound();
            }
            return clienteItem;          
           
        }

        //ENVIO
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostEditorial(Cliente item)
        {
            _context.ClienteItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEditorialItem), new { id = item.ClientelId}, item);
        }

        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEditorial(int id, Cliente item)
        {
            if(id != item.ClientelId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEditorialItem), new { id = item.ClientelId }, item);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEditorial(int id)
        {
            var clienteItem = await _context.ClienteItems.FindAsync(id);

            _context.Remove(clienteItem).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return Ok(clienteItem);         
        }

    }
}
