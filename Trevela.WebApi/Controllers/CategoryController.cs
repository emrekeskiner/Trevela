using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Trevela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetListAll")]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var values = _categoryService.TGetById(id);
            if (values == null) {
                return NotFound("Kategori Bulunamadı !");           
            }
            return Ok(values);
        }

        [HttpPost("Add")]
        public IActionResult CategoryAdd(Category category)
        {
            _categoryService.TInsert(category);

            return Created("",$"{category.CategoryName} Eklendi");
        }

        [HttpDelete("Delete")]
        public IActionResult CategoryDelete(int id)
        {
            var values = _categoryService.TGetById(id);
            if (values == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            _categoryService.TDelete(id);
            return Ok($"{values.CategoryName} başarıyla silindi.");
        }

        [HttpPut("Update")]
        public IActionResult Update(Category category)
        {
            _categoryService.TUpdate(category);
            return Ok("Kategori güncelleme başarılı");
        }
    }
}
