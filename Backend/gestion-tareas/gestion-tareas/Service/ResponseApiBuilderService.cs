using gestion_tareas.DTOs.Response;

namespace gestion_tareas.Service
{
    public class ResponseApiBuilderService
    {
    
            public static ApiResponse<T> SuccessResponse<T>(T data, string key)
            {
                try
                {
                    return new ApiResponse<T>(
                        Meta: new Meta(Message: "Operación Exitosa", StatusCode: 200),
                        Data: data,
                        Error: null
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

            public static ApiResponse<T> ErrorResponse<T>(int codeHttp, string codeName, string codeDescription)
            {
                try
                {
                    return new ApiResponse<T>(
                        Meta: new Meta(Message: "Solicitud Incorrecta", StatusCode: codeHttp),
                        Data: default,
                        Error: new ErrorDetails(Code: codeName, Description: codeDescription)
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }

