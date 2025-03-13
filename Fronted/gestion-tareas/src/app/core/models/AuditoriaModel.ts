export class AuditoriaModel {
    constructor(
      public id?: number,
      public idEstado?: number,
      public idPrioridad?: number,
      public accion?: string,
      public create_at?: Date,
      public creadoPor?: string
    ) {}
  }
