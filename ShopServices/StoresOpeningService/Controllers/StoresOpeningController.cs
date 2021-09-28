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
    [Route("api/[controller]")]
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
        /// <param name="key">Ключ</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     http://shop-services.avrora.lan/api/storesOpening?key=exampleKey
        ///
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<ShopsOpeningResponseModel> getAllStoresOpening([FromQuery] string key)
        {
            ShopsOpeningResponseModel shopsOpeningResponseModel = await _shopService.getAllStoresOpening(key);

            return shopsOpeningResponseModel;
        }
        /// <summary>
        /// Cписок відкриттів у періоді
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="from">Початкова дата</param>
        /// <param name="till">Кінцева дата</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     http://shop-services.avrora.lan/api/storesOpening/period?key=exampleKey&amp;from=2021-09-28
        ///
        /// </remarks>
        /// <returns></returns>
        [HttpGet("period")]
        public async Task<ShopsOpeningResponseModel> getAllStoresOpening([FromQuery] string key, [FromQuery]DateTime from, [FromQuery]DateTime till)
        {
            ShopsOpeningResponseModel shopsOpeningResponseModel = await _shopService.getStoresOpeningForMonth(key,from,till);

            return shopsOpeningResponseModel;
        }
    }
}
