using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoresOpeningService.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class storesOpeningController : ControllerBase
    {
        private readonly IShopsOpeningService _shopService;

        public storesOpeningController(IShopsOpeningService shopsService)
        {
            _shopService = shopsService;
        }
        /// <summary>
        /// Cписок відкриттів у майбутньому
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ShopsResponseModel>> getAllStoresOpening()
        {
            List<ShopsResponseModel> shopsResponseModels = await _shopService.getAllStoresOpening();

            return shopsResponseModels;
        }
        /// <summary>
        /// Cписок відкриттів у періоді
        /// </summary>
        /// <param name="from">Початкова дата</param>
        /// <param name="till">Кінцева дата</param>
        /// <returns></returns>
        [HttpGet("period")]
        public async Task<List<ShopsResponseModel>> getAllStoresOpening([FromQuery]DateTime from, [FromQuery]DateTime till)
        {
            List<ShopsResponseModel> shopsResponseModels = await _shopService.getStoresOpeningForMonth(from,till);

            return shopsResponseModels;
        }
    }
}
