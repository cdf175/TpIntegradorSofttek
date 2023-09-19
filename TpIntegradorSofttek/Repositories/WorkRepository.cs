using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAcces;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Repositories.Interfaces;

namespace TpIntegradorSofttek.Repositories
{
    public class WorkRepository : Repository<Work>, IWorkRepository
    {
        public WorkRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<List<Work>> GetAll()
        {
            return await _context.Set<Work>().Include(p=>p.Service).Include(p => p.Proyect).Where(p => p.EndDate == null).ToListAsync();
        }

        public override async Task<Work> GetById(int id)
        {
            var list = await _context.Set<Work>().Include(p => p.Service).Include(p => p.Proyect).Where(p => p.EndDate == null && p.Id == id).ToListAsync();
            return list.Count < 1 ? null : list[0];
        }


        public override async Task<bool> Update(Work updateWork)
        {
            var work = await _context.Works.SingleOrDefaultAsync(p => p.Id == updateWork.Id);

            if (work == null) return false;

            work.Date = updateWork.Date;
            work.ProyectId = updateWork.ProyectId;
            work.ServiceId = updateWork.ServiceId;
            work.HourQuantity = updateWork.HourQuantity;
            work.HourValue = updateWork.HourValue;
            work.Cost = updateWork.Cost;

            _context.Update(work);

            return true;

        }

        /// <summary>
        /// Método que retorna un mensaje si los datos ingresados son incorrectos.
        /// </summary>
        /// <param name="work"></param>
        /// <returns> string o null </returns>
        public async Task<string>? workInsertValidator(Work work)
        {
            var proyect = await _context.Proyects.FindAsync(work.ProyectId);
            if(proyect == null) return "El código de proyecto no existe.";
            var service = await _context.Proyects.FindAsync(work.ServiceId);
            if (service == null) return "El código de servicio no existe.";

            return null;
        }

        public WorkResponseDto ConvertToResponseDto(Work work)
        {
            var dto = new WorkResponseDto();
            dto.Date = work.Date;
            dto.Proyect = work.Proyect;
            dto.Service = work.Service;
            dto.HourQuantity = work.HourQuantity;
            dto.HourValue = work.HourValue;
            dto.Cost = work.Cost;

            return dto;
        }

    }
}
