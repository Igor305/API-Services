using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.AutoHelper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ItExecutionPlanShop, ItExecutionPlanShopModel>();
        }
    }
}
