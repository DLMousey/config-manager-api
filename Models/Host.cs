using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ConfigManager.ViewModels;

namespace ConfigManager.Models
{
    public class Host
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public String Name { get; set; }

        [Required]
        public String Description { get; set; }
        
        public String HostName { get; set; }

        [Required]
        public String IpAddress { get; set; }

        [Required]
        public String OperatingSystem { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

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