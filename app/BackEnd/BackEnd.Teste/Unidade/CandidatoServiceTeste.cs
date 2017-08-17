using System;
using System.Linq;
using BackEnd.Data;
using BackEnd.Model;
using BackEnd.Service;
using FluentAssert;
using Moq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace BackEnd.Teste
{
    public class CandidatoServiceTeste
    {
        private readonly Mock<ICandidatoRepository> candidatoRepositorio;

        public CandidatoServiceTeste()
        {
            candidatoRepositorio = new Mock<ICandidatoRepository>();
        }

        [Fact]
        public void deve_obter_candidatos()
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
            candidatoRepositorio.Setup(x => x.Count()).Returns(candidatosNoBanco.Count);

            var candidatoService = new CandidatoService(candidatoRepositorio.Object);

            Paginacao paginacao = new Paginacao();

            var candidatos = candidatoService.ObterCandidatos(ref paginacao);

            candidatos.Count().ShouldBeEqualTo(4);
        }

        [Fact]
        public void deve_obter_candidatos_a_partir_da_paginacao()
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
            candidatoRepositorio.Setup(x => x.Count()).Returns(candidatosNoBanco.Count);

            var candidatoService = new CandidatoService(candidatoRepositorio.Object);

            var paginacao = new Paginacao(1);

            var candidatos = candidatoService.ObterCandidatos(ref paginacao);

            candidatos.Count().ShouldBeEqualTo(2);
        }

        [Fact]
        public void deve_obter_candidato_filtrando_por_id()
        {
            var candidatoNoBanco = new Candidato() { Id = 3, Nome = "Glaicon" };

            candidatoRepositorio.Setup(x => x.GetSingle(It.IsAny<Expression<Func<Candidato, bool>>>(), It.IsAny<Expression<Func<Candidato, object>>[]>())).Returns(candidatoNoBanco);

            var candidatoService = new CandidatoService(candidatoRepositorio.Object);

            var idCandidato = 3;
            var candidato = candidatoService.ObterCandidato(idCandidato);

            candidato.Nome.ShouldBeEqualTo("Glaicon");
            candidato.Id.ShouldBeEqualTo(idCandidato);
        }

        [Fact]
        public void deve_salvar_candidato()
        {
            var candidatoService = new CandidatoService(candidatoRepositorio.Object);
            Candidato candidato = new Candidato();

            candidatoService.SalvarCandidato(candidato);

            candidatoRepositorio.Verify(x => x.Add(It.IsAny<Candidato>()), Times.Once);
            candidatoRepositorio.Verify(x => x.Commit(), Times.Once);
        }

        [Fact]
        public void deve_atualizar_candidato()
        {
            var candidatoService = new CandidatoService(candidatoRepositorio.Object);
            Candidato candidato = new Candidato();

            candidatoService.AtualizarCandidato(candidato);

            candidatoRepositorio.Verify(x => x.Update(It.IsAny<Candidato>()), Times.Once);
            candidatoRepositorio.Verify(x => x.Commit(), Times.Once);
        }

        [Fact]
        public void deve_deletar_candidato()
        {
            var candidatoService = new CandidatoService(candidatoRepositorio.Object);
            Candidato candidato = new Candidato();

            candidatoService.DeletarCandidato(candidato.Id);

            candidatoRepositorio.Verify(x => x.DeleteWhere(It.IsAny<Expression<Func<Candidato, bool>>>()), Times.Once);
            candidatoRepositorio.Verify(x => x.Commit(), Times.Once);
        }
    }
}