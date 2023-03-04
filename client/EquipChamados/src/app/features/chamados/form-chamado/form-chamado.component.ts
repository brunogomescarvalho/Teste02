import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, Observable, of, Subject, take } from 'rxjs';
import { IChamado, IEquipamento } from 'src/app/model';
import { EquipamentoService } from '../../equipamentos/equipamentosService';
import { ChamadoService } from '../chamadoService';

@Component({
  selector: 'app-form-chamado',
  templateUrl: './form-chamado.component.html',
  styleUrls: ['./form-chamado.component.css']
})
export class FormChamadoComponent implements OnInit {

  equipamentos!: IEquipamento[];
  form!: FormGroup;
  editarCadastro: boolean = false;

  observable = new Observable<boolean>();
  error$ = new Subject();

  constructor(
    private route: ActivatedRoute,
    private service: ChamadoService,
    private equipamentoService: EquipamentoService,
    private datePipe: DatePipe,
    private router: Router
  ) { }

  ngOnInit(): void {

    const chamado = this.route.snapshot.data['chamado'];
    chamado.dataAbertura = this.datePipe.transform(chamado.dataAbertura, 'yyyy-MM-dd');

    if (chamado.id) {
      this.editarCadastro = true
    }

    this.obtemEquipamentos();
    this.formulario(chamado);
  }


  obtemEquipamentos() {
    this.equipamentoService.buscarTodos()
      .pipe(take(1))
      .subscribe(lista => this.equipamentos = lista);
  }

  formulario(chamado: IChamado) {
    this.form = new FormGroup({
      id: new FormControl(chamado.id),
      titulo: new FormControl(chamado.titulo, [Validators.required]),
      descricao: new FormControl(chamado.descricao, [Validators.minLength(6), Validators.required]),
      dataAbertura: new FormControl(chamado.dataAbertura, [Validators.required]),
      equipamento: new FormControl(chamado.equipamento, [Validators.required])

    })
  }

  onSubmit() {
    if (this.form.valid) {

      const chamado: IChamado = {
        id: this.form.value.id == null ? 0 : this.form.value.id,
        titulo: this.form.value.titulo,
        descricao: this.form.value.descricao,
        dataAbertura: this.form.value.dataAbertura,
        equipamento: this.form.value.equipamento
      }
      console.log(chamado);

      if (chamado.id) {
        this.observable = this.service.editar(chamado);
        this.enviar()

      }
      else {
        this.observable = this.service.cadastrar(chamado);
        this.enviar()
      }
    }
  }

  enviar() {
    this.observable
      .pipe(take(1), catchError(e => {
        this.error$.next(e);
        alert(e.error);
        return of()
      })).subscribe(() => {
        this.form.reset();
        alert("Cadastro efetuado com sucesso")
      })
    
  }

  voltar(editarCadastro: boolean) {
    var rota = editarCadastro == true ? 'gerenciar' : '../home';
    this.router.navigate([rota], { relativeTo: this.route.parent });
  }
}

