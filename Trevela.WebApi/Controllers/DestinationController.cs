using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Trevela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet("GetListAll")]
        public IActionResult DestinationList()
        {
            var values = _destinationService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var values = _destinationService.TGetById(id);
            if (values == null)
            {
                return NotFound("Tur Bulunamadı !");
            }
            return Ok(values);
        }

        [HttpPost("Add")]
        public IActionResult DestinationAdd(Destination destination)
        {
            _destinationService.TInsert(destination);

            return Created("", "Kayıt Eklendi");
        }

        [HttpDelete("Delete")]
        public IActionResult DestinationDelete(int id)
        {
            var values = _destinationService.TGetById(id);
            if (values == null)
            {
                return NotFound("Tur bulunamadı");
            }
            _destinationService.TDelete(id);
            return Ok("Silme başarılı");
        }

        [HttpPut("Update")]
        public IActionResult Update(Destination destination)
        {
            _destinationService.TUpdate(destination);
            return Ok("Tur güncelleme başarılı");
        }
    }
}
