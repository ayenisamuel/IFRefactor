using AcmeStudios.Models.Domain.StudioItemTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeStudios.Core.Module.Studio.Dtos
{
    public class GetStudioItemDto
    {
        public int StudioItemId { get; set; }
        public DateTime Acquired { get; set; }
        public DateTime? Sold { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public decimal? SoldFor { get; set; }
        public bool Eurorack { get; set; }
        public int StudioItemTypeId { get; set; }
        public StudioItemTypeDto StudioItemType { get; set; }
    }
}
