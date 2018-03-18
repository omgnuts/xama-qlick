using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Resources
{
    public class WaypointResource : IResource<Waypoint>
    {
        private readonly DataContext context;

        public WaypointResource(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Waypoint>> ListAsync()
        {
            return await context.Waypoints.AsNoTracking().ToListAsync();
        }

        public async Task<Waypoint> FindAsync(int key)
        {
            return await context.Waypoints
                .Where(r => r.WaypointID.Equals(key))
                .SingleOrDefaultAsync();
        }

        public async Task<int> AddAsync(Waypoint item)
        {
            await context.Waypoints.AddAsync(item);
            return await context.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(Waypoint[] items)
        {
            await context.Waypoints.AddRangeAsync(items);
            return await context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int key)
        {
            var res = await FindAsync(key);
            if (res != null)
            {
                context.Waypoints.Remove(res);
                return await context.SaveChangesAsync();

            }
            return await Task.FromResult(0);
        }

        public async Task<int> UpdateAsync(Waypoint item)
        {
            var res = await FindAsync(item.WaypointID);
            if (res != null)
            {
                res.Title = item.Title;
                return await context.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
    }
}
