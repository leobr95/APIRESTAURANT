// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

namespace WebAPIMD.Migrations
{
    [DbContext(typeof(FacturaContext))]
    [Migration("20220520035148_FirtsMigrationRestaurante")]
    partial class FirtsMigrationRestaurante
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.Cliente", b =>
                {
                    b.Property<int>("ClientelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Identificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ClientelId");

                    b.ToTable("ClienteItems");
                });

            modelBuilder.Entity("WebAPI.Models.DetalleFactura", b =>
                {
                    b.Property<int>("DetalleFacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Plato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("DetalleFacturaId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("DetalleFacturaItems");
                });

            modelBuilder.Entity("WebAPI.Models.Factura", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("DetalleFacturaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<int>("MeseroId")
                        .HasColumnType("int");

                    b.HasKey("FacturaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DetalleFacturaId");

                    b.HasIndex("MesaId");

                    b.HasIndex("MeseroId");

                    b.ToTable("FacturaItems");
                });

            modelBuilder.Entity("WebAPI.Models.Mesa", b =>
                {
                    b.Property<int>("MesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puestos")
                        .HasColumnType("int");

                    b.Property<bool>("Reservada")
                        .HasColumnType("bit");

                    b.HasKey("MesaId");

                    b.ToTable("MesaItems");
                });

            modelBuilder.Entity("WebAPI.Models.Mesero", b =>
                {
                    b.Property<int>("MeseroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Antiguedad")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeseroId");

                    b.ToTable("MeseroItems");
                });

            modelBuilder.Entity("WebAPI.Models.Supervisor", b =>
                {
                    b.Property<int>("SupervisorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Antiguedad")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupervisorId");

                    b.ToTable("SupervisorItems");
                });

            modelBuilder.Entity("WebAPI.Models.DetalleFactura", b =>
                {
                    b.HasOne("WebAPI.Models.Supervisor", "Supervisor")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("WebAPI.Models.Factura", b =>
                {
                    b.HasOne("WebAPI.Models.Cliente", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.DetalleFactura", "DetalleFactura")
                        .WithMany("Facturas")
                        .HasForeignKey("DetalleFacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Mesa", "Mesa")
                        .WithMany("Facturas")
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Mesero", "Mesero")
                        .WithMany("Facturas")
                        .HasForeignKey("MeseroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("DetalleFactura");

                    b.Navigation("Mesa");

                    b.Navigation("Mesero");
                });

            modelBuilder.Entity("WebAPI.Models.Cliente", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("WebAPI.Models.DetalleFactura", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("WebAPI.Models.Mesa", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("WebAPI.Models.Mesero", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("WebAPI.Models.Supervisor", b =>
                {
                    b.Navigation("DetalleFacturas");
                });
#pragma warning restore 612, 618
        }
    }
}
