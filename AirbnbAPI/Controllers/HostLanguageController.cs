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
        public async Task<IActionResult> getall()
        {
            return  Ok(await _context.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HostLanguage>> HostLanguageById(string id)
        {
            HostLanguage p =  await _context.GetByIdAsync(0, id);
            return p;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteHostLanguage(string id)
        {
            _context.Delete(0, id);
            return Ok("deleted");
        }
        [HttpPost]

        public IActionResult AddHostLanguage(HostLanguage HostLanguage)
        {

            _context.Insert(HostLanguage);
            return Ok("HostLanguage Added");
        }

        [HttpPut]
        public IActionResult UpdateHostLanguage(HostLanguage HostLanguage)
        {
            _context.Update(HostLanguage);
            return Ok("HostLanguage Updated");
        }

    }
}
