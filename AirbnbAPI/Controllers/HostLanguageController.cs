using App.Repository;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirbnbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostLanguageController : ControllerBase
    {
        private readonly IRepository<HostLanguage> _context;
        public HostLanguageController(IRepository<HostLanguage> context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> getall()
        {
            return Ok(await _context.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HostLanguage>> HostLanguageById(string id)
        {
            HostLanguage p = await _context.GetByIdAsync(0, id);
            return Ok(p);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHostLanguage(string id)
        {
            await _context.DeleteAsync(0, id);
            return Ok("deleted");
        }
        [HttpPost]

        public async Task<ActionResult> AddHostLanguage(HostLanguage HostLanguage)
        {

            var x = await _context.InsertAsync(HostLanguage);
            return Ok(x);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHostLanguage(HostLanguage HostLanguage)
        {
            await _context.UpdateAsync(HostLanguage);
            return Ok("HostLanguage Updated");
        }

    }
}
