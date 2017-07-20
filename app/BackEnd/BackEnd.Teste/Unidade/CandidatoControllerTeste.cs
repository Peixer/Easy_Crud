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
        public void deve_obter_todos_os_candidatos(string paginacao, int quantidadeCandidatosEsperados)
        {
            controller.ControllerContext = new ControllerContext(ObterActionContext(paginacao));

            var candidatosNoBanco = ObterCandidatos();
            candidatoRepository.Setup(x => x.GetAll()).Returns(candidatosNoBanco);
            candidatoRepository.Setup(x => x.Count()).Returns(candidatosNoBanco.Count);

            var resultado = controller.Get() as OkObjectResult;
            var candidatosResumido = ((List<CandidatoResumidoViewModel>)resultado.Value);

            candidatosResumido.Count().ShouldBeEqualTo(quantidadeCandidatosEsperados);
        }

        [Theory]
        [InlineData(4, "Leticia")]
        [InlineData(1, "Glaicon")]
        [InlineData(3, "Carla")]
        [InlineData(6, "Carol")]
        public void deve_obter_candidato(int idCandidato, string nomeCandidatoEsperado)
        {
            var actionContext = ObterActionContext("");
            controller.ControllerContext = new ControllerContext(actionContext);

            var candidatosNoBanco = ObterCandidatos();
            //candidatoRepository.Setup(x => x.GetSingle(It.IsAny<Expression<Func<T, bool>>>, It.IsAny<Expression<Func<T, object>>>)).Returns(candidatosNoBanco);
            candidatoRepository.Setup(x => x.Count()).Returns(candidatosNoBanco.Count);

            var resultadoObterCandidato = controller.ObterCandidato(idCandidato) as OkObjectResult;
            var candidato = ((CandidatoViewModel)resultadoObterCandidato.Value);

            candidato.Nome.ShouldBeEqualTo(nomeCandidatoEsperado);
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

        private List<Candidato> ObterCandidatos()
        {
            return new List<Candidato>
            {
                new Candidato() {Id = 1, Nome="Glaicon"},
                new Candidato() {Id = 5, Nome="Maria"},
                new Candidato() {Id = 2, Nome="Janaina"},
                new Candidato() {Id = 4, Nome="Leticia"},
                new Candidato() {Id = 3, Nome="Carla"},
                new Candidato() {Id = 6, Nome="Carol"}
            };
        }
    }
}
