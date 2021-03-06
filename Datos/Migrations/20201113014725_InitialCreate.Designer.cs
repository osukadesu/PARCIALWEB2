﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(ParcialContext))]
    [Migration("20201113014725_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.Persona", b =>
                {
                    b.Property<string>("Cedula")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Apellido")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(25)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Sexo")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Cedula");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Entidad.Vacuna", b =>
                {
                    b.Property<string>("IdVacuna")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Cedula")
                        .HasColumnType("varchar(12)");

                    b.Property<DateTime>("FechaVacuna")
                        .HasColumnType("datetime");

                    b.Property<string>("TipoVacuna")
                        .HasColumnType("varchar(30)");

                    b.HasKey("IdVacuna");

                    b.HasIndex("Cedula");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("Entidad.Estudiante", b =>
                {
                    b.HasBaseType("Entidad.Persona");

                    b.Property<string>("Colegio")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("IdEstudiante")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("NombreAcudiente")
                        .HasColumnType("varchar(12)");

                    b.HasDiscriminator().HasValue("Estudiante");
                });

            modelBuilder.Entity("Entidad.Vacuna", b =>
                {
                    b.HasOne("Entidad.Estudiante", null)
                        .WithMany()
                        .HasForeignKey("Cedula");
                });

            modelBuilder.Entity("Entidad.Estudiante", b =>
                {
                    b.HasOne("Entidad.Persona", null)
                        .WithMany()
                        .HasForeignKey("Cedula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
