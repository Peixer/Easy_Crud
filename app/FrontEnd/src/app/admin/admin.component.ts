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
    this.candidatoService.todos().then(values => {
      this.candidatos = values;
    });
  }

  abrirCandidato(id: number) {
    this.router.navigate(['/cadastro/' + id]);
  }

  addCandidato() {
    this.router.navigate(['/cadastro']);
  }
}