using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UslugaController : ControllerBase
    {
        private readonly IUslugaService _uslugaService;

        public UslugaController(IUslugaService uslugaService)
        {
            _uslugaService = uslugaService;
        }

        [HttpGet]
        public ActionResult<List<UslugaDTO>> GetAll([FromQuery] string? fraza)
        {
            var uslugi = _uslugaService.get();

            if (!string.IsNullOrEmpty(fraza))
            {
                uslugi = uslugi
                    .Where(u => u.nazwa != null &&
                                u.nazwa.Contains(fraza, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(uslugi);
        }

        [HttpGet("{id}")]
        public ActionResult<UslugaEntity> GetById(int id)
        {
            var usluga = _uslugaService.getById(id);
            if (usluga == null)
                return NotFound();

            return Ok(usluga);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UslugaDTO usluga)
        {
            _uslugaService.post(usluga);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, usluga); 
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UslugaDTO usluga)
        {
            var existing = _uslugaService.getById(id);
            if (existing == null)
                return NotFound();

            _uslugaService.put(id, usluga);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _uslugaService.getById(id);
            if (existing == null)
                return NotFound();

            _uslugaService.delete(id);
            return NoContent();
        }
    }
}
