using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CheckList.Data;
using CheckList.Models;
using Microsoft.AspNetCore.Authorization;

namespace CheckList.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TasksController(ApplicationDbContext DB)
        {
            _db = DB;
        }

        // GET: api/Tasks
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CheckList.Models.Task>>> GetTasks(Guid id)
        {
            return await _db.Tasks.Where(w=>w.TaskGroupId == id).ToListAsync();
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(Guid id, CheckList.Models.Task task)
        {
            if (id != task.ID)
            {
                return BadRequest();
            }

            _db.Entry(task).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        // POST: api/Tasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CheckList.Models.Task>> PostTask(CheckList.Models.Task task)
        {
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.ID }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CheckList.Models.Task>> DeleteTask(Guid id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();

            return task;
        }

        private bool TaskExists(Guid id)
        {
            return _db.Tasks.Any(e => e.ID == id);
        }
    }
}
