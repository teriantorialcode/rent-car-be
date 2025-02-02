using System;
using AutoMapper;
using rent_car_api.BindingModels;
using rent_car_api.Models;

namespace rent_car_api.Mapper
{
	public class ObjectMapperProfile : Profile
	{
        public ObjectMapperProfile()
        {
            CreateMap<CarInsertModel, Car>();
        }
    }
}

