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
            else
            {
                return Ok(hosts);
            }
        }
    }
}