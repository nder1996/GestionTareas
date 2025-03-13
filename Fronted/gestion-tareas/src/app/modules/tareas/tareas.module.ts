import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { PaginaPrincipalComponent } from './presentation/pages/pagina-principal/pagina-principal.component';
import { TareasComponent } from './presentation/components/tareas/tareas.component';
import { TareasRoutingModule } from './tareas-routing.module';

@NgModule({
  declarations: [
    PaginaPrincipalComponent,
    TareasComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    TareasRoutingModule
  ]
})
export class TareasModule { }
