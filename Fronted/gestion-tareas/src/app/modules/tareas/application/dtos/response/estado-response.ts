export class EstadoResponse {
    constructor(
      public id?: number,
      public nombre?: string,
      public severity?: string,
      public descripcion?: string,
      public estado?: string,
      public create_at?: Date
    ) {}
  }