using System;
using System.Linq;
using BackEnd.Data;
using BackEnd.Model;
using BackEnd.Service;
using FluentAssert;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq.Expressions;

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

            Paginacao paginacao = null;

            var candidatos = candidatoService.ObterCandidatos(paginacao);

            candidatos.Count().ShouldBeEqualTo(4);
            
            candidatos = candidatoService.ObterCandidatos(paginacao);
            
            candidatos.Count().ShouldBeEqualTo(2);
        }

        [Test]
        public void ObtendoCandidatoEspecifico()
        {
            var candidatoNoBanco = new Candidato() { Id = 3, Nome = "Glaicon" };

            candidatoRepositorio.Setup(x => x.GetSingle(It.IsAny<Expression<Func<Candidato, bool>>>(), It.IsAny<Expression<Func<Candidato, object>>[]>())).Returns(candidatoNoBanco);

            var candidatoService = new CandidatoService(candidatoRepositorio.Object);

            var idCandidato = 3;
            var candidato = candidatoService.ObterCandidato(idCandidato);

            candidato.Nome.ShouldBeEqualTo("Glaicon");
            candidato.Id.ShouldBeEqualTo(idCandidato);
        }
    }
}