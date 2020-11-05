using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThreeApi.Repositories;

namespace ThreeApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryRepository _summaryRepository;

        public SummaryController(ISummaryRepository summaryRepository)
        {
            this._summaryRepository = summaryRepository;
        }

        public async Task<IActionResult> Get()
        {
            var result = await _summaryRepository.GetCompanySummary();
            return Ok(result);
        }
    }
}
