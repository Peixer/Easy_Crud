using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BackEnd.Data;
using BackEnd.Model;
using BackEnd.Service;
using FluentAssert;
using Moq;
using Xunit;

namespace BackEnd.Teste.Unidade
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
            var candidatos = candidatoService.ObterCandidatos(1);

            candidatos.Item1.Count().ShouldBeEqualTo(6);
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

            var segundaPagina = 2;
            var candidatos = candidatoService.ObterCandidatos(segundaPagina);

            candidatos.Item1.Count().ShouldBeEqualTo(0);
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
            var candidato = new Candidato();

            candidatoService.DeletarCandidato(candidato.Id);

            candidatoRepositorio.Verify(x => x.DeleteWhere(It.IsAny<Expression<Func<Candidato, bool>>>()), Times.Once);
            candidatoRepositorio.Verify(x => x.Commit(), Times.Once);
        }
    }
}