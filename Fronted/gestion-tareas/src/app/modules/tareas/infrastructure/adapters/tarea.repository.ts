import { firstValueFrom } from "rxjs";
import { ApiResponse } from "../../application/dtos/response/api-response.model";
import { TareaRequest } from "../../application/dtos/request/tarea-request.model";
import { ITareaRepositorio } from "../../domain/ITareaRepository";
import { TareaModel } from "src/app/core/models/TareaModel";
import { GestionTareasResponse } from "../../application/dtos/response/gestion-tareas-response";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/app/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class TareaRepositorio implements ITareaRepositorio {
    private apiUrl = `${environment.apiUrl}/Tareas`;

    constructor(private http: HttpClient) { }

    async gestionTareas(): Promise<ApiResponse<GestionTareasResponse[]>> {
        return firstValueFrom(
            this.http.get<ApiResponse<GestionTareasResponse[]>>(`${this.apiUrl}/getAllGestionTareas`)
        );
    }

    async gestionHistoricoTareas(): Promise<ApiResponse<GestionTareasResponse[]>> {
        return firstValueFrom(
            this.http.get<ApiResponse<GestionTareasResponse[]>>(`${this.apiUrl}/getAllAuditoria`)
        );
    }

    async findAll(): Promise<ApiResponse<TareaModel[]>> {
        return firstValueFrom(
            this.http.get<ApiResponse<TareaModel[]>>(this.apiUrl)
        );
    }

    async findById(id: number): Promise<ApiResponse<TareaModel>> {
        return firstValueFrom(
            this.http.get<ApiResponse<TareaModel>>(`${this.apiUrl}/${id}`)
        );
    }

    async inactivateById(id: number): Promise<ApiResponse<string>> {
        return firstValueFrom(
            this.http.put<ApiResponse<string>>(`${this.apiUrl}/inactivate/${id}`, {})
        );
    }

    async activarById(id: number, idEstado: number): Promise<ApiResponse<string>> {
        return firstValueFrom(
            this.http.put<ApiResponse<string>>(`${this.apiUrl}/activate/${id}`, { idEstado })
        );
    }

    async insert(tareaRequest: TareaRequest): Promise<ApiResponse<string>> {
        return firstValueFrom(
            this.http.post<ApiResponse<string>>(this.apiUrl, tareaRequest)
        );
    }

    async update(tareaRequest: TareaRequest): Promise<ApiResponse<string>> {
        return firstValueFrom(
            this.http.put<ApiResponse<string>>(`${this.apiUrl}/${tareaRequest.id}`, tareaRequest)
        );
    }

    saveAuditoria(idTarea: number, idEstado: number, idPrioridad: number, tipoAuditoria: string): void {
        this.http.post(`${this.apiUrl}/auditoria`, {
            idTarea,
            idEstado,
            idPrioridad,
            tipoAuditoria
        }).subscribe();
    }
}