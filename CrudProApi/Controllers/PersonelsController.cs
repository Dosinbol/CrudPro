using CrudProApi.Core;
using CrudProApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudProApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonels()
        {
            return Ok(await _unitOfWork.Personel.AllAsync());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var personel = await _unitOfWork.Personel.GetByIdAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            return Ok(personel);
        }

        [HttpPost]
        [Route("CreatePersonel")]
        public async Task<IActionResult> CreatePersonel(Personel personel)
        {
            await _unitOfWork.Personel.AddAsync(personel);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("UpdatePersonel")]
        public async Task<IActionResult> UpdatePersonel(Personel personel)
        {
            var select = await _unitOfWork.Personel.GetByIdAsync(personel.Id);
            if (select == null)
            {
                return NotFound();
            }
            await _unitOfWork.Personel.UpdateAsync(personel);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("DeletePersonel")]
        public async Task<IActionResult> DeletePersonel(int id)
        {
            var personel = await _unitOfWork.Personel.GetByIdAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            await _unitOfWork.Personel.DeleteAsync(personel);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
