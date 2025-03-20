import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { ApiResponse } from "../../application/dtos/response/api-response.model";
import { EstadoResponse } from "../../application/dtos/response/estado-response";
import { PrioridadResponse } from "../../application/dtos/response/prioridad-response";

@Injectable({
    providedIn: 'root'
})
export class ReferenceDataRepository {
    private apiUrl = `${environment.apiUrl}/Reference`;

    constructor(private http: HttpClient) { }

    getAllPrioridades(): Observable<ApiResponse<PrioridadResponse[]>> {
        return this.http.get<ApiResponse<PrioridadResponse[]>>(`${this.apiUrl}/prioridades`);
    }

    getAllEstados(): Observable<ApiResponse<EstadoResponse[]>> {
        return this.http.get<ApiResponse<EstadoResponse[]>>(`${this.apiUrl}/estados`);
    }
}