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
public class CropController : ControllerBase
{
	private readonly FarmManagement2_PRN231Context _context; // Replace with your DbContext

	public CropController(FarmManagement2_PRN231Context context)
	{
		_context = context;
	}

	// GET: api/Crops
	[HttpGet]
	[EnableQuery]
	public async Task<ActionResult<IEnumerable<Crop>>> GetCrops()
	{
		var listCrops = _context.Crops.Include(x => x.CareProcesses).Include(x => x.HarvestProcesses).Include(x => x.PlantProcesses);
		return Ok(listCrops);
	}

	// GET: api/Crops/5
	[HttpGet("{id}")]
	public async Task<ActionResult<Crop>> GetCrop(int id)
	{
		var crop = _context.Crops.Include(x => x.CareProcesses).Include(x => x.HarvestProcesses).Include(x => x.PlantProcesses).FirstOrDefault(a=>a.CropId == id);

		if (crop == null)
		{
			return NotFound();
		}

		return crop;
	}

	// POST: api/Crops
	[HttpPost]
	public async Task<ActionResult<Crop>> PostCrop(Crop crop)
	{
		_context.Crops.Add(crop);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetCrop), new { id = crop.CropId }, crop);
	}

	// PUT: api/Crops/5
	[HttpPut("{id}")]
	public async Task<IActionResult> PutCrop(int id, Crop crop)
	{
		if (id != crop.CropId)
		{
			return BadRequest();
		}

		_context.Entry(crop).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!CropExists(id))
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

	// DELETE: api/Crops/5
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteCrop(int id)
	{
		var crop = await _context.Crops.FindAsync(id);
		if (crop == null)
		{
			return NotFound();
		}

		_context.Crops.Remove(crop);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool CropExists(int id)
	{
		return _context.Crops.Any(e => e.CropId == id);
	}
}
