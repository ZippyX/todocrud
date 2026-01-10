using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Doist.Models;
namespace Doist.Controllers;




[Route("api/[controller]")] // це шо 
[ApiController] // забыл добавить )0)

public class ProblemController : ControllerBase
{
    private readonly ProblemContext _context;

    public ProblemController(ProblemContext context)
    {
        _context = context;
    }

    [HttpGet] // endpoint
    public async Task<ActionResult<IEnumerable<Problem>>> GetAllProblems()
    {
        return await _context.Problems.ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Problem>> AddProblem(Problem task)
    {
        await _context.Problems.AddAsync(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProblem),new {id = task.Id},task);

    }
    [HttpGet("Id")] // forgot добавить blyять; endpoint
    public async Task<ActionResult<Problem>> GetProblem(int id)
    {
        var task = await _context.Problems.FindAsync(id);
        if(task.Equals(null))
        {
            return NotFound();
        }
        return task;
    }
    [HttpDelete("id")] // endpoint
    public async Task<ActionResult> RemoveProblem(int id)
    {
        var task = await _context.Problems.FindAsync(id);
        if(task != null)
        {
            _context.Problems.Remove(task);
            return Ok();
        }
        _context.SaveChanges();
        return NotFound();
        

    } 
    [HttpPut("id")] //endpoint
    public async Task<ActionResult<Problem>> UpdateProblem(Problem task,int id)
    {
        var oldTask = await _context.Problems.FindAsync(id);
        if(oldTask.Equals(null))
        {
            return NotFound();
        }
        oldTask.Name = task.Name;
        oldTask.Description = task.Description;
        _context.SaveChanges();
        return Ok();
    }
}



/*
get
post
put
delete
*
В теории, ендпоин называется именно так, т.к. это такой URL, по которому на запрос идёт ответ, т.е. диалог заканчивается
все получили, что хотели( ну или не совсем)

*/

