namespace BusinessLogicLayer.Models
{
    /// <summary>
    /// Інформація по ТТ
    /// </summary>
    public class ShopInfoModel
    {
        /// <summary>
        /// Номер ТТ
        /// </summary>
        public int? ShopNumber { get; set; }
        /// <summary>
        /// Статуc
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// Область
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Район
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// Місто
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Вулиця
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Адреса
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Коментарій щодо адреси
        /// </summary>
        public string AddressComment { get; set; }
        /// <summary>
        /// Широта
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// Довгота
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// Час роботи ТТ
        /// </summary>
        public string ShopWorkTimeString { get; set; }
        /// <summary>
        /// Регіон
        /// </summary>
        public string ShopRegion { get; set; }
        /// <summary>
        /// Територіальний менеджер
        /// </summary>
        public string TerritorialManager { get; set; }
        /// <summary>
        /// Регіональний менеджер
        /// </summary>
        public string RegionalManager { get; set; }
        /// <summary>
        /// Адміністратор
        /// </summary>
        public string Administrator { get; set; }
        /// <summary>
        /// Заступник адміністратора
        /// </summary>
        public string DeputyAdministrator { get; set; }
        /// <summary>
        /// Номер ТТ
        /// </summary>
        public string WorkPhoneNumber { get; set; }
    }
}