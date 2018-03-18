using api.Models;
using api.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using api.Controllers.Common;
using Newtonsoft.Json;

namespace api.Controllers
{
    public class NuancesController : BaseApiController
    {
        //readonly JsonSerializerSettings jsonSS = new JsonSerializerSettings
        //{
        //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        //    ContractResolver = new JsonContractResolver()
        //};

        // TODO: resources can be instantiated per request to
        // avoid persistent connections with DB (depends on setup)
        private NuanceResource resource { get; set; }

        public NuancesController(NuanceResource resource)
        {
            this.resource = resource;
        }

        [HttpGet]
        public async Task<JsonResult> ListAsync()
        {
            var results = await resource.ListAsync();
            return new JsonResult(results);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> ReadAsync(int id)
        //{
        //    var res = await resource.FindAsync(id);
        //    if (res == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(res);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync([FromBody] Nuance item)
        //{
        //    if (item == null)
        //    {
        //        return BadRequest();
        //    }
        //    await resource.AddAsync(item);
        //    return CreatedAtRoute(new { id = item.NuanceID }, item);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> ReplaceAsync(int id, [FromBody] Nuance item)
        //{
        //    if (item == null || item.NuanceID != id)
        //    {
        //        return BadRequest();
        //    }

        //    var res = await resource.FindAsync(id);
        //    if (res == null)
        //    {
        //        return NotFound();
        //    }

        //    await resource.UpdateAsync(item);
        //    return new NoContentResult();
        //}

        //[HttpPatch("{id}")]
        //public async Task<IActionResult> UpdateAsync(int id, [FromBody] Nuance item)
        //{
        //    if (item == null)
        //    {
        //        return BadRequest();
        //    }

        //    var res = await resource.FindAsync(id);
        //    if (res == null)
        //    {
        //        return NotFound();
        //    }

        //    item.NuanceID = res.NuanceID;

        //    await resource.UpdateAsync(item);

        //    return new NoContentResult();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var res = await resource.FindAsync(id);
        //    if (res == null)
        //    {
        //        return NotFound();
        //    }

        //    await resource.RemoveAsync(id);

        //    return new NoContentResult();
        //}
    }
}