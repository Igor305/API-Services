using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetImagesController : ControllerBase
    {
        private readonly ITradeClientFrameService _tradeClientFrameService;

        public GetImagesController(ITradeClientFrameService tradeClientFrameService)
        {
            _tradeClientFrameService = tradeClientFrameService;
        }

        [HttpGet("{id}")]
        public async Task<VirtualFileResult> GetImage(int id)
        {
            await _tradeClientFrameService.getImages(id);

             var df = File("PlanDay.jpg", "image/jpeg");

            return df;
            /* var filepath = Path.Combine("~/Files", "PlanDay.jpg");
             return File(filepath, "image/jpg", "PlanDay.jpg");*/
        }
    }
}
