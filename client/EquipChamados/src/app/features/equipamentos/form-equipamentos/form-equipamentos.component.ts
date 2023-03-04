import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, Observable, of, Subject, take } from 'rxjs';
import { IEquipamento } from 'src/app/model';
import { EquipamentoService } from '../equipamentosService';

@Component({
  selector: 'app-form-equipamentos',
  templateUrl: './form-equipamentos.component.html',
  styleUrls: ['./form-equipamentos.component.css']
})
export class FormEquipamentosComponent implements OnInit {

  form!: FormGroup;
  editarCadastro: boolean = false;
  observable = new Observable<boolean>();
  error$ = new Subject();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private datePipe: DatePipe,
    private service: EquipamentoService) { }

  ngOnInit(): void {
    const equipamento = this.route.snapshot.data['equipamento'];
    equipamento.dataFabricacao = this.datePipe.transform(equipamento.dataFabricacao, 'yyyy-MM-dd');

    if (equipamento.id) {
      this.editarCadastro = true
    }

    this.formulario(equipamento);
  }

  formulario(equipamento: IEquipamento) {
    this.form = new FormGroup({
      id: new FormControl(equipamento.id),
      nome: new FormControl(equipamento.nome, [Validators.minLength(6), Validators.required]),
      preco: new FormControl(equipamento.preco, [Validators.required, Validators.min(0)]),
      nrSerie: new FormControl(equipamento.nrSerie, [Validators.required]),
      dataFabricacao: new FormControl(equipamento.dataFabricacao, [Validators.required]),
      fabricante: new FormControl(equipamento.fabricante, [Validators.required]),
    })
  }

  onSubmit() {
    if (this.form.valid) {
      const equipamento: IEquipamento = {
        id: this.form.value.id == null ? 0 : this.form.value.id,
        nome: this.form.value.nome,
        preco: this.form.value.preco,
        nrSerie: this.form.value.nrSerie,
        dataFabricacao: this.form.value.dataFabricacao,
        fabricante: this.form.value.fabricante
      }
      console.log(equipamento);

      if (equipamento.id) {
        this.observable = this.service.editar(equipamento);
        this.enviar();
      }
      else {
        this.observable = this.service.cadastrar(equipamento);
        this.enviar();
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
