import { TipoDisponibilidade } from "app/TipoDisponibilidade";
import { TipoHorarioTrabalho } from "app/TipoHorarioTrabalho";
import $ from 'jquery/dist/jquery';

export class Candidato {
  id: number;
  contaBancaria: ContaBancaria = new ContaBancaria();

  ateQuatroHoras: boolean = false;
  ateSeisHoras: boolean = false;
  ateOitoHoras: boolean = false;
  maisDeOitoHoras: boolean = false;
  finaisDeSemana: boolean = false;

  manha: boolean = false;
  tarde: boolean = false;
  noite: boolean = false;
  madrugada: boolean = false;
  comercial: boolean = false;

  constructor(json: any) {
    if (json != '')
      $.extend(this, json);

    if (this.contaBancaria == null)
      this.contaBancaria = new ContaBancaria();
  }
}

export class ContaBancaria {
  id: number;
  cpf: string = "";
  nome: string = "";
  banco: string = "";
  agencia: string = "";
  numero: Number = 0;

  corrente: boolean = false;;
  poupanca: boolean = false;;
}

export enum TipoNivelConhecimento {
  Nenhum = 0,
  MuitoBaixo = 1,
  Baixo = 2,
  Medio = 3,
  Bom = 4,
  Senior = 5,
}