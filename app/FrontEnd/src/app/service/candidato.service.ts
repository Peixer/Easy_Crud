import { Injectable } from '@angular/core';
import 'rxjs/add/operator/toPromise';

import { Http } from '@angular/http'
import { environment } from 'environments/environment';
import { Candidato } from '../candidato';

@Injectable()
export class CandidatoService {

    constructor(private httpService: Http) { }

    obter(id: number): Promise<Candidato> {
        return this.httpService.get(environment.baseUrl + '/api/candidato/' + id).toPromise().then(response => response.json());
    }

    todos(): Promise<Candidato[]> {
        return this.httpService.get(environment.baseUrl + '/api/candidato').toPromise().then(response => response.json());
    }
}