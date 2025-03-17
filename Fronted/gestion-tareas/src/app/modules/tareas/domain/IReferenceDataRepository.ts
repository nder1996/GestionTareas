
import { ApiResponse } from "../application/dtos/response/api-response.model";
import { Observable } from "rxjs";
import { EstadoResponse } from "../application/dtos/response/estado-response";
import { PrioridadResponse } from "../application/dtos/response/prioridad-response";

export interface IReferenceDataRepository {
    getAllPrioridades(): Observable<ApiResponse<PrioridadResponse[]>>;
    getAllEstados(): Observable<ApiResponse<EstadoResponse[]>>;
}