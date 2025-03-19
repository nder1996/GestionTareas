using gestion_tareas.Models;

namespace gestion_tareas.DTOs.Response
{
    public class GestionTareasResponse
    {
        public long? idTarea { get; set; }
        public string? tituloTarea { get; set; }
        public string? descripcionTarea { get; set; }
        public DateTime? fechaVencimiento { get; set; }
        public Estado? estado { get; set; }

        public string? estadoTarea { get; set; }
        public Prioridad? prioridad { get; set; }
        public DateTime? createAt { get; set; }
        public DateTime? updateAt { get; set; }
    }
}
