using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SAC_Web_Application.Models.ClubModel;

namespace SAC_Web_Application.Data.ClubMigrations
{
    [DbContext(typeof(ClubContext))]
    [Migration("20161130131706_AddTeamName")]
    partial class AddTeamName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.Members", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired();

                    b.Property<string>("Address2");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("County")
                        .IsRequired();

                    b.Property<string>("CountyOfBirth")
                        .IsRequired();

                    b.Property<DateTime>("DOB")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("date");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("MembershipPaid");

                    b.Property<string>("PaymentID")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("PostCode");

                    b.Property<string>("Province")
                        .IsRequired();

                    b.Property<string>("TeamName");

                    b.HasKey("MemberID");

                    b.HasIndex("PaymentID")
                        .IsUnique();

                    b.ToTable("Member");
                });

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.Payment", b =>
                {
                    b.Property<string>("PaymentID");

                    b.Property<string>("Amount");

                    b.Property<string>("CreateTime");

                    b.Property<string>("UpdateTime");

                    b.HasKey("PaymentID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.Members", b =>
                {
                    b.HasOne("SAC_Web_Application.Models.ClubModel.Payment")
                        .WithOne("Member")
                        .HasForeignKey("SAC_Web_Application.Models.ClubModel.Members", "PaymentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
