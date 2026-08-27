using AutoMapper;
using MyMango.Services.CouponAPI.Models;
using MyMango.Services.CouponAPI.Models.Dto;
using Microsoft.Extensions.Logging.Abstractions;
namespace MyMango.Services.CouponAPI 
{
    public class MappingConfig : Profile
    {
        //public static MapperConfiguration RegisterMaps()
        //{
        //    var mappingConfig = new MapperConfiguration(config =>
        //    {
        //        config.CreateMap<CouponDto, Coupon>();
        //        config.CreateMap<Coupon, CouponDto>();
        //    }, NullLoggerFactory.Instance);

        //    return mappingConfig;
        //}
        public MappingConfig()
        {
            CreateMap<CouponDto, Coupon>();
            CreateMap<Coupon, CouponDto>();
        }
    }
}
