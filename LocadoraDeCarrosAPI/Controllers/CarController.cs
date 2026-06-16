using LocadoraDeCarrosAPI.Data;
using LocadoraDeCarrosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarrosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _context.Cars.ToListAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
                return NotFound("Carro não encontrado.");

            return Ok(car);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Car carRequest)
        {
            var car = new Car(
                carRequest.Model,
                carRequest.Brand,
                carRequest.Year,
                carRequest.DailyRate
            );

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = car.CarId }, car);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int carId, [FromBody] Car request)
        {
            var car = await _context.Cars.FindAsync(carId);

            if (car == null)
                return NotFound("Carro não encontrado.");

            car.UpdateCar(
                request.Model,
                request.Brand,
                request.Year,
                request.DailyRate
            );

            await _context.SaveChangesAsync();

            return Ok(car);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
                return NotFound("Carro não encontrado.");

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
