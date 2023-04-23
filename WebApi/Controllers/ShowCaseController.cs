using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Services;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class ShowcaseController : ControllerBase
    {
        private readonly ShowcaseRepo _showcaseRepo;

        public ShowcaseController(ShowcaseRepo showcaseRepo)
        {
            _showcaseRepo = showcaseRepo;
        }

        [HttpGet("Latest")]
        public async Task<ActionResult> Latest()
        {
            return Ok(await _showcaseRepo.GetLatestShowcaseAsync());
        }

    }
}
