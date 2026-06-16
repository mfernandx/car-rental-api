using LocadoraDeCarrosAPI.Data;
using LocadoraDeCarrosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarrosAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {

        private readonly AppDbContext _context;

        public RentalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("calcular")]
        public async Task<IActionResult> Calcular(Rental request)
        {
            var car = await _context.Cars.FindAsync(request.CarId);

            if (car == null)
                return NotFound("Carro não encontrado");

            int dias = (request.EndDate - request.StartDate).Days;

            if (dias <= 0)
                return BadRequest("Período inválido");

            decimal subtotal = dias * car.DailyRate;

            decimal desconto = 0;

            if (dias >= 7)
                desconto = 0.10m;
            else if (dias >= 3)
                desconto = 0.05m;

            decimal valorFinal = subtotal - (subtotal * desconto);

            return Ok(new
            {
                carro = $"{car.Brand} - {car.Model}",
                periodo = $"{request.StartDate:dd/MM/yyyy} até {request.EndDate:dd/MM/yyyy}",
                valorDiaria = car.DailyRate,dias,subtotal,desconto = desconto * 100,valorFinal
            });
        }
    }
}
