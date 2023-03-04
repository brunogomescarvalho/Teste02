import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormChamadoComponent } from './features/chamados/form-chamado/form-chamado.component';
import { TableChamadoComponent } from './features/chamados/table-chamado/table-chamado.component';
import { TableEquipamentosComponent } from './features/equipamentos/table-equipamentos/table-equipamentos.component';
import { FormEquipamentosComponent } from './features/equipamentos/form-equipamentos/form-equipamentos.component';
import { HomeComponent } from './features/home/home.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EquipamentoResolve } from './features/equipamentos/resolve-equipamentos/equipamento-resolve.guard';
import { EquipamentoService } from './features/equipamentos/equipamentosService';
import { ChamadoService } from './features/chamados/chamadoService';
import { ChamadoResolve } from './features/chamados/chamado-resolve.guard';
import { DatePipe } from '@angular/common';
import { DetalhesComponent } from './features/chamados/detalhes/detalhes.component';

@NgModule({
  declarations: [
    AppComponent,
    FormChamadoComponent,
    TableChamadoComponent,
    TableEquipamentosComponent,
    FormEquipamentosComponent,
    HomeComponent,
    DetalhesComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,

  ],
  providers: [
    EquipamentoResolve,
    EquipamentoService,
    ChamadoResolve,
    ChamadoService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
