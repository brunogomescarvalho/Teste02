import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { IEquipamento } from 'src/app/model';
import { EquipamentoService } from '../equipamentosService';

@Injectable({ providedIn: 'root' })
export class EquipamentoResolve implements Resolve<IEquipamento> {

    constructor(private service: EquipamentoService) { }

    equipamento: IEquipamento = {} as IEquipamento;

    resolve(route: ActivatedRouteSnapshot): Observable<IEquipamento> {
        if (route.params && route.params['id']) {
            return this.service.buscarEquipPorId(route.params['id'])
        }
        return of(this.equipamento);
    }


}