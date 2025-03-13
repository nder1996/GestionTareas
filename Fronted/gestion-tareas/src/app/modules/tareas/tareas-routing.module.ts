// src/app/modules/tareas/tareas-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PaginaPrincipalComponent } from './presentation/pages/pagina-principal/pagina-principal.component';


const routes: Routes = [
  { path: '', component: PaginaPrincipalComponent },  // Ruta vacía como página principal
  { path: 'principal', component: PaginaPrincipalComponent },  // Ruta 'principal' sin la barra '/'
  //{ path: 'nueva', component: DetalleTareaComponent },
  //{ path: ':id', component: DetalleTareaComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TareasRoutingModule { }