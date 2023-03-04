import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, of, Subject, take } from 'rxjs';
import { IChamado } from 'src/app/model';
import { ChamadoService } from '../chamadoService';

@Component({
  selector: 'app-table-chamado',
  templateUrl: './table-chamado.component.html',
  styleUrls: ['./table-chamado.component.css']
})
export class TableChamadoComponent implements OnInit {
  
  chamados!: IChamado[];
  error$ = new Subject();

  constructor(private service: ChamadoService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.obterChamados();
  }

  private obterChamados() {
    this.service.buscarTodos().pipe(take(1), catchError(e => {
      this.error$.next(e);
      alert(e.error);
      return of()
    }))
      .subscribe(dados => this.chamados = dados);
  }

  editar(chamado: IChamado) {
    this.router.navigate(['editar', chamado.id], { relativeTo: this.route.parent })
    console.log(chamado);
  }

  excluir(chamado: IChamado, index: number) {
    let confirma = confirm(`Confirma excluír o chamado id: ${chamado.id} ?`)
    if (confirma) {
      this.service.excluir(chamado.id!)
        .pipe(take(1))
        .subscribe(() => this.chamados.splice(index, 1));
    }
  }

  detalhes(chamado: IChamado) {

    this.router.navigate(['detalhes', chamado.id], { relativeTo: this.route.parent })
  }
}
