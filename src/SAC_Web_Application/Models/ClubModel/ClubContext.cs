using Microsoft.EntityFrameworkCore;
using SAC_Web_Application.Models.ClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAC_Web_Application.Models.ClubModel
{
    public class ClubContext : DbContext
    {
        public ClubContext(DbContextOptions<ClubContext> options)
            : base(options)
        { }

        public DbSet<Members> Members { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MemberPayment> MemberPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region MemberPayemnts link table

            modelBuilder.Entity<MemberPayment>()
                .HasKey(p => new { p.MemberID, p.PaymentID });

            modelBuilder.Entity<MemberPayment>()
            .HasOne(mp => mp.Member)
            .WithMany(m => m.MemberPayments)
            .HasForeignKey(mp => mp.MemberID);

            modelBuilder.Entity<MemberPayment>()
                .HasOne(mp => mp.Payment)
                .WithMany(p => p.MemberPayments)
                .HasForeignKey(mp => mp.PaymentID);

            #endregion
        }

    }

}
