using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Data;
using BackEnd.Model;

namespace BackEnd.Service
{
    public class CandidatoService
    {
        public ICandidatoRepository CandidatoRepository { get; }
        
        const int TAMANHO_PAGINA = 10;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            CandidatoRepository = candidatoRepository;
        }

        public Tuple<IEnumerable<Candidato>, Paginacao> ObterCandidatos(int pagina)
        {
            var paginacao = new Paginacao(pagina);

            var totalCandidatos = CandidatoRepository.Count();
            paginacao.TotalPaginas = (int)Math.Ceiling((double)totalCandidatos / TAMANHO_PAGINA);

            return new Tuple<IEnumerable<Candidato>, Paginacao>(CandidatoRepository
                .GetAll()
                .OrderBy(s => s.Id)
                .Skip((paginacao.Pagina - 1) * TAMANHO_PAGINA)
                .Take(TAMANHO_PAGINA)
                .ToList(), paginacao);
        }

        public Candidato ObterCandidato(int idCandidato)
        {
            return CandidatoRepository
                .GetSingle(x => x.Id == idCandidato, x => x.ContaBancaria);
        }

        public void SalvarCandidato(Candidato novoCandidato)
        {
            CandidatoRepository.Add(novoCandidato);
            CandidatoRepository.Commit();
        }

        public void AtualizarCandidato(Candidato candidatoAtualizado)
        {
            CandidatoRepository.Update(candidatoAtualizado);
            CandidatoRepository.Commit();
        }

        public void DeletarCandidato(int idCandidato)
        {
            CandidatoRepository.DeleteWhere(candidato => candidato.Id == idCandidato);
            CandidatoRepository.Commit();
        }
    }
}