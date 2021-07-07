using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response
{
    public class ShopsInfoResponseModel
    {
        public List<ShopInfoModel> shopInfoModels { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }

        public ShopsInfoResponseModel()
        {
            shopInfoModels = new List<ShopInfoModel>();
        }
    }
}
