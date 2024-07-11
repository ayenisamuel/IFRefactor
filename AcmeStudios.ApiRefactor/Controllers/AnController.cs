using AcmeStudios.Core.Module.Studio.Dtos;
using AcmeStudios.Core.Module.Studio.Interface;
using AcmeStudios.Models.Domain.StudioItems;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AcemStudios.ApiRefactor.Controllers
{
    [Route("peoplespartnership/api/[controller]")]
    [ApiController]
    public class AnController : ControllerBase
    {
        private readonly IStudioService _studioService;
        public AnController(IStudioService studioService)
        {
            _studioService = studioService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var response = await _studioService.GetAllStudioHeaderItems();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _studioService.GetStudioItemById(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudioItemDto studioItem)
        {
            var response = await _studioService.AddStudioItem(studioItem);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudioItemDto studioItem)
        {
            var response = await _studioService.UpdateStudioItem(studioItem);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _studioService.DeleteStudioItem(id);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudioItemTypes()
        {
            var response = await _studioService.GetAllStudioItemTypes();

            return Ok(response);
        }
    }
}