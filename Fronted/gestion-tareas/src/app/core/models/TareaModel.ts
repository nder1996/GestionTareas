export class TareaModel {
    constructor(
      public id?: number,
      public titulo?: string,
      public descripcion?: string,
      public idEstado?: number,
      public idEstadoAnterior?: number,
      public idPrioridad?: number,
      public fechaVencimiento?: Date,
      public create_at?: Date,
      public update_at?: Date
    ) {}
  }
