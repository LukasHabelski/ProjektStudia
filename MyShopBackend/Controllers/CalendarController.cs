using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyShopBackend.Models;

namespace MyShopBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly DataContext _context;

        public CalendarController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CalendarTask>> GetTasks()
        {
            return _context.CalendarTasks.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CalendarTask> GetTask(int id)
        {
            var task = _context.CalendarTasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public ActionResult<CalendarTask> AddTask(CalendarTask task)
        {
            _context.CalendarTasks.Add(task);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, CalendarTask updatedTask)
        {
            if (id != updatedTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedTask).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.CalendarTasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.CalendarTasks.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
