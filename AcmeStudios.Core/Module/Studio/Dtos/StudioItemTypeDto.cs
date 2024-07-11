using AcmeStudios.Models.Domain.StudioItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AcmeStudios.Core.Module.Studio.Dtos
{
    public class StudioItemTypeDto
    {
        public int StudioItemTypeId { get; set; }
        public string Value { get; set; }
        public List<StudioItem> StudioItem { get; set; }
    }
}
