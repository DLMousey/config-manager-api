using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConfigManager.Models;
using ConfigManager.Services.Interfaces;
using ConfigManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConfigManager.Controllers
{
    [ApiController]
    [Route("/hosts")]
    public class HostsController : ControllerBase
    {
        private readonly IHostService _hostService;
        private readonly IHateoasService _hateoasService;

        public HostsController(IHostService hostService, IHateoasService hateoasService)
        {
            _hostService = hostService;
            _hateoasService = hateoasService;
        }

        [HttpOptions]
        public IActionResult Options()
        {
            List<object> endpoints = new List<object>();
            
            endpoints.Add(new { Uri = "/", Method = "GET", Description = "Retrieve a list of hosts" });
            endpoints.Add(new { Uri = "/:id", Method = "GET", Description = "Retrieve detail on a specific host"});
            endpoints.Add(new { Uri = "/", Method = "POST", Description = "Create a new host"});
            endpoints.Add(new { Uri = "/:id", Method = "PUT", Description = "Update an existing host"});
            endpoints.Add(new { Uri = "/:id", Method = "DELETE", Description = "Delete an existing host"});

            return Ok(new
            {
                status = 200,
                message = "Available endpoints at /hosts",
                data = endpoints
            });
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromHeader(Name = "Accept")] String accept)
        {
            List<Host> hosts = new List<Host>();
            hosts = await _hostService.FindAll();

            if (hosts == null)
            {
                return Ok(new
                {
                    status = 200,
                    data = new { }
                });
            }

            if (accept.Contains("hateoas"))
            {
                List<HostViewModel> hostViewModels = new List<HostViewModel>();
                hosts.ForEach(h =>
                {
                    hostViewModels.Add(h.ToViewModel(_hateoasService.GenerateHostLinks(h)));
                });
            
                return Ok(hostViewModels);
            }

            return Ok(hosts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, [FromHeader(Name = "Accept")] String accept)
        {
            Host host = await _hostService.Find(id);

            if (host == null)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "No record found matching id: " + id.ToString()
                });
            }

            if (accept.Contains("hateoas"))
            {
                return Ok(host.ToViewModel(_hateoasService.GenerateHostLinks(host)));
            }

            return Ok(host);
        }
    }
}