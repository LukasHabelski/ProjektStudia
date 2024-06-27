using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyShopBackend.Models;

namespace MyShopBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly DataContext _context;

        public InventoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InventoryItem>> GetInventoryItems()
        {
            return _context.Inventory.Include(i => i.Product).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<InventoryItem> GetInventoryItem(int id)
        {
            var item = _context.Inventory.Include(i => i.Product).FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<InventoryItem> AddInventoryItem(InventoryItem item)
        {
            _context.Inventory.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetInventoryItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInventoryItem(int id, InventoryItem updatedItem)
        {
            if (id != updatedItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedItem).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInventoryItem(int id)
        {
            var item = _context.Inventory.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Inventory.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
