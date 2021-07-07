namespace BusinessLogicLayer.Models
{
    public class ShopInfoModel
    {
        public int? ShopNumber { get; set; }
        public int StatusId { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string AddressComment { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ShopWorkTimeString { get; set; }
        public string ShopRegion { get; set; }
        public string TerritorialManager { get; set; }
        public string RegionalManager { get; set; }
        public string Administrator { get; set; }
        public string DeputyAdministrator { get; set; }
        public string WorkPhoneNumber { get; set; }
    }
}
