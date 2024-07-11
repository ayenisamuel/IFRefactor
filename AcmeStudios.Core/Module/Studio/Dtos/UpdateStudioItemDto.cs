﻿using System.ComponentModel.DataAnnotations;

namespace AcmeStudios.Core.Module.Studio.Dtos
{
    public class UpdateStudioItemDto
    {
        public int StudioItemId { get; set; }
        public DateTime Acquired { get; set; } = new DateTime(2020, 08, 04);
        public DateTime? Sold { get; set; } = null;
        [Required]
        public string Name { get; set; } = "DSI Mopho x4";
        [Required]
        public string Description { get; set; } = "Dave Smith Instruments analog poly";
        [Required]
        public string SerialNumber { get; set; } = "123456";
        public decimal Price { get; set; } = 10.00M;
        public decimal SoldFor { get; set; } = 0M;
        public bool Eurorack { get; set; } = false;

        public StudioItemTypeDto StudioItemType { get; set; }

        //public StudioItemImage StudioItemImage { get; set; }
    }
}
