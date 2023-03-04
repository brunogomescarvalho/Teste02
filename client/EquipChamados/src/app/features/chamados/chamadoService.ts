import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, take } from "rxjs";
import { IChamado } from "src/app/model";

@Injectable()


export class ChamadoService {


    constructor(private httpClient: HttpClient) { }

    private api: string = 'http://localhost:5290/api';

    public cadastrar(chamado: IChamado): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}/chamado`, chamado);
    }

    public buscarPorId(id: number): Observable<IChamado> {
        return this.httpClient.get<IChamado>(`${this.api}/chamado/id/${id}`).pipe(take(1));
    }

    public buscarTodos(): Observable<IChamado[]> {
        return this.httpClient.get<IChamado[]>(`${this.api}/chamado`);
    }

    public editar(chamado: IChamado): Observable<boolean> {
        return this.httpClient.put<boolean>(`${this.api}/chamado`, chamado);
    }

    public excluir(id: number): Observable<boolean> {
        return this.httpClient.delete<boolean>(`${this.api}/chamado/${id}`);
    }
}