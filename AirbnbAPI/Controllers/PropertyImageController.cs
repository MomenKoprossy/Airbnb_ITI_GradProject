using App.Repository;
using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AirbnbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IRepository<PropertyImage> _context;
        private UserManager<User> UserManager;
        private readonly IWebHostEnvironment _host;
        public PropertyImageController(UserManager<User> userManager, IRepository<PropertyImage> context, IWebHostEnvironment host)
        {
            _context = context;
            UserManager = userManager;
            _host = host;
        }
        [HttpGet]
        public async Task<IActionResult> getall()
        {
            return Ok(await _context.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> PropertyImageById(int id)
        {
            var p = await _context.GetPropertyImage(id);
            return Ok(p);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePropertyImage(int id)
        {
            await _context.DeleteAsync(id, "");
            return Ok("deleted");
        }
        [HttpPost]
        [Route("AddPropertyImages/{id}")]
        [Authorize]
        public async Task<ActionResult> AddPropertyImage(int id)
        {
            int propId = 0;
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var File = Request.Form.Files[i];
                var FileName = File.FileName;
                string uploads = Path.Combine(_host.WebRootPath, @"images\property");
                string fullpath = Path.Combine(uploads, FileName);
                File.CopyTo(new FileStream(fullpath, FileMode.Create));
                PropertyImage propertyImage = new PropertyImage { Image = FileName, PropertyID = id };
                propId = await _context.InsertAsync(propertyImage);
            }
            return Ok(propId);
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePropertyImage(PropertyImage PropertyImage)
        {
            await _context.UpdateAsync(PropertyImage);
            return Ok("PropertyImage Updated");
        }

    }
}
