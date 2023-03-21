import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { Observable } from 'rxjs';
import { catchError, map } from "rxjs/operators";
import { Veiculo } from '../models/Veiculo';
import { Motorista } from '../models/Motorista';
import { Corrida } from '../models/Corrida';
import { BaseService } from 'src/app/base/baseService';

@Injectable()
export class CorridaService extends BaseService {
    constructor(private http: HttpClient) { super() }

    obterTodos(): Observable<Corrida[]> {
        return this.http
            .get<Corrida[]>(this.UrlServiceV1 + "corridas", super.ObterAuthHeaderJson())
            .pipe(
                catchError(this.serviceError));
    }

   

    registrarCorrida(corrida: Corrida): Observable<Corrida> {

        return this.http
            .post(this.UrlServiceV1 + 'corridas', corrida, super.ObterAuthHeaderJson())
            .pipe(
                map(super.extractData),
                catchError(super.serviceError)
            );
    }

    obterMotorista(): Observable<Motorista[]> {
        return this.http
            .get<Motorista[]>(this.UrlServiceV1 + 'motorista')
            .pipe(
                catchError(super.serviceError)
            );
    }

    obterVeiculo(): Observable<Veiculo[]> {
        return this.http
            .get<Veiculo[]>(this.UrlServiceV1 + 'veiculo')
            .pipe(
                catchError(super.serviceError)
            );
    }
}