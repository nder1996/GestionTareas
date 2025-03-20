import { firstValueFrom } from "rxjs";
import { ApiResponse } from "../../application/dtos/response/api-response.model";
import { TareaRequest } from "../../application/dtos/request/tarea-request.model";
import { ITareaRepositorio } from "../../domain/ITareaRepository";
import { TareaModel } from "src/app/core/models/TareaModel";
import { GestionTareasResponse } from "../../application/dtos/response/gestion-tareas-response";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment.prod";





@Injectable({
    providedIn: 'root'
})
export class TareaRepositorio implements ITareaRepositorio {
    private apiUrl = `${environment.apiUrl}/Tareas`;

    constructor(private http: HttpClient) {
        //console.log('Current environment:', environment.environment);
        console.log('API URL:', environment.apiUrl);
    }

    async gestionTareas(): Promise<ApiResponse<GestionTareasResponse[]>> {
        return firstValueFrom(
            this.http.get<ApiResponse<GestionTareasResponse[]>>(`${this.apiUrl}/getAllGestionTareas`)
        );
    }

    async getAllHistorico(): Promise<ApiResponse<GestionTareasResponse[]>> {
        return firstValueFrom(
            this.http.get<ApiResponse<GestionTareasResponse[]>>(`${this.apiUrl}/getAllHistorico`)
        );
    }


    async inactivateById(id: number): Promise<ApiResponse<string>> {
        return firstValueFrom(
            this.http.put<ApiResponse<string>>(`${this.apiUrl}/inactivate/${id}`, {})
        );
    }

    async activarById(id: number): Promise<ApiResponse<string>> {
        return firstValueFrom(
            this.http.put<ApiResponse<string>>(`${this.apiUrl}/activate/${id}`, {})
        );
    }



    /*
    async activarById(tareaRequest: TareaRequest): Promise<ApiResponse<string>> {
        return firstValueFrom(
            this.http.put<ApiResponse<string>>(`${this.apiUrl}/activate`, tareaRequest)
        );
    }*/

    async insert(tareaRequest: TareaRequest): Promise<ApiResponse<string>> {
        return firstValueFrom(
            this.http.post<ApiResponse<string>>(`${this.apiUrl}/insertUpdate`, tareaRequest)
        );
    }
}