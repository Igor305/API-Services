using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoresOpeningService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class shopsInfoController : ControllerBase
    {
        private readonly IShopsInfoService _shopsInfoService;

        public shopsInfoController(IShopsInfoService shopsInfoService)
        {
            _shopsInfoService = shopsInfoService;
        }

        /// <summary>
        /// Cписок всіх магазинів
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     http://shop-services.avrora.lan/api/shopsInfo?key=exampleKey
        ///
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<ShopsInfoResponseModel> getAllInfo([FromQuery] string key)
        {
            ShopsInfoResponseModel shopsInfoResponseModel = await _shopsInfoService.getInfoForAllShops(key);

            return shopsInfoResponseModel;
        }

        /// <summary>
        /// Cписок магазинів із зазначеним статусом
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="statusId">Номер статусу</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     http://shop-services.avrora.lan/api/shopsInfo/status?key=exampleKey&amp;statusId=25
        ///
        /// </remarks>
        /// <returns></returns>
        [HttpGet("status")]
        public async Task<ShopsInfoResponseModel> getAllInfo([FromQuery] string key, [FromQuery] int statusId)
        {
            ShopsInfoResponseModel shopsInfoResponseModel = await _shopsInfoService.getInfoForShopsByStatus(key,statusId);

            return shopsInfoResponseModel;
        }
    }
}
