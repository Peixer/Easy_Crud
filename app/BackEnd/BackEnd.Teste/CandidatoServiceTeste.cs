using System.Linq;
using BackEnd.Data;
using BackEnd.Model;
using BackEnd.Service;
using FluentAssert;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BackEnd.Teste
{
    public class CandidatoServiceTeste
    {
        private Mock<ICandidatoRepository> candidatoRepositorio;

        [SetUp]
        public void SetUp()
        {
            candidatoRepositorio = new Mock<ICandidatoRepository>();
        }

        [Test]
        public void ObtendoCandidatosConformePaginacao()
        {
            var candidatosNoBanco = new List<Candidato>
            {
                new Candidato() {Id = 1},
                new Candidato() {Id = 2},
                new Candidato() {Id = 3},
                new Candidato() {Id = 4},
                new Candidato() {Id = 5},
                new Candidato() {Id = 6}
            };
            candidatoRepositorio.Setup(x => x.GetAll()).Returns(candidatosNoBanco);

            var candidatoService = new CandidatoService(candidatoRepositorio.Object);

            var candidatos = candidatoService.ObterCandidatos(null);

            candidatos.Count().ShouldBeEqualTo(4);
        }
    }
}