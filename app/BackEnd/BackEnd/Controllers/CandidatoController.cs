using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Model;
using BackEnd.ViewModel;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System;
using BackEnd.Core;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class CandidatoController : Controller
    {
        public ICandidatoRepository CandidatoRepository { get; }
        public IMapper Mapper { get; }
        int page = 1;
        int pageSize = 4;

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
                var vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            var currentPage = page;
            var currentPageSize = pageSize;
            var totalSchedules = CandidatoRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalSchedules / pageSize);

            IEnumerable<Candidato> candidatos = CandidatoRepository
                .GetAll()
                .OrderBy(s => s.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            Response.AddPagination(page, pageSize, totalSchedules, totalPages);

            var candidatosVM = Mapper.Map<IEnumerable<Candidato>, IEnumerable<CandidatoViewModel>>(candidatos);

            return new OkObjectResult(candidatosVM);
        }

        [HttpGet("{id}")]
        public IActionResult ObterCandidato(int id)
        {
            var candidato = CandidatoRepository
                .GetSingle(id);
            
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
    }
}
