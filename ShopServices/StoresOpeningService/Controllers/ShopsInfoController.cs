using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoresOpeningService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopsInfoController : ControllerBase
    {
        private readonly IShopsInfoService _shopsInfoService;

        public ShopsInfoController (IShopsInfoService shopsInfoService)
        {
            _shopsInfoService = shopsInfoService;
        }

        [HttpGet]

        public async Task<ShopsInfoResponseModel> getAllInfo()
        {
            ShopsInfoResponseModel shopsInfoResponseModel = await _shopsInfoService.getInfoForAllShops();

            return shopsInfoResponseModel;
        }

    }
}
