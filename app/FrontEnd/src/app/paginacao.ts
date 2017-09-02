import $ from 'jquery/dist/jquery';

export class Paginacao {
  Pagina: number = 0;
  TotalPaginas: number = 0;

  constructor(json: any) {
    if (json != '')
      $.extend(this, json);
  }
}