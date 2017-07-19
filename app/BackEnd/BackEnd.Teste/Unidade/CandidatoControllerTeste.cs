using AutoMapper;
using BackEnd.Controllers;
using BackEnd.Data;
using BackEnd.Model;
using BackEnd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace BackEnd.Teste.Unidade
{
    public class CandidatoControllerTeste
    {
        [Fact]
        public void deve_obter_todos_os_candidatos()
        {
            Mock<IMapper> mapper = new Mock<IMapper>();
            Mock<ICandidatoRepository> candidatoRepository = new Mock<ICandidatoRepository>();
            Mock<CandidatoService> candidatoService = new Mock<CandidatoService>(candidatoRepository.Object);

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

            var request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary() { { "Paginacao",""} });
            //StringBuilder sb = new StringBuilder();
            //StringWriter sw = new StringWriter(sb);
            //HttpResponse response = new HttpResponse(sw);
            var context = new Mock<HttpContext>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            //context.SetupGet(x => x.Response).Returns(new HttpResponse());
            ActionContext actionContext = new ActionContext(context.Object, new Microsoft.AspNetCore.Routing.RouteData(), new Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor());

            CandidatoController controller = new CandidatoController(mapper.Object, candidatoService.Object);
            controller.ControllerContext = new ControllerContext(actionContext);

            var resultado = controller.Get();




        }
    }
}
