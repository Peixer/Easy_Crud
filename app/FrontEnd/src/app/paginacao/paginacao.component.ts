import { Component, Input, EventEmitter, Output } from '@angular/core';

@Component({
    selector: 'paginacao',
    templateUrl: './paginacao.component.html',
    styleUrls: ['./paginacao.component.css']
})
export class PaginacaoComponent {
    @Input() pagina: number;
    @Input() totalPaginas: number;

    @Output() voltar = new EventEmitter<boolean>();
    @Output() avancar = new EventEmitter<boolean>();
    @Output() navegar = new EventEmitter<number>();

    constructor() { }

    onNavegar(n: number): void {
        this.navegar.emit(n);
    }

    onVoltar(): void {
        if (this.pagina != 1)
            this.voltar.emit(true);
    }

    onAvancar(next: boolean): void {
        if (!this.ehUltimaPagina())
            this.avancar.emit(next);
    }

    ehUltimaPagina(): boolean {
        return this.pagina === this.totalPaginas;
    }

    obterPaginacao(): number[] {
        const qntdPaginas = 10;
        const paginacao: number[] = [];

        paginacao.push(this.pagina);
        const times = qntdPaginas - 1;
        for (let i = 0; i < times; i++) {
            if (paginacao.length < qntdPaginas) {
                if (Math.min.apply(null, paginacao) > 1) {
                    paginacao.push(Math.min.apply(null, paginacao) - 1);
                }
            }
            if (paginacao.length < qntdPaginas) {
                if (Math.max.apply(null, paginacao) < this.totalPaginas) {
                    paginacao.push(Math.max.apply(null, paginacao) + 1);
                }
            }
        }

        paginacao.sort((a, b) => a - b);
        return paginacao;
    }
}