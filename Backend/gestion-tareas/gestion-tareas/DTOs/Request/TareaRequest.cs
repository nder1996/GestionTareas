using System.ComponentModel.DataAnnotations;

namespace gestion_tareas.DTOs.Request
{
    public class TareaRequest
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres")]
        public string? titulo { get; set; }

        public string? estado { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        public string? descripcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estado válido")]
        public int? idEstado { get; set; }

        [Required(ErrorMessage = "La prioridad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una prioridad válida")]
        public int? idPrioridad { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "La fecha de vencimiento debe ser posterior a la fecha actual")]
        public DateTime? fechaVencimiento { get; set; }

        public DateTime? create_at { get; set; }
        public DateTime? update_at { get; set; }
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
                return true;

            return (DateTime)value > DateTime.Now;
        }
    }
}
