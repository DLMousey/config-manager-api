using System.Collections.Generic;
using ConfigManager.Models;

namespace ConfigManager.Services.Interfaces
{
    public interface IHateoasService
    {
        List<HateoasExtension> GenerateHostLinks(Host host);
    }
}