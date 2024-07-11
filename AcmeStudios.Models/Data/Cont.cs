using AcmeStudios.Models.Domain.StudioItems;
using AcmeStudios.Models.Domain.StudioItemTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeStudios.Models.Data
{
    public class Cont : DbContext
    {
        public DbSet<StudioItem> StudioItems { get; set; }
        public DbSet<StudioItemType> StudioItemTypes { get; set; }
        public Cont(DbContextOptions<Cont> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudioItem>()
            .HasOne(s => s.StudioItemType)
            .WithMany(ad => ad.StudioItem)
            .HasForeignKey(ad => ad.StudioItemTypeId);

            modelBuilder.Entity<StudioItemType>().HasData(
            new StudioItemType { StudioItemTypeId = 1, Value = "Synthesiser" },
            new StudioItemType { StudioItemTypeId = 2, Value = "Drum Machine" },
            new StudioItemType { StudioItemTypeId = 3, Value = "Effect" },
            new StudioItemType { StudioItemTypeId = 4, Value = "Sequencer" },
            new StudioItemType { StudioItemTypeId = 5, Value = "Mixer" },
            new StudioItemType { StudioItemTypeId = 6, Value = "Oscillator" },
            new StudioItemType { StudioItemTypeId = 7, Value = "Utility" }
            );
        }
    }
}
