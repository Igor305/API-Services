using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response
{
    public class ShopsOpeningResponseModel
    {
        public List<ShopOpeningModel> shopOpeningModels { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// Текст помилки
        /// </summary>
        public string Message { get; set; }

        public ShopsOpeningResponseModel()
        {
            shopOpeningModels = new List<ShopOpeningModel>();
        }
    }
}
