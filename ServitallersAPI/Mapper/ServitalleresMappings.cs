using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServitallersAPI.Models;
using ServitallersAPI.Models.Dtos;

namespace ServitallersAPI.Mapper
{
    public class ServitalleresMappings : Profile
    {
        public ServitalleresMappings()
        {
            CreateMap<VehicleBrand, VehicleBrandDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
        }
    }
}
