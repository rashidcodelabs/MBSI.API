using AutoMapper;
using MBSI.Models.DataModels;
using MBSI.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.BL.Profiles
{
    public class UserProfile : Profile
    {
        #region Constructors
        public UserProfile()
        {
            ////For custome mapping
            //CreateMap<ProductDto, Product>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.ProductId, opt => opt.Ignore());
            //CreateMap<Product, ProductDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName));

            ////For default mapping
            //For Response mapping
            CreateMap<UserInfoModel, UserResponse>();
            CreateMap<UserResponse, UserInfoModel>();

            //CreateMap<UserInfoModel, UserRequest>();
            //CreateMap<UserRequest, UserInfoModel>();
        }
        #endregion
    }
}
