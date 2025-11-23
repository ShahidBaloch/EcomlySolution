using AutoMapper;
using Ecomly.Core.DTOs;
using Ecomly.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomly.Core.Mappers;

public class RegisterRequestMappingProfile : Profile
{
    public RegisterRequestMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>().ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(des => des.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(des => des.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
            .ForMember(des => des.Password, opt => opt.MapFrom(src => src.Password));
    }
}
