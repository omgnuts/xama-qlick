using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Resources
{
    public class NuanceResource : IResource<Nuance>
    {
        private readonly DataContext context;

        public NuanceResource(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Nuance>> ListAsync()
        {
            return await context.Nuances.AsNoTracking()
                .OrderByDescending(n => n.NuanceID)
                .Include(n => n.Waypoints)
                .ToListAsync();

            //IEnumerable<Nuance> nuances = await context.Nuances.AsNoTracking()
            //    .Include(n => n.Waypoints)
            //    .ToListAsync();

            //foreach (Nuance nuance in nuances)
            //{
            //    nuance.Waypoints = nuance.Waypoints.OrderBy(w => w.Order);
            //}
            //return nuances.ToList();
        }

        public async Task<Nuance> LatestAsync()
        {
            Nuance nuance = await context.Nuances
                .Include(n => n.Waypoints)
                .OrderByDescending(n => n.NuanceID)
                .Take(1)
                .SingleOrDefaultAsync();

            nuance.Waypoints = nuance.Waypoints.OrderBy(w => w.Order).ToList();

            return nuance;
        }

        public async Task<Nuance> FindAsync(int key)
        {
            return await context.Nuances
                .Where(r => r.NuanceID.Equals(key))
                .SingleOrDefaultAsync();
        }

        public async Task<int> AddAsync(Nuance item)
        {
            await context.Nuances.AddAsync(item);
            return await context.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(Nuance[] items)
        {
            await context.Nuances.AddRangeAsync(items);
            return await context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int key)
        {
            var res = await FindAsync(key);
            if (res != null)
            {
                context.Nuances.Remove(res);
                return await context.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }

        public async Task<int> UpdateAsync(Nuance item)
        {
            var res = await FindAsync(item.NuanceID);
            if (res != null)
            {
                res.Title = item.Title;
                res.Description = item.Description;
                return await context.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }

        public async Task<int> QuickUpdateAsync(Nuance item)
        {
            if (item != null)
            {
                return await context.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }

    }
}
