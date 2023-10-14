﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Migrations
{
    [DbContext(typeof(ContextoTipoCambio))]
    partial class ContextoTipoCambioModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Modelo.TipoCambio", b =>
                {
                    b.Property<int>("TipoCambioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("MontoTipoCambio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("TipoCambioId");

                    b.ToTable("TipoCambio");
                });
#pragma warning restore 612, 618
        }
    }
}
