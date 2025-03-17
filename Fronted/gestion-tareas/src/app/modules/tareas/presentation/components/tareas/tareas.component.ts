import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { EstadoResponse } from '../../../application/dtos/response/estado-response';
import { GestionTareasResponse } from '../../../application/dtos/response/gestion-tareas-response';
import { PrioridadResponse } from '../../../application/dtos/response/prioridad-response';
import { MessageService } from 'primeng/api';
import { TareaRepositorio } from '../../../infrastructure/adapters/tarea.repository';
import { ReferenceDataRepository } from '../../../infrastructure/adapters/reference-data.repository';
import { TareaRequest } from '../../../application/dtos/request/tarea-request.model';

@Component({
  selector: 'app-tareas',
  templateUrl: './tareas.component.html',
  styleUrls: ['./tareas.component.css']
})
export class TareasComponent {

  constructor(private tareaRepository: TareaRepositorio, private cdr: ChangeDetectorRef,
    private messageService: MessageService, private referenceDataRepository: ReferenceDataRepository, private fb: FormBuilder,
    private router: Router) {
    this.taskForm = this.fb.group({
      idTarea: [],
      titulo: ['', [Validators.required]],
      descripcion: ['', [Validators.required]],
      fechaVencimiento: [null, [Validators.required]],
      prioridad: [null, [Validators.required]],
      estado: [null, [Validators.required]]
    });
}

  public listTask: GestionTareasResponse[] = []
  public listHistoryTask: GestionTareasResponse[] = [];
  public listPrioridades: PrioridadResponse[] = [];
  public listEstados: EstadoResponse[] = [];
  public idEliminar: number = 0;

  public actionEditarCrud: boolean = false;
  public taskForm!: FormGroup;
  public showHistoryTask: boolean = false;
  public showTask: boolean = false;
  public showDelete: boolean = false;


  getNombreEstado(estado: number): string {
    const name = this.listEstados.find(e => e.id == estado)?.nombre || "";
    return name;
  }
  getSeverityEstado(estado: number): string {
    const name = this.listEstados.find(e => e.id == estado)?.severity || "";
    return name;
  }

  getNombrePrioridad(estado: number): string {
    const name = this.listEstados.find(e => e.id == estado)?.nombre || "";
    return name;
  }
  getSeverityPrioridad(estado: number): string {
    const name = this.listEstados.find(e => e.id == estado)?.severity || "";
    return name;
  }


  async ngOnInit() {
    // console.log('3. NgOnInit - Después del constructor');
    await this.getTasks();
  }

  ngAfterViewInit(): void {
    // console.log('4. NgAfterViewInit - Después de inicializar la vista');
    this.cdr.detectChanges();

  }

