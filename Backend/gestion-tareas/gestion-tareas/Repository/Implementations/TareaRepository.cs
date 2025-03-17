using gestion_tareas.DBContext;
using gestion_tareas.DTOs.Request;
using gestion_tareas.DTOs.Response;
using gestion_tareas.Models;
using gestion_tareas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace gestion_tareas.Repository.Implementations
{
    public class TareaRepository : ITareaRepository
    {

        private readonly TareasDbContext _context;

        public TareaRepository(TareasDbContext context)
        {
            _context = context;
        }


        public Task<int> ActivarByIdAsync(int id, int idEstado)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tarea>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tarea> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<List<TareaXAuditoria>> GestionHistoricoTareasAsync()
        {
            return _context.Tarea
                .Join(_context.TareaXAuditoria,
                    t => t.Id,
                    ta => ta.Tarea.Id,
                    (t, ta) => new { Tarea = t, TareaAuditoria = ta })
                .Join(_context.Auditoria,
                    tta => tta.TareaAuditoria.Auditoria.Id,
                    a => a.Id,
                    (tta, a) => new { tta.Tarea, tta.TareaAuditoria, Auditoria = a })
                .Join(_context.Estado,
                    ttaa => ttaa.Tarea.idEstado,
                    e => e.Id,
                    (ttaa, e) => new { ttaa.Tarea, ttaa.TareaAuditoria, ttaa.Auditoria, Estado = e })
                .Join(_context.Prioridad,
                    ttaae => ttaae.Tarea.idPrioridad,
                    p => p.Id,
                    (ttaae, p) => new TareaXAuditoria
                    {
                        Id = ttaae.TareaAuditoria.Id,
                        Tarea = ttaae.Tarea,
                        Auditoria = ttaae.Auditoria,
                        create_at = ttaae.TareaAuditoria.create_at
                    })
                .OrderBy(r => r.Tarea.Id)
                .ThenByDescending(r => r.Auditoria.CreateAt)
                .ToListAsync();
        }



        public Task<List<GestionTareasResponse>> GestionTareasAsync()
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
                             updateAt = te.Tarea.update_at
                         })
                     .Where(r => r.estado.Id != 4)
                     .ToListAsync();
        }

        public Task<int> InactivateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(TareaRequest tareaRequest)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TareaRequest tareaRequest)
        {
            throw new NotImplementedException();
        }
    }
}
