export class Candidato {
  id: number;
  nome: String = "";
  email: String = "";
  informacoesBanco: String = "";
  contaBancaria: ContaBancaria;

  private _disponibilidade2: TipoDisponibilidade;
  ateQuatroHoras: boolean;
  ateSeisHoras: boolean;
  ateOitoHoras: boolean;
  maisDeOitoHoras: boolean;
  finaisDeSemana: boolean;

  get disponibilidade() {
    if (this.ateQuatroHoras)
      this._disponibilidade2 |= TipoDisponibilidade.AteQuatroHoras;

    if (this.ateSeisHoras)
      this._disponibilidade2 |= TipoDisponibilidade.AteSeisHoras;

    return this._disponibilidade2;
  }

  set disponibilidade(disponibilidade) {
    if (disponibilidade & TipoDisponibilidade.AteQuatroHoras) {
      this.ateQuatroHoras = true;
    }
    if (disponibilidade & TipoDisponibilidade.AteSeisHoras) {
      this.ateSeisHoras = true;
    }
  }

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

}