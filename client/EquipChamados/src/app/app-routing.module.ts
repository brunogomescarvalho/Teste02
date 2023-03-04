import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChamadoResolve } from './features/chamados/chamado-resolve.guard';
import { DetalhesComponent } from './features/chamados/detalhes/detalhes.component';
import { FormChamadoComponent } from './features/chamados/form-chamado/form-chamado.component';
import { TableChamadoComponent } from './features/chamados/table-chamado/table-chamado.component';
import { FormEquipamentosComponent } from './features/equipamentos/form-equipamentos/form-equipamentos.component';
import { EquipamentoResolve } from './features/equipamentos/resolve-equipamentos/equipamento-resolve.guard';
import { TableEquipamentosComponent } from './features/equipamentos/table-equipamentos/table-equipamentos.component';
import { HomeComponent } from './features/home/home.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'equipamento',
    children: [
      {
        path: 'cadastrar',
        component: FormEquipamentosComponent,
        resolve: { 'equipamento': EquipamentoResolve }

      },
      {
        path: 'gerenciar',
        component: TableEquipamentosComponent,
      },
      {
        path: 'editar/:id',
        component: FormEquipamentosComponent,
        resolve: { 'equipamento': EquipamentoResolve }
      }]
  },
  {
    path: 'chamado',
    children: [
      {
        path: 'cadastrar',
        component: FormChamadoComponent,
        resolve: { 'chamado': ChamadoResolve }
      },
      {
        path: 'gerenciar',
        component: TableChamadoComponent
      },
      {
        path: 'editar/:id',
        component: FormChamadoComponent,
        resolve: { 'chamado': ChamadoResolve }
      },
      {
        path: 'detalhes/:id',
        component: DetalhesComponent,
        resolve: { 'chamado': ChamadoResolve }
      }]
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
