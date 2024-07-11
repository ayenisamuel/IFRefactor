using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeStudios.Models.Domain.StudioItemTypes;

namespace AcmeStudios.Models.Domain.StudioItems
{
    public class StudioItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudioItemId { get; set; }
        public DateTime Acquired { get; set; }
        public DateTime? Sold { get; set; } = null;
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public decimal Price { get; set; } //= 10.00M;
        public decimal? SoldFor { get; set; } //= 0M;
        public bool Eurorack { get; set; } //= false;
        [Required]
        public int StudioItemTypeId { get; set; }
        public StudioItemType StudioItemType { get; set; }
    }
}
