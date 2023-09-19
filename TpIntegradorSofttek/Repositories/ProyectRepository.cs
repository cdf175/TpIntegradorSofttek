using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAcces;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Repositories.Interfaces;

namespace TpIntegradorSofttek.Repositories
{
    public class ProyectRepository : Repository<Proyect>, IProyectRepository
    {
        public ProyectRepository(ApplicationDbContext context) : base(context){}

        public override async Task<List<Proyect>> GetAll()
        {
            return await _context.Set<Proyect>().Where(p => p.EndDate == null).ToListAsync();
        }

        public override async Task<Proyect> GetById(int id)
        {
            var list = await _context.Set<Proyect>().Where(p => p.EndDate == null && p.Id == id).ToListAsync();
            return list.Count < 1 ? null : list[0];
        }

        public override async Task<bool> Update(Proyect updateProyect)
        {
            var proyect = await _context.Proyects.SingleOrDefaultAsync(p => p.Id == updateProyect.Id);

            if (proyect == null) return false;

            proyect.Name = updateProyect.Name;
            proyect.State = updateProyect.State;
            proyect.Address = updateProyect.Address;

            _context.Update(proyect);

            return true;

        }
    }
}
