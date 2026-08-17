using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;

namespace DoceCantinho.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoceController : Controller
    {
        private readonly IDoceService _doceService;

        public DoceController(IDoceService DoceService)
        {
            _doceService = DoceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoceDto>>> GetAll()
        {
            var doce = await _doceService.GetAllAsync();
            return Ok(doce);
        }

        /// <summary>
        /// Busca Game especifico
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("{id}")]
        public async Task<ActionResult<DoceDto>> GetById(int id)
        {
            var doce = await _doceService.GetByIdAsync(id);
            if (doce == null) return NotFound(new { message = "Doce não encontrado" });
            return Ok(doce);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        // From body é o corpo da requisição, ou seja, os dados que estão sendo enviados para criar um novo game
        /// <summary>
        /// Cria um novo game
        /// </summary>
        /// 
        public async Task<ActionResult<DoceDto>> Create([FromBody] CreateDoceDto createDoceDto)
        {
            var doce = await _doceService.CreateAsync(createDoceDto);
            return CreatedAtAction(nameof(GetById), new { id = doce.Id }, doce);

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        /// <summary>
        /// Atualiza um game existente
        /// </summary>
        /// ´<param name="id"></param>
        /// <param name="dto"></param>
        public async Task<ActionResult<DoceDto>> Update(int id, [FromBody] UpdateDoceDto dto)
        {
            var doce = await _doceService.UpdateAsync(id, dto);
            if (doce == null) return NotFound(new { message = " doce não encontrado" });
            return Ok(doce);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Delete(int id)
        {
            var delete = await _doceService.DeleteAsync(id);
            if (!delete) return NotFound(new { message = "doce não encontrado" });
            return NoContent();
        }
    }
}
