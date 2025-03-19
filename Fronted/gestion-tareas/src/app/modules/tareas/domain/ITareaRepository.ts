import { TareaModel } from "src/app/core/models/TareaModel";
import { ApiResponse } from "../application/dtos/response/api-response.model";
import { GestionTareasResponse } from "../application/dtos/response/gestion-tareas-response";
import { TareaRequest } from "../application/dtos/request/tarea-request.model";

export interface ITareaRepositorio {
    gestionTareas(): Promise<ApiResponse<GestionTareasResponse[]>>;
    getAllHistorico(): Promise<ApiResponse<GestionTareasResponse[]>>;
    inactivateById(id: number): Promise<ApiResponse<string>>;
    activarById(tareaRequest: TareaRequest): Promise<ApiResponse<string>>;
    insert(tareaRequest: TareaRequest): Promise<ApiResponse<string>>;
  }