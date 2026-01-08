using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Doist.Controllers;


[Route("api/[controller]")] // це шо 
[ApiController] // забыл добавить )0)

public class TaskController : ControllerBase
{
    private readonly TasksContext _context;

    public TaskController(TasksContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Task>>> GetAllTasks()
    {
        var tasks = await _context.Tasks.ToListAsync();
        return tasks;
    }
    [HttpPost]
    public async Task<ActionResult<Task>> AddTask(Task task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTask),new {id = task.Id},task);

    }
    [HttpGet("Id")] // forgot добавить blyять
    public async Task<ActionResult<Task>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if(task.Equals(null))
        {
            return NotFound();
        }
        return task;
    }
    [HttpDelete("id")]
    public async Task<ActionResult> RemoveTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if(task != null)
        {
            _context.Tasks.Remove(task);
            return Ok();
        }
        _context.SaveChanges();
        return NotFound();
        

    } 
    [HttpPut("id")]
    public async Task<ActionResult<Task>> UpdateTask(Task task,int id)
    {
        var oldTask = await _context.Tasks.FindAsync(id);
        if(oldTask.Equals(null))
        {
            return NotFound();
        }
        oldTask.Name
    }
}
/*

get
post
put
delete
*/
