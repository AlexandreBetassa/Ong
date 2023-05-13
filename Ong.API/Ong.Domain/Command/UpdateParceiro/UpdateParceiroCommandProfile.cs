using AutoMapper;
using Ong.Domain.Entities;

namespace Ong.Domain.Command.UpdateParceiro
{
    public class UpdateParceiroCommandProfile : Profile
    {
        public UpdateParceiroCommandProfile()
        {
            CreateMap<UpdateParceiroCommand, ParceirosOng>()
                .ForMember(dest => dest.UrlLogotipo, src => src.MapFrom(opt => opt.UrlLogotipo))
                .ForMember(dest => dest.Id, src => src.MapFrom(opt => opt.Id))
                .ForMember(dest => dest.Nome, src => src.MapFrom(opt => opt.Nome));
        }
    }
}