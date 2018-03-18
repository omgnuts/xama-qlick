using api.Models;
using api.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using api.Controllers.Common;
using Newtonsoft.Json;
using api.Data;
using System;

namespace api.Controllers
{
    public class DemoController : BaseApiController
    {
        private NuanceResource resource { get; set; }

        private WaypointResource wpresource { get; set; }

        private DataContext context { get; set; }

        public DemoController(DataContext context, NuanceResource resource, WaypointResource wpresource)
        {
            this.resource = resource;
            this.wpresource = wpresource;
            this.context = context;
        }

        [HttpGet]
        [Route("reset")]
        public async Task<ActionResult> Reset()
        {
            await context.WipeDatabase();
            var results = await resource.AddRangeAsync(MockData.GenerateDefaults());
            return new OkResult();
        }

        [HttpGet]
        [Route("add-shipment")]
        public async Task<ActionResult> AddShipment()
        {
            var results = await resource.AddAsync(MockData.GenerateShipment());
            return new OkResult();
        }

        [HttpGet]
        [Route("trigger-blockchain")]
        public async Task<ActionResult> TriggerBlockchain()
        {
            Nuance item = await resource.LatestAsync();
            item = mockUpdate(item);
            var results = await resource.QuickUpdateAsync(item);
            return new OkResult();
        }

        Nuance mockUpdate(Nuance nuance)
        {
            for (int c = 0; c < nuance.Waypoints.Count; c++)
            {
                Waypoint wp = nuance.Waypoints[c];

                if (wp.Status == 0 && c < nuance.Waypoints.Count - 1)
                {
                    wp.Status = Models.Definitions.WaypointStatus.Previous;
                    if (c < nuance.Waypoints.Count - 1)
                    {
                        Waypoint next = nuance.Waypoints[c + 1];
                        next.Status = Models.Definitions.WaypointStatus.Current;
                        next.BlockChain = 1;
                    }

                    return nuance;
                }
            }
            return nuance;
        }
    }
}
