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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CheckList.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TaskGroupsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;


        public TaskGroupsController(ApplicationDbContext DB, UserManager<ApplicationUser> userManager)
        {
            _db = DB;
            _userManager = userManager;
        }

        // GET: api/TaskGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskGroup>>> GetTaskGroups()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            var model = await _db.TaskGroups.Where(w => w.AddByUserId == userId).ToListAsync();
            return model;
        }

        // GET: api/TaskGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskGroup>> GetTaskGroup(Guid id)
        {
            var taskGroup = await _db.TaskGroups.FindAsync(id);

            if (taskGroup == null)
            {
                return NotFound();
            }

            return taskGroup;
        }

        // PUT: api/TaskGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskGroup(Guid id, TaskGroup taskGroup)
        {
            if (id != taskGroup.ID)
            {
                return BadRequest();
            }

            _db.Entry(taskGroup).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskGroupExists(id))
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

        // POST: api/TaskGroups
        [HttpPost]
        public async Task<ActionResult<TaskGroup>> PostTaskGroup(TaskGroup taskGroup)
        {
            _db.TaskGroups.Add(taskGroup);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetTaskGroup", new { id = taskGroup.ID }, taskGroup);
        }

        // DELETE: api/TaskGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskGroup>> DeleteTaskGroup(Guid id)
        {
            var taskGroup = await _db.TaskGroups.FindAsync(id);
            if (taskGroup == null)
            {
                return NotFound();
            }

            _db.TaskGroups.Remove(taskGroup);
            await _db.SaveChangesAsync();

            return taskGroup;
        }

        private bool TaskGroupExists(Guid id)
        {
            return _db.TaskGroups.Any(e => e.ID == id);
        }
    }
}
