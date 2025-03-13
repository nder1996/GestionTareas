export class ApiResponse<T> {
    meta?: ApiResponse.Meta;
    data?: T;
    error?: ApiResponse.ErrorDetails;
    constructor(data?: Partial<ApiResponse<T>>) {
      if (data) {
        Object.assign(this, data);
      }
    }
  }
  export namespace ApiResponse {
    export class Meta {
      message?: string;
      statusCode?: number;
      constructor(data?: Partial<Meta>) {
        if (data) {
          Object.assign(this, data);
        }
      }
    }
    export class ErrorDetails {
      code?: string;
      description?: string;

      constructor(data?: Partial<ErrorDetails>) {
        if (data) {
          Object.assign(this, data);
        }
      }
    }
  }
