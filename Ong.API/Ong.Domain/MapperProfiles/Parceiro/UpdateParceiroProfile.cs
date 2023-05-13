using AutoMapper;
using Ong.Domain.Command.Parceiros.UpdateParceiro;
using Ong.Domain.Entities;

namespace Ong.Domain.MapperProfiles.Parceiro
{
    public class UpdateParceiroProfile : Profile
    {
        public UpdateParceiroProfile()
        {
            CreateMap<UpdateParceiroCommand, ParceiroOng>()
                .ForMember(dest => dest.UrlLogotipo, src => src.MapFrom(opt => opt.UrlLogotipo))
                .ForMember(dest => dest.Id, src => src.MapFrom(opt => opt.Id))
                .ForMember(dest => dest.Nome, src => src.MapFrom(opt => opt.Nome));
        }
    }
}