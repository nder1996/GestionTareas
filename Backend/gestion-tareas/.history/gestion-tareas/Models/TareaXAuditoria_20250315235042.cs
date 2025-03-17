namespace gestion_tareas.Models
{
    public class TareaXAuditoria
    {
        public int? Id { get; set; }
        public int? TareaId { get; set; }
        public int? AuditoriaId { get; set; }
        public Auditoria? Auditoria { get; set; }
        public Tarea? Tarea { get; set; }
        public DateTime? create_at { get; set; }
    }
}