  reloadPage() {
    const currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]).then(() => {
        this.cdr.detectChanges(); // Asegura la actualización de la vista
      });
    });
  }


  onSubmit() {
    if (this.taskForm.valid) {
      const task: TareaRequest = {
        id: this.taskForm.get('idTarea')?.value || null,
        titulo: this.taskForm.get('titulo')?.value,
        descripcion: this.taskForm.get('descripcion')?.value,
        fechaVencimiento: this.taskForm.get('fechaVencimiento')?.value,
        idEstado: this.taskForm.get('estado')?.value?.id || 1,
        idPrioridad: this.taskForm.get('prioridad')?.value?.id,
        createAt: new Date(),
        updateAt: new Date()
      };
      this.createTask(task);
      if (this.actionEditarCrud) {
        // Lógica de edición
      } else {
        // Lógica de creación
      }
    } else {
      // Marcar todos los campos como touched para mostrar los errores
      Object.keys(this.taskForm.controls).forEach(key => {
        const control = this.taskForm.get(key);
        control?.markAsTouched();
      });
    }
  }


  async cargarModalAgregar() {
    this.taskForm.reset();
    await this.getAllPrioridades();
    await this.getAllEstados();
    this.actionEditarCrud = false;
    this.showTask = true;
    let estadoEncontrado = this.listEstados.find(estado => estado.id === 1);
    this.selectedEstado = estadoEncontrado ?? new EstadoResponse();
    this.taskForm.get('estado')?.setValue(estadoEncontrado);
    this.taskForm.get('estado')?.disable();
    this.cdr.detectChanges();
  }

  selectedPrioridad: PrioridadResponse = new PrioridadResponse();
  selectedEstado: EstadoResponse = new EstadoResponse();


  async cargarModalEditar(task: GestionTareasResponse) {
    if (task) {
      await this.getAllPrioridades();
      await this.getAllEstados();
      this.taskForm.get('estado')?.enable();
      this.selectedPrioridad = task.prioridad ?? new PrioridadResponse();
      this.selectedEstado = task.estado ?? new EstadoResponse();
      console.log('modal editar : ' + JSON.stringify(this.selectedPrioridad))
      this.taskForm.patchValue({
        idTarea: task.idTarea,
        titulo: task.tituloTarea,
        descripcion: task.descripcionTarea,
        fechaVencimiento: task.fechaVencimiento ? new Date(task.fechaVencimiento) : null,
        estado: task.estado,
        prioridad: task.prioridad,
      });

      // console.log("datos de form : " + JSON.stringify(this.taskForm.value))
    }
    this.actionEditarCrud = true;
    this.cdr.detectChanges();
    this.showTask = true;
   
  
  }


  async dialogHistoryTask() {
    await this.getAllPrioridades();
    await this.getAllEstados();
    await this.getHistoyTasks();
    this.showHistoryTask=true;
  }

  onCancel() {
    this.showTask = false;
    this.taskForm.reset();
  }


  async createTask(task: TareaRequest): Promise<void> {
    try {
      const response = await this.tareaRepository.insert(task);
      
      if (response.error) {
        this.messageService.add({ 
          severity: 'error', 
          summary: 'Error', 
          detail: response.error.description || 'Error al crear la tarea'
        });
        return;
      }
      
      this.messageService.add({
        severity: 'success',
        summary: 'Éxito',
        detail: 'Tarea creada exitosamente'
      });

      // Reset del formulario o estado si es necesario
      await this.ngOnInit()
      this.showTask = false;

      // Recargar datos o actualizar vista
     

    } catch (error) {
      console.error('Error al crear la tarea:', error);
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error al crear la tarea'
      });
    }
  }


  async activarTarea(idTarea: number): Promise<void> {
    try {
      const response = await this.tareaRepository.activarById(idTarea, 1); // Asumiendo que 1 es el ID del estado activo
      
      if (response.error) {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: response.error.description || 'Error desconocido'
        });
        return;
      }

      this.messageService.add({
        severity: 'success',
        summary: 'Éxito',
        detail: 'Tarea Activada'
      });

      this.showHistoryTask = false;
      await this.ngOnInit()


    } catch (error) {
      console.error('Error al activar la tarea:', error);
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error al activar la tarea'
      });
    }
  }


  async deleteTask(id: number): Promise<void> {
    try {
      const response = await this.tareaRepository.inactivateById(id);
      if (response.error) {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: response.error.description || 'Error desconocido'
        });
        return;
      }

      this.messageService.add({
        severity: 'success',
        summary: 'Éxito',
        detail: 'Tarea Borrada'
      });

      await this.ngOnInit()
      this.showDelete = false;


    } catch (error) {
      console.error('Error al inactivar la tarea:', error);
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error al inactivar la tarea'
      });
    }
  }


  async getTasks(): Promise<void> {
    try {
      const response = await this.tareaRepository.gestionTareas();
      if (response.error && response.error.code == "NO_CONTENT") {
        this.messageService.add({
          severity: 'warn', summary: 'Warning',
          detail: response.error.description || 'Error desconocido'
        });
        return;
      }

      if (!response.data?.length) {
        this.messageService.add({
          severity: 'warn', summary: 'Warning',
          detail: 'No se encontraron tareas'
        });
        this.listTask = [];
        return;
      }
      this.listTask = response.data;
      this.reloadPage()
    } catch (error) {
      console.error('Error al obtener tareas:', error);
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error al cargar las tareas'
      });
      this.listTask = [];
    }
  }

  async getHistoyTasks(): Promise<void> {
    try {
      const response = await this.tareaRepository.gestionHistoricoTareas();
      if (response.error && response.error.code == "NO_CONTENT") {
        this.messageService.add({
          severity: 'warn', summary: 'Warning',
          detail: response.error.description || 'Error desconocido'
        });
        return;
      }

      if (!response.data?.length) {
        this.messageService.add({
          severity: 'warn', summary: 'Warning',
          detail: 'No se encontraron tareas'
        });
        this.listHistoryTask = [];
        return;
      }
      console.log("historico de imprimir : "+JSON.stringify(response.data))
      this.listHistoryTask = response.data;
      this.reloadPage()

    } catch (error) {
      console.error('Error al obtener tareas:', error);
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error al cargar las tareas'
      });
      this.listHistoryTask = [];
    }
  }


  async getAllPrioridades(): Promise<void> {
    try {
      const response = await firstValueFrom(this.referenceDataRepository.getAllPrioridades());
      if (response && response.meta?.statusCode!=200) {
        this.messageService.add({
          severity: 'warn', summary: 'Warning',
          detail: response?.error?.description || 'Error desconocido'
        });
        return;
      }

      if (!response.data?.length) {
        this.messageService.add({
          severity: 'warn', summary: 'Warning',
          detail: 'No se encontraron prioridades'
        });
        this.listPrioridades = [];
        return;
      }
      this.listPrioridades = response.data;
      // console.log("prioridades : " + JSON.stringify(this.listPrioridades))
    } catch (error) {
      console.error('Error al obtener prioridades:', error);
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error al cargar las prioridades'
      });
      this.listPrioridades = [];
    }
  }

  async getAllEstados(): Promise<void> {
    try {
      const response = await firstValueFrom(this.referenceDataRepository.getAllEstados());
      if (response.error && response.meta?.statusCode!=200) {
        this.messageService.add({
          severity: 'warn', summary: 'Warning',
          detail: response.error.description || 'Error desconocido'
        });
        return;
      }

      if (!response.data?.length) {
        this.messageService.add({
          severity: 'warn', summary: 'Warning',
          detail: 'No se encontraron estados'
        });
        this.listEstados = [];
        return;
      }
      this.listEstados = response.data.filter((estado: EstadoResponse) => estado.id !== 4);

      //console.log("estados : " + JSON.stringify(this.listEstados))
    } catch (error) {
      console.error('Error al obtener estados:', error);
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error al cargar los estados'
      });
      this.listEstados = [];
    }
  }
}
