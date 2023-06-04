using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TaskWebAPI.DAL.EFCore;
using TaskWebAPI.Entities.Dtos.Cars;
using TaskWebAPI.Entities;
using TaskWebAPI.Entities.Dtos.Brands;

namespace TaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrandsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Brands.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode((int)HttpStatusCode.OK, result);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.Brands.Where(b => b.Id == id).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode((int)HttpStatusCode.OK, result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto brandDto)
        {
            Brand brand = new Brand()
            {
                Name = brandDto.Name,
            };
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateBrandDto updateBrandDto)
        {

            var result = await _context.Brands.FindAsync(id);
            if (result == null) { return NotFound(); }
            result.Name= updateBrandDto.Name;
            result.Id= updateBrandDto.Id;
            

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Brands.FindAsync(id);
            if (result == null) return BadRequest(new
            {
                StatusCode = 201,
                Message = "Tapilmadi"
            });
            _context.Brands.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
