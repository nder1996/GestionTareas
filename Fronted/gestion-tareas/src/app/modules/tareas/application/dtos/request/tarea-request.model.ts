export class TareaRequest {
    constructor(
      public id?: number,
      public titulo?: string,
      public descripcion?: string,
      public idEstado?: number,
      public idPrioridad?: number,
      public fechaVencimiento?: Date,
      public createAt?: Date,
      public updateAt?: Date
    ) {}
  }
