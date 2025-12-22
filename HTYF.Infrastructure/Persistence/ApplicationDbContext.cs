using HTYF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTYF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HTYF.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<EventBooking> EventBookings => Set<EventBooking>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Location)
                      .IsRequired()
                      .HasMaxLength(200);
            });

            builder.Entity<EventBooking>(entity =>
            {
                entity.Property(b => b.BookerName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(b => b.BookerEmail)
                      .IsRequired()
                      .HasMaxLength(200);
            });
        }
    }
}
