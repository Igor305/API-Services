using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> getAllInOneImage(int id)
        {
            await _tradeClientFrameService.getAllInOneImage(id);

            Byte[] file_path = System.IO.File.ReadAllBytes(@"Plan.png");                                                                                                                                                                 //  FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/png";
            string file_name = "Plan.png";
            return File(file_path, file_type, file_name);
        }

        [HttpGet("day/{id}")]
        public async Task<IActionResult> getImagePerDay(int id)
        {
            await _tradeClientFrameService.getImagePerDay(id);

            Byte[] file_path = System.IO.File.ReadAllBytes(@"PlanDay.png");                                                                                                                                                                 //  FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/png";
            string file_name = "PlanDay.png";
            return File(file_path, file_type, file_name);        
        }

        [HttpGet("month/{id}")]
        public async Task<IActionResult> getImagePerMonth(int id)
        {
            await _tradeClientFrameService.getImagePerMonth(id);

            Byte[] file_path = System.IO.File.ReadAllBytes(@"PlanMonth.png");                                                                                                                                                                 //  FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/png";
            string file_name = "PlanMonth.png";
            return File(file_path, file_type, file_name);
        }

        [HttpGet("forecast/{id}")]
        public async Task<IActionResult> getImagePerForecast(int id)
        {
            await _tradeClientFrameService.getImagePerForecast(id);

            Byte[] file_path = System.IO.File.ReadAllBytes(@"PlanForecast.png");                                                                                                                                                                 //  FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/png";
            string file_name = "PlanForecast.png";
            return File(file_path, file_type, file_name);
        }
    }
}
