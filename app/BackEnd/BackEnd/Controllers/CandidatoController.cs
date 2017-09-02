using Microsoft.AspNetCore.Mvc;
using BackEnd.Model;
using BackEnd.ViewModel;
using System.Collections.Generic;
using AutoMapper;
using BackEnd.Core;
using BackEnd.Service;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class CandidatoController : Controller
    {
        public IMapper Mapper { get; }
        public CandidatoService CandidatoService { get; }
        
        public CandidatoController(IMapper mapper, CandidatoService candidatoService)
        {
            Mapper = mapper;
            CandidatoService = candidatoService;
        }

        [HttpGet]
        public IActionResult Get(int pagina = 1)
        {
            var resultadoObterCandidatos = CandidatoService.ObterCandidatos(pagina);

            Response.AdicionarPaginacao(resultadoObterCandidatos.Item2);

            var candidatosResumidoViewModel = Mapper.Map<IEnumerable<Candidato>, IEnumerable<CandidatoResumidoViewModel>>(resultadoObterCandidatos.Item1);

            return new OkObjectResult(candidatosResumidoViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult ObterCandidato(int id)
        {
            var candidato = CandidatoService.ObterCandidato(id);

            var candidatosVM = Mapper.Map<Candidato, CandidatoViewModel>(candidato);

            return new OkObjectResult(candidatosVM);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CandidatoViewModel candidato)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novoCandidato = Mapper.Map<CandidatoViewModel, Candidato>(candidato);

            CandidatoService.SalvarCandidato(novoCandidato);

            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody]CandidatoViewModel candidato)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var candidatoAtualizado = Mapper.Map<CandidatoViewModel, Candidato>(candidato);

            CandidatoService.AtualizarCandidato(candidatoAtualizado);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CandidatoService.DeletarCandidato(id);
            
            return Ok();
        }
    }
}
