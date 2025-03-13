import { EstadoModel } from "src/app/core/models/EstadoModel";
import { PrioridadModel } from "src/app/core/models/PrioridadModel";

export class GestionTareasResponse {
    constructor(
      public idTarea?: number,
      public tituloTarea?: string,
      public descripcionTarea?: string,
      public fechaVencimiento?: Date,
      public estado?: EstadoModel,
      public prioridad?: PrioridadModel,
      public createAt?: Date,
      public updateAt?: Date
    ) {}
  }