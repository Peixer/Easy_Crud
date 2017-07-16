using System;
using AutoMapper;
using BackEnd.Model;

namespace BackEnd.ViewModel
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidato, CandidatoViewModel>()
                .ForMember(x => x.AteQuatroHoras, expression => expression.MapFrom(model => model.Disponibilidade.HasFlag(TipoDisponibilidade.AteQuatroHoras)))
                .ForMember(x => x.AteSeisHoras, expression => expression.MapFrom(model => model.Disponibilidade.HasFlag(TipoDisponibilidade.AteSeisHoras)))
                .ForMember(x => x.AteOitoHoras, expression => expression.MapFrom(model => model.Disponibilidade.HasFlag(TipoDisponibilidade.AteOitoHoras)))
                .ForMember(x => x.MaisDeOitoHoras, expression => expression.MapFrom(model => model.Disponibilidade.HasFlag(TipoDisponibilidade.MaisDeOitoHoras)))
                .ForMember(x => x.FinaisDeSemana, expression => expression.MapFrom(model => model.Disponibilidade.HasFlag(TipoDisponibilidade.FinaisDeSemana)))
                .ForMember(x => x.Manha, expression => expression.MapFrom(model => model.HorarioDeTrabalho.HasFlag(TipoHorarioDeTrabalho.Manha)))
                .ForMember(x => x.Tarde, expression => expression.MapFrom(model => model.HorarioDeTrabalho.HasFlag(TipoHorarioDeTrabalho.Tarde)))
                .ForMember(x => x.Noite, expression => expression.MapFrom(model => model.HorarioDeTrabalho.HasFlag(TipoHorarioDeTrabalho.Noite) ))
                .ForMember(x => x.Madrugada, expression => expression.MapFrom(model => model.HorarioDeTrabalho.HasFlag(TipoHorarioDeTrabalho.Madrugada)))
                .ForMember(x => x.Comercial, expression => expression.MapFrom(model => model.HorarioDeTrabalho.HasFlag(TipoHorarioDeTrabalho.Comercial)));

            CreateMap<CandidatoViewModel, Candidato>()
                .ForMember(x => x.Disponibilidade, expression => expression.MapFrom(model => ConverterTipoDisponibilidade(model)))
                .ForMember(x => x.HorarioDeTrabalho, expression => expression.MapFrom(model => ConverterTipoHorarioDeTrabalho(model)));
        }

        private TipoDisponibilidade ConverterTipoDisponibilidade(CandidatoViewModel model)
        {
            var tipoDisponibilidade = (TipoDisponibilidade) 0;

            if (model.AteQuatroHoras)
                tipoDisponibilidade |= TipoDisponibilidade.AteQuatroHoras;

            if (model.AteSeisHoras)
                tipoDisponibilidade |= TipoDisponibilidade.AteSeisHoras;

            if (model.AteOitoHoras)
                tipoDisponibilidade |= TipoDisponibilidade.AteOitoHoras;

            if (model.MaisDeOitoHoras)
                tipoDisponibilidade |= TipoDisponibilidade.MaisDeOitoHoras;

            if (model.FinaisDeSemana)
                tipoDisponibilidade |= TipoDisponibilidade.FinaisDeSemana;

            return tipoDisponibilidade;
        }

        private TipoHorarioDeTrabalho ConverterTipoHorarioDeTrabalho(CandidatoViewModel model)
        {
            var tipoHorarioDeTrabalho = (TipoHorarioDeTrabalho)0;

            if (model.Manha)
                tipoHorarioDeTrabalho |= TipoHorarioDeTrabalho.Manha;

            if (model.Tarde)
                tipoHorarioDeTrabalho |= TipoHorarioDeTrabalho.Tarde;

            if (model.Noite)
                tipoHorarioDeTrabalho |= TipoHorarioDeTrabalho.Noite;

            if (model.Madrugada)
                tipoHorarioDeTrabalho |= TipoHorarioDeTrabalho.Madrugada;

            if (model.Comercial)
                tipoHorarioDeTrabalho |= TipoHorarioDeTrabalho.Comercial;

            return tipoHorarioDeTrabalho;
        }
    }
}
