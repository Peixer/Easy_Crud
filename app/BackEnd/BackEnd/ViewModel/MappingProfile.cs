using System;
using AutoMapper;
using BackEnd.Model;

namespace BackEnd.ViewModel
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContaBancaria, ContaBancariaViewModel>()
                .ForMember(x => x.Poupanca, expression => expression.MapFrom(model => model.Tipo.HasFlag(TipoContaBancaria.Poupanca)))
                .ForMember(x => x.Corrente, expression => expression.MapFrom(model => model.Tipo.HasFlag(TipoContaBancaria.Corrente)));

            CreateMap<ContaBancariaViewModel, ContaBancaria>()
                .ForMember(x => x.Tipo, expression => expression.MapFrom(model => ConverterTipoContaBancaria(model)));

            CreateMap<Candidato, CandidatoViewModel>()
                .ForMember(x => x.AteQuatroHoras, expression => expression.MapFrom(model => model.Disponibilidade.HasFlag(TipoDisponibilidade.AteQuatroHoras)))
                .ForMember(x => x.AteSeisHoras, expression => expression.MapFrom(model => model.Disponibilidade.HasFlag(TipoDisponibilidade.AteSeisHoras)))
                .ForMember(x => x.AteOitoHoras, expression => expression.MapFrom(model => model.Disponibilidade.HasFlag(TipoDisponibilidade.AteOitoHoras)))
                .ForMember(x => x.MaisDeOitoHoras, expression => expression.MapFrom(model => model.Disponibilidade.HasFlag(TipoDisponibilidade.MaisDeOitoHoras)))
                .ForMember(x => x.FinaisDeSemana, expression => expression.MapFrom(model => model.Disponibilidade.HasFlag(TipoDisponibilidade.FinaisDeSemana)))
                .ForMember(x => x.Manha, expression => expression.MapFrom(model => model.HorarioDeTrabalho.HasFlag(TipoHorarioDeTrabalho.Manha)))
                .ForMember(x => x.Tarde, expression => expression.MapFrom(model => model.HorarioDeTrabalho.HasFlag(TipoHorarioDeTrabalho.Tarde)))
                .ForMember(x => x.Noite, expression => expression.MapFrom(model => model.HorarioDeTrabalho.HasFlag(TipoHorarioDeTrabalho.Noite)))
                .ForMember(x => x.Madrugada, expression => expression.MapFrom(model => model.HorarioDeTrabalho.HasFlag(TipoHorarioDeTrabalho.Madrugada)))
                .ForMember(x => x.Comercial, expression => expression.MapFrom(model => model.HorarioDeTrabalho.HasFlag(TipoHorarioDeTrabalho.Comercial)))
                .ForMember(x => x.ContaBancaria, opt => opt.MapFrom(s => Mapper.Map<ContaBancaria, ContaBancariaViewModel>(s.ContaBancaria)));

            CreateMap<CandidatoViewModel, Candidato>()
                .ForMember(x => x.Disponibilidade, expression => expression.MapFrom(model => ConverterTipoDisponibilidade(model)))
                .ForMember(x => x.HorarioDeTrabalho, expression => expression.MapFrom(model => ConverterTipoHorarioDeTrabalho(model)))
            .ForMember(x => x.ContaBancaria, opt => opt.MapFrom(model => Mapper.Map<ContaBancariaViewModel, ContaBancaria>(model.ContaBancaria)));

            CreateMap<Candidato, CandidatoResumidoViewModel>();
        }

        private TipoDisponibilidade ConverterTipoDisponibilidade(CandidatoViewModel model)
        {
            var tipoDisponibilidade = (TipoDisponibilidade)0;

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

        private TipoContaBancaria ConverterTipoContaBancaria(ContaBancariaViewModel model)
        {
            var tipoContaBancaria = (TipoContaBancaria)0;

            if (model.Corrente)
                tipoContaBancaria |= TipoContaBancaria.Corrente;

            if (model.Poupanca)
                tipoContaBancaria |= TipoContaBancaria.Poupanca;

            return tipoContaBancaria;
        }
    }
}
