using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyShopBackend.Models;

namespace MyShopBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryDocumentsController : ControllerBase
    {
        private readonly DataContext _context;

        public InventoryDocumentsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InventoryDocument>> GetInventoryDocuments()
        {
            return _context.InventoryDocuments.Include(d => d.Product).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<InventoryDocument> GetInventoryDocument(int id)
        {
            var document = _context.InventoryDocuments.Include(d => d.Product).FirstOrDefault(d => d.Id == id);
            if (document == null)
            {
                return NotFound();
            }
            return document;
        }

        [HttpPost]
        public ActionResult<InventoryDocument> AddInventoryDocument(InventoryDocument document)
        {
            _context.InventoryDocuments.Add(document);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetInventoryDocument), new { id = document.Id }, document);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInventoryDocument(int id, InventoryDocument updatedDocument)
        {
            if (id != updatedDocument.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedDocument).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInventoryDocument(int id)
        {
            var document = _context.InventoryDocuments.Find(id);
            if (document == null)
            {
                return NotFound();
            }

            _context.InventoryDocuments.Remove(document);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
