import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import 'rxjs/add/operator/switchMap';

import { CandidatoService } from '../service/candidato.service';
import { Candidato } from '../candidato';

@Component({
    selector: 'cadastro-root',
    templateUrl: './cadastro.component.html',
    styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
    PARTE_FINAL: number = 4;
    PARTE_INICIAL: number = 1;
    constructor(private route: ActivatedRoute, private router: Router, private candidatoService: CandidatoService) { }
    candidato: Candidato;
    contadorParteFormulario: number = this.PARTE_INICIAL;

    ngOnInit() {
        let id = this.route.snapshot.paramMap.get('id');

        if (id != null) {
            this.candidatoService.obter(Number(id))
                .then((candidato) => {
                    this.candidato = candidato
                });
        } else
            this.candidato = new Candidato();
    }

    proxima() {
        this.navegarEntreAsPartesDoFormulario(false);
    }

    voltar() {
        this.navegarEntreAsPartesDoFormulario(true);
    }

    navegarEntreAsPartesDoFormulario(estaVoltando: boolean) {
        if (!this.podeNavegar(estaVoltando))
            return;

        this.mostrarParteFormulario(estaVoltando);
        this.habilitarBotaoEnviar(this.contadorParteFormulario == this.PARTE_FINAL);
        this.habilitarBotaoAnterior(this.contadorParteFormulario != this.PARTE_INICIAL);
    }

    habilitarBotaoAnterior(deveHabilitar: boolean) {
        let botaoAnteriorElement = document.getElementById('botaoAnterior');

        if (deveHabilitar && botaoAnteriorElement.classList.contains('disabled'))
            botaoAnteriorElement.classList.remove('disabled');
        else if (!deveHabilitar && !botaoAnteriorElement.classList.contains('disabled'))
            botaoAnteriorElement.classList.add('disabled');
    }

    habilitarBotaoEnviar(deveHabilitar: boolean) {
        let botaoEnviarElement = document.getElementById('botaoEnviar');
        let botaoProximoElement = document.getElementById('botaoProximo');

        if (deveHabilitar && botaoEnviarElement.classList.contains('hide')) {
            botaoEnviarElement.classList.remove('hide');
            botaoProximoElement.classList.add('hide');
        }
        else if (!deveHabilitar && !botaoEnviarElement.classList.contains('hide')) {
            botaoEnviarElement.classList.add('hide');
            botaoProximoElement.classList.remove('hide');
        }
    }

    mostrarParteFormulario(estaVoltando: boolean) {
        let idParteFormularioParaEsconder = "formulario_" + this.contadorParteFormulario;
        let element = document.getElementById(idParteFormularioParaEsconder);

        element.classList.add('hide');

        if (estaVoltando)
            this.contadorParteFormulario--;
        else
            this.contadorParteFormulario++;

        idParteFormularioParaEsconder = "formulario_" + this.contadorParteFormulario;
        element = document.getElementById(idParteFormularioParaEsconder);
        element.classList.remove('hide');
    }

    podeNavegar(estaVoltando: boolean): Boolean {
        if (estaVoltando && this.contadorParteFormulario == this.PARTE_INICIAL)
            return false;
        if (!estaVoltando && this.contadorParteFormulario == this.PARTE_FINAL)
            return false;
        return true;
    }
}