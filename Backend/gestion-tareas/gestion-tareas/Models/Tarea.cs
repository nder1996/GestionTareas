namespace gestion_tareas.Models
{
    public class Tarea
    {
        public int? Id { get; set; }
        public string? titulo { get; set; }
        public string? descripcion { get; set; }
        public int? idEstado { get; set; }
        public int? idPrioridad { get; set; }
        public DateTime? fechaVencimiento { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? update_at { get; set; }
    }
}

