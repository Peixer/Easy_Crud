import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { CandidatoService } from '../service/candidato.service';
import { Candidato } from '../candidato';

@Component({
  selector: 'admin-root',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private candidatoService: CandidatoService, private router: Router) { }
  candidatos: Candidato[] = [];

  ngOnInit() {
    this.obterCandidatos();
  }

  abrirCandidato(id: number) {
    this.router.navigate(['/cadastro/' + id]);
  }

  deletarCandidato(id: number) {
    debugger;
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
      this.candidatos = values;
    });
  }
}