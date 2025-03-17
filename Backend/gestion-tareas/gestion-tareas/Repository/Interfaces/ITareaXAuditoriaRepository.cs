using gestion_tareas.Models;

namespace gestion_tareas.Repository.Interfaces
{
    public interface ITareaXAuditoriaRepository
    {
        Task<List<TareaXAuditoria>> ByIdAuditoriXUltimoTareaAsync(int idTarea);
        Task<Auditoria> ByIdAuditoriaXTareaAsync(int idAuditoria);
        Task<int> InsertAuditoriaAsync(Auditoria auditoria);
        Task<int> InsertTareaXAuditoriaAsync(TareaXAuditoria tareaXAuditoria);
    }
}
