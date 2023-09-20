using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAcces;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Repositories.Interfaces;

namespace TpIntegradorSofttek.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<List<Service>> GetAll()
        {
            return await _context.Set<Service>().Where(p => p.EndDate == null).ToListAsync();
        }

        public async Task<List<Service>> GetAll(ServiceFilterDto filterDto)
        {
            return await _context.Set<Service>().Where(p => p.EndDate == null && p.State == filterDto.State).ToListAsync();
        }


        public override async Task<Service> GetById(int id)
        {
            var list = await _context.Set<Service>().Where(p => p.EndDate == null && p.Id == id).ToListAsync();
            return list.Count < 1 ? null : list[0];
        }

        public override async Task<bool> Update(Service updateService)
        {
            var service = await _context.Services.SingleOrDefaultAsync(p => p.Id == updateService.Id);

            if (service == null) return false;

            service.Description = updateService.Description;
            service.State = updateService.State;
            service.HourValue = updateService.HourValue;

            _context.Update(service);

            return true;

        }
    }
}
