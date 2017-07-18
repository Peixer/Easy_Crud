using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BackEnd.Data;
using BackEnd.Model;

namespace BackEnd.Service
{
    public class CandidatoService
    {
        public ICandidatoRepository CandidatoRepository { get; }

        int pagina = 1;
        const int TAMANHO_PAGINA = 4;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            CandidatoRepository = candidatoRepository;
        }

        public IEnumerable<Candidato> ObterCandidatos(Paginacao paginacao)
        {
            if (paginacao != null)
                paginacao.Pagina++;
            else
                paginacao = new Paginacao(pagina);

            var totalCandidatos = CandidatoRepository.Count();
            paginacao.TotalPaginas = (int)Math.Ceiling((double)totalCandidatos / TAMANHO_PAGINA);

            return CandidatoRepository
                .GetAll()
                .OrderBy(s => s.Id)
                .Skip((paginacao.Pagina - 1) * TAMANHO_PAGINA)
                .Take(TAMANHO_PAGINA)
                .ToList();
        }
    }
}