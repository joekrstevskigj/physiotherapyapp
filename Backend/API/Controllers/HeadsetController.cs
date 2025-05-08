namespace API.Controllers
{
    using API.DTOs.Response;
    using API.Interfaces.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class HeadsetController : ControllerBase
    {
        private readonly IHeadsetService headsetService;

        public HeadsetController(IHeadsetService headsetService)
        {
            this.headsetService = headsetService;
        }

        [HttpGet(nameof(GetHeadsetData))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<HeadsetDataDto>>> GetHeadsetData()
        {
            var result = await headsetService.GetAllHeadsetData().ConfigureAwait(false);

            if (result == null || result.Count == 0)
            {
                return NotFound("No headset data is avalible at this moment.");
            }

            return Ok(result);
        }
    }
}
