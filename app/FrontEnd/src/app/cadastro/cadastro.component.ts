import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import 'rxjs/add/operator/switchMap';

import { Candidato } from '../candidato';
import { CandidatoService } from '../service/candidato.service';

@Component({
    selector: 'cadastro-root',
    templateUrl: './cadastro.component.html',
    styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

    constructor(private route: ActivatedRoute, private router: Router, private candidatoService: CandidatoService) { }
    candidato: Candidato;

    ngOnInit() {
        let id = this.route.snapshot.paramMap.get('id');

        if (id != null) {
            this.candidatoService.obter(Number(id))
                .then((candidato: Candidato) => {
                    this.candidato = candidato});
        }
    }

    botao(){
        debugger;
    }
}