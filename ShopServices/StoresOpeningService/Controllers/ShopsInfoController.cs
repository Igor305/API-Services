using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoresOpeningService.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
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
        /// <returns></returns>
        [HttpGet]
        public async Task<ShopsInfoResponseModel> getAllInfo()
        {
            ShopsInfoResponseModel shopsInfoResponseModel = await _shopsInfoService.getInfoForAllShops();

            return shopsInfoResponseModel;
        }

        /// <summary>
        /// Cписок магазинів із зазначеним статусом
        /// </summary>
        /// <param name="statusId">Номер статусу</param>
        /// <returns></returns>
        [HttpGet("status")]
        public async Task<ShopsInfoResponseModel> getAllInfo([FromQuery] int statusId)
        {
            ShopsInfoResponseModel shopsInfoResponseModel = await _shopsInfoService.getInfoForShopsByStatus(statusId);

            return shopsInfoResponseModel;
        }
    }
}
