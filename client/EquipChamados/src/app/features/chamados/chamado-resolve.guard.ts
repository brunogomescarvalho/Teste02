import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Observable, of } from "rxjs";
import { IChamado } from "src/app/model";
import { ChamadoService } from "./chamadoService";
@Injectable()
export class ChamadoResolve implements Resolve<IChamado>{
    constructor(private service: ChamadoService) { }

    chamado: IChamado = {} as IChamado;

    resolve(route: ActivatedRouteSnapshot): Observable<IChamado> {
        if (route.params && route.params['id']) {
            return this.service.buscarPorId(route.params['id']) 
        }
        return of(this.chamado);
    }


}