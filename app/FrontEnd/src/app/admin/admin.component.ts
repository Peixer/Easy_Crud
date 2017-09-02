import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { CandidatoService } from '../service/candidato.service';
import { Candidato } from '../candidato';
import { Paginacao } from '../paginacao';

@Component({
  selector: 'admin-root',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private candidatoService: CandidatoService, private router: Router) { }
  candidatos: Candidato[] = [];
  paginacao: Paginacao = new Paginacao('');

  ngOnInit() {
    this.obterCandidatos();
  }

  abrirCandidato(id: number) {
    this.router.navigate(['/cadastro/' + id]);
  }

  deletarCandidato(id: number) {
    this.candidatoService.deletar(id).then((mensagem) => {
      alert('Candidato Deletado!');
      this.obterCandidatos();
    }, (mensagem) => {
      alert('Erro ao deletar candidato - ' + mensagem);
    });
  }

  addCandidato() {
    this.router.navigate(['/cadastro']);
  }

  obterCandidatos() {
    this.candidatoService.todos().then(values => {
      this.atualizarInformacoesPagina(values);
    });
  }

  moverParaPagina(pagina: number): void {
    this.candidatoService.pagina(pagina).then(values => {
      this.atualizarInformacoesPagina(values);
    });
  }

  atualizarInformacoesPagina(values) {
    let jsonPaginacao = JSON.parse(values.headers.get('paginacao'));
    this.paginacao = new Paginacao(jsonPaginacao);
    this.candidatos = values.json() as Candidato[];
  }

  avancarParaPagina(): void {
    this.moverParaPagina(++this.paginacao.Pagina);
  }

  voltarParaPagina(): void {
    this.moverParaPagina(--this.paginacao.Pagina)
  }
}