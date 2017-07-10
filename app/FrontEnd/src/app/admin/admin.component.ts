import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Candidato } from '../candidato';
import { CandidatoService } from '../service/candidato.service';

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
}