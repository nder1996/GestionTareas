import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  { path: '', redirectTo: 'tareas', pathMatch: 'full' },
  {
    path: 'tareas',
    loadChildren: () => import('./modules/tareas/tareas.module')
      .then(m => m.TareasModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
