using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Model;
using BackEnd.ViewModel;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System;
using System.Threading;
using BackEnd.Core;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class CandidatoController : Controller
    {
        public ICandidatoRepository CandidatoRepository { get; }
        public IMapper Mapper { get; }
        int pagina = 1;
        int tamanhoPagina = 4;

        public CandidatoController(ICandidatoRepository candidatoRepository, IMapper mapper)
        {
            CandidatoRepository = candidatoRepository;
            Mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                var informacoesPaginacao = pagination.ToString().Split(',');
                int.TryParse(informacoesPaginacao[0], out pagina);
                int.TryParse(informacoesPaginacao[1], out tamanhoPagina);
            }

            var paginaAtual = pagina;
            var tamanhoPaginaAtual = tamanhoPagina;
            var totalCandidatos = CandidatoRepository.Count();
            var totalPaginas = (int)Math.Ceiling((double)totalCandidatos / tamanhoPagina);

            IEnumerable<Candidato> candidatos = CandidatoRepository
                .GetAll()
                .OrderBy(s => s.Id)
                .Skip((paginaAtual - 1) * tamanhoPaginaAtual)
                .Take(tamanhoPaginaAtual)
                .ToList();

            Response.AddPagination(pagina, tamanhoPagina, totalCandidatos, totalPaginas);

            var candidatosResumidoViewModel = Mapper.Map<IEnumerable<Candidato>, IEnumerable<CandidatoResumidoViewModel>>(candidatos);

            return new OkObjectResult(candidatosResumidoViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult ObterCandidato(int id)
        {
            var candidato = CandidatoRepository
                .GetSingle(x => x.Id == id, x => x.ContaBancaria);

            var candidatosVM = Mapper.Map<Candidato, CandidatoViewModel>(candidato);

            return new OkObjectResult(candidatosVM);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CandidatoViewModel candidato)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novoCandidato = Mapper.Map<CandidatoViewModel, Candidato>(candidato);

            CandidatoRepository.Add(novoCandidato);
            CandidatoRepository.Commit();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody]CandidatoViewModel candidato)
        {
            Thread.Sleep(5000);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var candidatoAtualizado = Mapper.Map<CandidatoViewModel, Candidato>(candidato);

            CandidatoRepository.Update(candidatoAtualizado);
            CandidatoRepository.Commit();

            return Ok();
        }
    }
}
