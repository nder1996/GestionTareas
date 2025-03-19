using gestion_tareas.DBContext;
using gestion_tareas.DTOs.Request;
using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;
using gestion_tareas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;


namespace gestion_tareas.Repository.Implementations
{
    public class TareaRepository : ITareaRepository
    {

        private readonly TareasDbContext _context;

        public TareaRepository(TareasDbContext context)
        {
            _context = context;
        }


        public int ActivarTask(TareaRequest tareaRequest)
        {
            /*var tarea = _context.Tarea.Find(id);
            if (tarea == null)
            {
                return 0;
            }*/
            tareaRequest.estado = "A";
            tareaRequest.idEstado = 1;
            tareaRequest.update_at = DateTime.Now;
            _context.SaveChanges();
            return 1;
        }

        public List<GestionTareasResponse> getAllHistorico()
        {
            return _context.Tarea
                     .Join(_context.Estado,
                         t => t.idEstado,
                         e => e.Id,
                         (t, e) => new { Tarea = t, Estado = e })
                     .Join(_context.Prioridad,
                         te => te.Tarea.idPrioridad,
                         p => p.Id,
                         (te, p) => new GestionTareasResponse
                         {
                             idTarea = te.Tarea.Id,
                             tituloTarea = te.Tarea.titulo,
                             descripcionTarea = te.Tarea.descripcion,
                             fechaVencimiento = te.Tarea.fechaVencimiento,
                             estado = te.Estado,
                             prioridad = p,
                             createAt = te.Tarea.create_at,
                             updateAt = te.Tarea.update_at,
                             estadoTarea = te.Tarea.estado,
                         })
                     .Where(r => r.estadoTarea == "I" || r.estado.Id == 3)
                     .ToList();
        }



        public List<GestionTareasResponse> getAllTareas()
        {
            return _context.Tarea
                     .Join(_context.Estado,
                         t => t.idEstado,
                         e => e.Id,
                         (t, e) => new { Tarea = t, Estado = e })
                     .Join(_context.Prioridad,
                         te => te.Tarea.idPrioridad,
                         p => p.Id,
                         (te, p) => new GestionTareasResponse
                         {
                             idTarea = te.Tarea.Id,
                             tituloTarea = te.Tarea.titulo,
                             descripcionTarea = te.Tarea.descripcion,
                             fechaVencimiento = te.Tarea.fechaVencimiento,
                             estado = te.Estado,
                             prioridad = p,
                             createAt = te.Tarea.create_at,
                             updateAt = te.Tarea.update_at,
                             estadoTarea = te.Tarea.estado,
                         })
                     .Where(r => r.estadoTarea == "A" && r.estado.Id != 3)
                     .ToList();
        }

        public int InactivarTask(int id)
        {
            var tarea = _context.Tarea.Find(id);
            if (tarea == null)
            {
                return 0;
            }
            tarea.estado = "I";
            tarea.update_at = DateTime.Now;
            _context.SaveChanges();
            return 1;
        }

        public int InsertTask(Tarea tarea)
        {
            _context.Tarea.Add(tarea);
            _context.SaveChanges();
            return tarea.Id ?? 0;
        }


        public int UpdateTask(Tarea tarea)
        {
            _context.Entry(tarea).State = EntityState.Modified;
            _context.SaveChanges();
            return tarea.Id ?? 0;
        }

    }
}
