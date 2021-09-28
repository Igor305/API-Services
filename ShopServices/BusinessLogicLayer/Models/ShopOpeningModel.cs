using System;

namespace BusinessLogicLayer.Models
{
    /// <summary>
    /// Відкриття ТТ
    /// </summary>
    public class ShopOpeningModel
    {
        /// <summary>
        /// Номер ТТ
        /// </summary>
        public int? ShopNumber { get; set; }
        /// <summary>
        /// Дата відкриття
        /// </summary>
        public DateTime? OpenFrom { get; set; }
    }
}
