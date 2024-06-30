using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TtcApi.Models;

namespace TtcApi.Data
{
    public class TTCContext : IdentityDbContext<IdentityUser>
    {
        public TTCContext(DbContextOptions<TTCContext> options) : base(options)
        {
        }

        public DbSet<Ship> Ships { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Lading> Ladings { get; set; }
        public DbSet<VeiligheidsChecklist> VeiligheidsChecklists { get; set; }
        public DbSet<StatusLading> StatusLadings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ship>()
                .HasKey(s => s.ShipName);

            modelBuilder.Entity<Terminal>()
                .HasKey(t => t.TerminalName);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductName);

            modelBuilder.Entity<Lading>()
                .HasOne(l => l.Ship)
                .WithMany(s => s.Ladings)
                .HasForeignKey(l => l.ShipName)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Lading>()
                .HasOne(l => l.Terminal)
                .WithMany(t => t.Ladings)
                .HasForeignKey(l => l.TerminalName)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Lading>()
                .HasOne(l => l.Product)
                .WithMany(p => p.Ladings)
                .HasForeignKey(l => l.ProductName)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VeiligheidsChecklist>()
                .HasOne(vc => vc.Lading)
                .WithMany(l => l.VeiligheidsChecklists)
                .HasForeignKey(vc => vc.LadingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StatusLading>()
                .HasKey(sl => sl.StatusLadingId);
        }
    }
}
