using System.Collections.Generic;
using ConfigManager.Models;
using ConfigManager.Services.Interfaces;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ConfigManager.Services.Implementation
{
    public class HateoasService : IHateoasService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HateoasService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        
        public List<HateoasExtension> GenerateHostLinks(Host host)
        {
            HttpContext context = _contextAccessor.HttpContext;
            List<HateoasExtension> Links = new List<HateoasExtension>();
            
            Links.Add(new HateoasExtension
            {
                Href = context.Request.PathBase + "/hosts/" + host.Id,
                Rel = "Detail",
                Method = "GET"
            });
            
            Links.Add(new HateoasExtension
            {
                Href = context.Request.PathBase + "/hosts",
                Rel = "Create",
                Method = "POST"
            });
            
            Links.Add(new HateoasExtension
            {
                Href = context.Request.PathBase + "/hosts/" + host.Id,
                Rel = "Update",
                Method = "PUT"
            });
            
            Links.Add(new HateoasExtension
            {
                Href = context.Request.PathBase + "/hosts/" + host.Id,
                Rel = "Delete",
                Method = "DELETE"
            });

            return Links;
        }
    }
}