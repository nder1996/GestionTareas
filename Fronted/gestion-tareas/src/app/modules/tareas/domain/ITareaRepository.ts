import { TareaModel } from "src/app/core/models/TareaModel";
import { ApiResponse } from "../application/dtos/request/api-response.model";
import { GestionTareasResponse } from "../application/dtos/response/GestionTareasResponse";
import { TareaRequest } from "../application/dtos/request/tarea-request.model";

export interface ITareaRepositorio {
    gestionTareas(): Promise<ApiResponse<GestionTareasResponse[]>>;
    gestionHistoricoTareas(): Promise<ApiResponse<GestionTareasResponse[]>>;
    findAll(): Promise<ApiResponse<TareaModel[]>>;
    findById(id: number): Promise<ApiResponse<TareaModel>>;
    inactivateById(id: number): Promise<ApiResponse<string>>;
    activarById(id: number, idEstado: number): Promise<ApiResponse<string>>;
    insert(tareaRequest: TareaRequest): Promise<ApiResponse<string>>;
    update(tareaRequest: TareaRequest): Promise<ApiResponse<string>>;
    saveAuditoria(idTarea: number, idEstado: number, idPrioridad: number, tipoAuditoria: string): void;
  }