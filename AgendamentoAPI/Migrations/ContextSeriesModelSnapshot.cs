﻿// <auto-generated />
using System;
using AgendamentoAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendamentoAPI.Migrations
{
    [DbContext(typeof(ContextSeries))]
    partial class ContextSeriesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AgendamentoAPI.Models.Agendamento", b =>
                {
                    b.Property<int>("agendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("agendamentoId"), 1L, 1);

                    b.Property<DateTime>("agendamentoDia")
                        .HasColumnType("datetime2");

                    b.Property<string>("agendamentoEscialidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("agendamentoMedico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pacienteId")
                        .HasColumnType("int");

                    b.HasKey("agendamentoId");

                    b.HasIndex("pacienteId");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("AgendamentoAPI.Models.ConfirmarAgendamento", b =>
                {
                    b.Property<int>("confirmarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("confirmarId"), 1L, 1);

                    b.Property<int>("agendamentoId")
                        .HasColumnType("int");

                    b.Property<bool>("confirmarAgendamento")
                        .HasColumnType("bit");

                    b.HasKey("confirmarId");

                    b.HasIndex("agendamentoId");

                    b.ToTable("confirmarAgendamentos");
                });

            modelBuilder.Entity("AgendamentoAPI.Models.Paciente", b =>
                {
                    b.Property<int>("pacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pacienteId"), 1L, 1);

                    b.Property<int>("agendamentoId")
                        .HasColumnType("int");

                    b.Property<int>("pacienteCPF")
                        .HasMaxLength(15)
                        .HasColumnType("int");

                    b.Property<DateTime>("pacienteNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("pacienteNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pacienteId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("AgendamentoAPI.Models.Agendamento", b =>
                {
                    b.HasOne("AgendamentoAPI.Models.Paciente", "Paciente")
                        .WithMany("Agendamento")
                        .HasForeignKey("pacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("AgendamentoAPI.Models.ConfirmarAgendamento", b =>
                {
                    b.HasOne("AgendamentoAPI.Models.Agendamento", "Agendamento")
                        .WithMany("ConfirmarAgendamento")
                        .HasForeignKey("agendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agendamento");
                });

            modelBuilder.Entity("AgendamentoAPI.Models.Agendamento", b =>
                {
                    b.Navigation("ConfirmarAgendamento");
                });

            modelBuilder.Entity("AgendamentoAPI.Models.Paciente", b =>
                {
                    b.Navigation("Agendamento");
                });
#pragma warning restore 612, 618
        }
    }
}
