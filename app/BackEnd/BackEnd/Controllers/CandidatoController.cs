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
using BackEnd.Service;
using Newtonsoft.Json;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class CandidatoController : Controller
    {
        public ICandidatoRepository CandidatoRepository { get; }
        public IMapper Mapper { get; }
        public CandidatoService CandidatoService { get; }
        
        public CandidatoController(ICandidatoRepository candidatoRepository, IMapper mapper, CandidatoService candidatoService)
        {
            CandidatoRepository = candidatoRepository;
            Mapper = mapper;
            CandidatoService = candidatoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var paginacao = Request.ObterPaginacao();

            var candidatos = CandidatoService.ObterCandidatos(paginacao);

            Response.AdicionarPaginacao(paginacao);

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
