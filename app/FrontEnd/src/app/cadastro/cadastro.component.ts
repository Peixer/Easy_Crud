import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import 'rxjs/add/operator/switchMap';

import { CandidatoService } from '../service/candidato.service';
import { Candidato, TipoNivelConhecimento } from '../candidato';
import $ from 'jquery/dist/jquery';
import "jquery-validation";

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
                    this.candidato = new Candidato(candidato);
                }, (mensagem) => {
                    alert('Erro ao atualizar candidato - ' + mensagem);
                });
        } else
            this.candidato = new Candidato('');

        this.adicionarMetodoJqueryValidate();
    }

    adicionarMetodoJqueryValidate() {
        $.validator.addMethod("require_from_group", function (value, element, options) {
            var $fields = $(options[1], element.form),
                $fieldsFirst = $fields.eq(0),
                validator = $fieldsFirst.data("valid_req_grp") ? $fieldsFirst.data("valid_req_grp") : $.extend({}, this),
                isValid = $fields.filter(function () {
                    return validator.elementValue(this);
                }).length >= options[0];

            // Store the cloned validator for future validation
            $fieldsFirst.data("valid_req_grp", validator);

            // If element isn't being validated, run each require_from_group field's validation rules
            if (!$(element).data("being_validated")) {
                $fields.data("being_validated", true);
                $fields.each(function () {
                    validator.element(this);
                });
                $fields.data("being_validated", false);
            }
            return isValid;
        }, $.validator.format("Selecione ao menos {0} dos campos."));
    }

    enviar() {
        if (!this.formularioEstaValido())
            return;

        if (this.route.snapshot.paramMap.has('id')) {
            this.candidatoService.atualizar(this.candidato).then((mensagem) => {
                alert('Candidato Atualizado!');
                this.router.navigate(['/admin']);
            }, (mensagem) => {
                alert('Erro ao atualizar candidato - ' + mensagem);
            });
        } else {
            this.candidatoService.salvar(this.candidato).then((mensagem) => {
                alert('Candidato cadastrado!');
                this.router.navigate(['/admin']);
            }, (mensagem) => {
                alert('Erro ao cadastrar candidato' + mensagem);
            });
        }
    }

    proxima() {
        if (!this.formularioEstaValido())
            return;

        this.navegarEntreAsPartesDoFormulario(false);
    }

    voltar() {
        this.navegarEntreAsPartesDoFormulario(true);
    }

    navegarEntreAsPartesDoFormulario(estaVoltando: boolean) {
        this.mostrarParteFormulario(estaVoltando);
        this.habilitarBotaoEnviar(this.contadorParteFormulario == this.PARTE_FINAL);
        this.habilitarBotaoAnterior(this.contadorParteFormulario != this.PARTE_INICIAL);

        $('#formulario_' + this.contadorParteFormulario + " :input:first").focus();
        $('#form-id :input:enabled:visible:first').focus();
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

        $('#formulario_' + this.contadorParteFormulario).addClass('hide');

        if (estaVoltando)
            this.contadorParteFormulario--;
        else
            this.contadorParteFormulario++;

        $('#formulario_' + this.contadorParteFormulario).removeClass('hide').fadeIn(500);
    }

    formularioEstaValido() {
        return $('#formulario_' + this.contadorParteFormulario).validate({
            rules: {
                email: {
                    required: true,
                    email: true
                },
                nome: {
                    required: true
                },
                skype: {
                    required: true
                },
                telefone: {
                    required: true
                },
                cidade: {
                    required: true
                },
                estado: {
                    required: true
                },
                pretensaoSalarial: {
                    required: true
                },
                groupIonic: {
                    required: true
                },
                groupAndroid: {
                    required: true
                },
                groupIOS: {
                    required: true
                },
                groupBootstrap: {
                    required: true
                },
                groupjquery: {
                    required: true
                },
                groupangularJS: {
                    required: true
                },
                groupaspNet: {
                    required: true
                },
                linkCrud: {
                    required: true
                },
                ateQuatroHoras: {
                    require_from_group: [1, ".disponibilidade-group"]
                },
                ateSeisHoras: {
                    require_from_group: [1, ".disponibilidade-group"]
                },
                ateOitoHoras: {
                    require_from_group: [1, ".disponibilidade-group"]
                },
                maisDeOitoHoras: {
                    require_from_group: [1, ".disponibilidade-group"]
                },
                finaisDeSemana: {
                    require_from_group: [1, ".disponibilidade-group"]
                },
                manha: {
                    require_from_group: [1, ".horario-group"]

                },
                tarde: {
                    require_from_group: [1, ".horario-group"]

                },
                noite: {
                    require_from_group: [1, ".horario-group"]

                },
                madrugada: {
                    require_from_group: [1, ".horario-group"]

                },
                comercial: {
                    require_from_group: [1, ".horario-group"]

                },
                poupanca: {
                    require_from_group: [1, ".contaBancaria-group"]

                },
                corrente: {
                    require_from_group: [1, ".contaBancaria-group"]

                }
            },
            messages: {
                email: {
                    required: "Campo obrigatório",
                    email: "Insira um endereço de e-mail válido"
                },
                nome: {
                    required: "Campo obrigatório"
                },
                skype: {
                    required: "Campo obrigatório"
                },
                telefone: {
                    required: "Campo obrigatório"
                },
                cidade: {
                    required: "Campo obrigatório"
                },
                estado: {
                    required: "Campo obrigatório"
                },
                pretensaoSalarial: {
                    required: "Campo obrigatório"
                },
                groupIonic: {
                    required: "Campo obrigatório"
                },
                groupAndroid: {
                    required: "Campo obrigatório"
                },
                groupIOS: {
                    required: "Campo obrigatório"
                },
                groupBootstrap: {
                    required: "Campo obrigatório"
                },
                groupjquery: {
                    required: "Campo obrigatório"
                },
                groupangularJS: {
                    required: "Campo obrigatório"
                },
                groupaspNet: {
                    required: "Campo obrigatório"
                },
                linkCrud: {
                    required: "Campo obrigatório"
                },
            },
            errorElement: 'div',
            errorPlacement: function (error, element) {
                var placement = $(element).data('error');

                error[0].style.color = 'red';

                if (element[0].type == 'checkbox') {
                    $(element[0].labels[0]).append(error);
                }
                else if (placement) {
                    $(placement).append(error)
                } else {
                    error.insertAfter(element);
                }
            }
        }).form();
    }
}