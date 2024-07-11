using AcmeStudios.Models.Domain.StudioItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AcmeStudios.Models.Domain.StudioItemTypes
{
    public class StudioItemType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudioItemTypeId { get; set; }
        [Required]
        public string Value { get; set; }
        [JsonIgnore]
        public ICollection<StudioItem> StudioItem { get; set; }
    }
}
