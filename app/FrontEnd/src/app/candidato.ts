import { TipoDisponibilidade } from "app/TipoDisponibilidade";
import { TipoHorarioTrabalho } from "app/TipoHorarioTrabalho";

export class Candidato {
  id: number;
  nome: String = "";
  email: String = "";
  informacoesBanco: String = "";
  contaBancaria: ContaBancaria;

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

  conhecimentoEmIonic: number;
  conhecimentoEmAndroid : number;

  constructor() {
    this.contaBancaria = new ContaBancaria();
  }
}

export class ContaBancaria {
  id: number;
  CPF: String = "";
  nome: String = "";
  banco: String = "";
  agencia: String = "";
  Numero: Number = 0;


  corrente: boolean;
  poupanca: boolean;
}

export enum TipoNivelConhecimento {
  Nenhum = 0,
  MuitoBaixo = 1,
  Baixo = 2,
  Medio = 3,
  Bom = 4,
  Senior = 5,
}