using System;
using AutoMapper;
using BackEnd.Controllers;
using BackEnd.Data;
using BackEnd.Model;
using BackEnd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using BackEnd.ViewModel;
using FluentAssert;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Xunit;

namespace BackEnd.Teste.Unidade
{
    public class CandidatoControllerTeste
    {
        private readonly CandidatoController controller;
        private readonly Mock<ICandidatoRepository> candidatoRepository;

        public CandidatoControllerTeste()
        {
            AutoMapperConfiguration.Configure();

            candidatoRepository = new Mock<ICandidatoRepository>();
            var candidatoService = new Mock<CandidatoService>(candidatoRepository.Object);

            controller = new CandidatoController(Mapper.Instance, candidatoService.Object);
        }

        [Theory]
        [InlineData("", 4)]
        [InlineData("{ Pagina : 1 }", 2)]
        public void deve_obter_todos_os_candidatos(string paginacao, int candidatosEsperados)
        {
            controller.ControllerContext = new ControllerContext(ObterActionContext(paginacao));

            var candidatosNoBanco = new List<Candidato>
            {
                new Candidato() {Id = 1},
                new Candidato() {Id = 2},
                new Candidato() {Id = 3},
                new Candidato() {Id = 4},
                new Candidato() {Id = 5},
                new Candidato() {Id = 6}
            };
            candidatoRepository.Setup(x => x.GetAll()).Returns(candidatosNoBanco);
            candidatoRepository.Setup(x => x.Count()).Returns(candidatosNoBanco.Count);

            var resultado = controller.Get() as OkObjectResult;
            var candidatosResumido = ((List<CandidatoResumidoViewModel>)resultado.Value);
            
            candidatosResumido.Count().ShouldBeEqualTo(candidatosEsperados);
        }

        private static ActionContext ObterActionContext(string paginacao)
        {
            var request = new Mock<HttpRequest>();
            var headerDictionary = new HeaderDictionary { { "Paginacao", paginacao } };
            request.Setup(x => x.Headers).Returns(headerDictionary);

            var context = new Mock<HttpContext>();
            context.SetupGet(x => x.Request).Returns(request.Object);

            var defaultHttpContext = new DefaultHttpContext();
            var defaultHttpResponse = new DefaultHttpResponse(defaultHttpContext);
            context.SetupGet(x => x.Response).Returns(defaultHttpResponse);

            var routeData = new RouteData();
            var controllerActionDescriptor = new ControllerActionDescriptor();

            return new ActionContext(context.Object, routeData, controllerActionDescriptor);
        }
    }
}
