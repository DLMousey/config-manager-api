using System;
using System.Collections.Generic;
using ConfigManager.ViewModels;

namespace ConfigManager.Models
{
    public class Host
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String HostName { get; set; }

        public String IpAddress { get; set; }

        public String OperatingSystem { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public HostViewModel ToViewModel(List<HateoasExtension> links)
        {
            return new HostViewModel
            {
                data = this,
                _links = links
            };
        }
    }
}