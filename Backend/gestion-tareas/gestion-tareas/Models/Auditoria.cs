namespace gestion_tareas.Models
{
    public class Auditoria
    {
        public int? Id { get; set; }
        public string? Accion { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreadoPor { get; set; }
    }
}
