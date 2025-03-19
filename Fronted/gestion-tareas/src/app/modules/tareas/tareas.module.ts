import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { PaginaPrincipalComponent } from './presentation/pages/pagina-principal/pagina-principal.component';
import { TareasComponent } from './presentation/components/tareas/tareas.component';
import { TareasRoutingModule } from './tareas-routing.module';
import { MessagesModule } from 'primeng/messages';
import { ConfirmationService, MessageService } from 'primeng/api';


import { TableModule } from 'primeng/table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Importa estos módulos
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';
import { TagModule } from 'primeng/tag';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { DropdownModule } from 'primeng/dropdown';
import { ToolbarModule } from 'primeng/toolbar';
import { CalendarModule } from 'primeng/calendar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';


@NgModule({
  declarations: [
    PaginaPrincipalComponent,
    TareasComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    TareasRoutingModule,
    MessagesModule,
    /*============*/
    TableModule,
    TableModule,
    ReactiveFormsModule,
    ButtonModule,
    DialogModule ,
    MessagesModule,
    ToastModule,
    TagModule,
    InputTextModule,
    InputTextareaModule,
    DropdownModule,
    HttpClientModule,
    ToolbarModule,
    CalendarModule,
    FormsModule,
    ConfirmDialogModule
    
  ],
  providers: [ConfirmationService, MessageService]
})
export class TareasModule { }
