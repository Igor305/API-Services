using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoresOpeningService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoresOpeningController : ControllerBase
    {
        private readonly IShopsService _shopService;

        public StoresOpeningController(IShopsService shopsService)
        {
            _shopService = shopsService;
        }

        [HttpGet]
        public async Task<List<ShopsResponseModel>> getAllStoresOpening()
        {
            List<ShopsResponseModel> shopsResponseModels = await _shopService.getAllStoresOpening();

            return shopsResponseModels;
        }

        [HttpGet("period")]
        public async Task<List<ShopsResponseModel>> getAllStoresOpening([FromQuery]DateTime from, [FromQuery]DateTime till)
        {
            List<ShopsResponseModel> shopsResponseModels = await _shopService.getStoresOpeningForMonth(from,till);

            return shopsResponseModels;
        }
    }
}
