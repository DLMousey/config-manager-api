using System.Collections.Generic;
using ConfigManager.Models;

// ReSharper disable InconsistentNaming
namespace ConfigManager.ViewModels
{
    public class HostViewModel
    {
        public Host data { get; set; }

        public List<HateoasExtension> _links { get; set; }
    }
}