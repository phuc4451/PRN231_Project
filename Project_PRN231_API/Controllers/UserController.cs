using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Project_PRN231_API.Models;
using Project_PRN231_API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Project_PRN231_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly FarmManagement2_PRN231Context _context;

    public UserController(FarmManagement2_PRN231Context context)
    {
        _context = context;
    }

    [HttpGet]
    [EnableQuery]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return _context.Users.Include(u => u.Role).ToList(); 
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = _context.Users
            .Include(u => u.Role)
            .Include(u => u.CareProcesses)
                .ThenInclude(cp => cp.Crop)
            .Include(u => u.PlantProcesses)
                .ThenInclude(pp => pp.Crop)
            .Include(u => u.HarvestProcesses)
                .ThenInclude(hp => hp.Crop)
            .Include(u => u.HarvestProcesses)
                .ThenInclude(hp => hp.StorageAllocations)
            .FirstOrDefault(u => u.UserId == id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        if (id != user.UserId)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPost("Login")]
    [EnableQuery]
    public async Task<IActionResult> Login(User user)
    {
        var existingUser = _context.Users.Include(u => u.Role).Include(a=>a.CareProcesses).Include(b=>b.PlantProcesses).Include(c=>c.HarvestProcesses)

            .FirstOrDefault(u => u.Username == user.Username);
        if (existingUser != null)
        {
            return Ok(existingUser);
        }
        return Unauthorized("Invalid username or password");
    }
}
