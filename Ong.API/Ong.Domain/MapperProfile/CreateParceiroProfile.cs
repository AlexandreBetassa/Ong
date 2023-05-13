﻿using AutoMapper;
using Ong.Domain.Command.Parceiros.CreateParceiro;
using Ong.Domain.Entities;

namespace Ong.Domain.MapperProfile
{
    public class CreateParceiroProfile : Profile
    {
        public CreateParceiroProfile()
        {
            CreateMap<CreateParceiroCommand, ParceiroOng>()
                .ForMember(dest => dest.UrlLogotipo, src => src.MapFrom(opt => opt.UrlLogotipo))
                .ForMember(dest => dest.Nome, src => src.MapFrom(opt => opt.Nome));
        }
    }
}
