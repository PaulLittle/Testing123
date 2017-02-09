﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SAC_Web_Application.Models.ClubModel;

namespace SAC_Web_Application.Data.ClubMigrations
{
    [DbContext(typeof(ClubContext))]
    [Migration("20170209155230_IdentifierField")]
    partial class IdentifierField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.Coaches", b =>
                {
                    b.Property<int>("CoachID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactNumber");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("GardaVetExpDate");

                    b.Property<string>("LastName");

                    b.HasKey("CoachID");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.CoachQualification", b =>
                {
                    b.Property<int>("CoachID");

                    b.Property<int>("QualID");

                    b.HasKey("CoachID", "QualID");

                    b.HasIndex("CoachID");

                    b.HasIndex("QualID");

                    b.ToTable("CoachQualifications");
                });

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.Committee", b =>
                {
                    b.Property<int>("CommitteeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("Image");

                    b.Property<string>("LastName");

                    b.Property<string>("Position");

                    b.HasKey("CommitteeID");

                    b.ToTable("Committees");
                });

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.MemberPayment", b =>
                {
                    b.Property<int>("MemberID");

                    b.Property<string>("PaymentID");

                    b.HasKey("MemberID", "PaymentID");

                    b.HasIndex("MemberID");

                    b.HasIndex("PaymentID");

                    b.ToTable("MemberPayments");
                });

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

                    b.Property<DateTime>("DOB");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("date");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender");

                    b.Property<int>("Identifier");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("MembershipPaid");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("PostCode");

                    b.Property<string>("Province")
                        .IsRequired();

                    b.Property<string>("TeamName");

                    b.HasKey("MemberID");

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

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.Qualifications", b =>
                {
                    b.Property<int>("QualID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QualName");

                    b.HasKey("QualID");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.Subscription", b =>
                {
                    b.Property<int>("SubID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<string>("Item");

                    b.HasKey("SubID");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.Training", b =>
                {
                    b.Property<int>("TrainingID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Day");

                    b.Property<string>("MemberType");

                    b.Property<string>("Time");

                    b.Property<string>("Venue");

                    b.HasKey("TrainingID");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.CoachQualification", b =>
                {
                    b.HasOne("SAC_Web_Application.Models.ClubModel.Coaches", "coaches")
                        .WithMany("coachQualifications")
                        .HasForeignKey("CoachID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SAC_Web_Application.Models.ClubModel.Qualifications", "qualifications")
                        .WithMany("coachQualifications")
                        .HasForeignKey("QualID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SAC_Web_Application.Models.ClubModel.MemberPayment", b =>
                {
                    b.HasOne("SAC_Web_Application.Models.ClubModel.Members", "Member")
                        .WithMany("MemberPayments")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SAC_Web_Application.Models.ClubModel.Payment", "Payment")
                        .WithMany("MemberPayments")
                        .HasForeignKey("PaymentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
