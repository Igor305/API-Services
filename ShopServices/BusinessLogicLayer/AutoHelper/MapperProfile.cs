using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities.Exchange;
using DataAccessLayer.Entities.Shops;

namespace BusinessLogicLayer.AutoHelper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Shop, ShopModel>();
            CreateMap<RegionsLocalization, RegionsLocalizationModel>();
            CreateMap<DistrictsLocalization, DistrictsLocalizationModel>();
            CreateMap<CitiesLocalization, CitiesLocalizationModel>();
            CreateMap<StreetsLocalization, StreetsLocalizationModel>();
            CreateMap<ShopRegionLocalization, ShopRegionLocalizationModel>();
            CreateMap<EmployeesDirectory, EmployeesDirectoryModel>();
            CreateMap<ShopWorkTime, ShopWorkTimeModel>();
        }
    }
}
