using AutoMapper;
using BackEnd.Model;

namespace BackEnd.ViewModel
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidato, CandidatoViewModel>();
            CreateMap<CandidatoViewModel, Candidato>();
        }
    }
}
