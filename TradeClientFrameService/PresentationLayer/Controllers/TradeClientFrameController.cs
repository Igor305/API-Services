using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TradeClientFrameController : ControllerBase
    {
        private readonly ITradeClientFrameService _tradeClientFrameService;

        public TradeClientFrameController(ITradeClientFrameService tradeClientFrameService)
        {
            _tradeClientFrameService = tradeClientFrameService;
        }
        [HttpGet]
        public void Draw()
        {
            _tradeClientFrameService.Drawtext();
        }
    }
}
