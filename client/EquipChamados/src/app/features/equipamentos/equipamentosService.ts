import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, take } from "rxjs";
import { IEquipamento } from "src/app/model";

@Injectable()

export class EquipamentoService {
    constructor(private httpClient: HttpClient) { }

    private api: string = 'http://localhost:5290/api';

    public cadastrar(equipamento: IEquipamento): Observable<boolean> {
        return this.httpClient.post<boolean>(`${this.api}/equipamento`, equipamento);
    }

    public buscarEquipPorId(id: number): Observable<IEquipamento> {
        return this.httpClient.get<IEquipamento>(`${this.api}/equipamento/id/${id}`).pipe(take(1));
    }

    public buscarTodos(): Observable<IEquipamento[]> {
        return this.httpClient.get<IEquipamento[]>(`${this.api}/equipamento`);
    }

    public editar(equipamento: IEquipamento): Observable<boolean> {
        return this.httpClient.put<boolean>(`${this.api}/equipamento`, equipamento);
    }

    public excluir(id: number): Observable<boolean> {
        return this.httpClient.delete<boolean>(`${this.api}/equipamento/${id}`);
    }


}