import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, of, Subject, take } from 'rxjs';
import { IEquipamento } from 'src/app/model';
import { EquipamentoService } from '../equipamentosService';

@Component({
  selector: 'app-table-equipamentos',
  templateUrl: './table-equipamentos.component.html',
  styleUrls: ['./table-equipamentos.component.css']
})
export class TableEquipamentosComponent implements OnInit {

  equipamentos!: IEquipamento[];
  error$ = new Subject()

  constructor(private service: EquipamentoService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.obterEquipamentos();
  }

  obterEquipamentos() {
    this.service.buscarTodos().pipe(take(1), catchError(e => {
      this.error$.next(e);
      alert(e.error);
      return of()
    }))
      .subscribe(dados => this.equipamentos = dados);
  }

  editar(e: IEquipamento) {
    this.router.navigate(['editar', e.id], { relativeTo: this.route.parent })
    console.log(e);
  }
  
  excluir(e: IEquipamento, index: number) {
    let confirma = confirm(`Confirma excluir o equipamento id: ${e.id} ?`)
    if (confirma) {
      this.service.excluir(e.id!)
        .pipe(take(1))
        .subscribe(() => this.equipamentos.splice(index, 1));
    }
  }
}
