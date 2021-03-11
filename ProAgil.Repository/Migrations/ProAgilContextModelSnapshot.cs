﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProAgil.Repository;

namespace ProAgil.Repository.Migrations
{
    [DbContext(typeof(ProAgilContext))]
    partial class ProAgilContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("ProAgil.Domain.Evento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dataEvento");

                    b.Property<string>("email");

                    b.Property<string>("imagemUrl");

                    b.Property<string>("local");

                    b.Property<int>("qtdPessoas");

                    b.Property<string>("telefone");

                    b.Property<string>("tema");

                    b.HasKey("id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ProAgil.Domain.Lote", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Preco");

                    b.Property<DateTime?>("dataFinal");

                    b.Property<DateTime?>("dataInicial");

                    b.Property<int>("eventoId");

                    b.Property<string>("nome");

                    b.Property<int>("quantidade");

                    b.HasKey("id");

                    b.HasIndex("eventoId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("ProAgil.Domain.Palestrante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("imagemUrl");

                    b.Property<string>("miniCurriculo");

                    b.Property<string>("nome");

                    b.Property<string>("telefone");

                    b.HasKey("id");

                    b.ToTable("Palestrantes");
                });

            modelBuilder.Entity("ProAgil.Domain.PalestranteEvento", b =>
                {
                    b.Property<int>("eventoId");

                    b.Property<int>("palestranteId");

                    b.HasKey("eventoId", "palestranteId");

                    b.HasIndex("palestranteId");

                    b.ToTable("PalestranteEventos");
                });

            modelBuilder.Entity("ProAgil.Domain.RedeSocial", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("eventoId");

                    b.Property<string>("nome");

                    b.Property<int?>("palestranteId");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.HasIndex("eventoId");

                    b.HasIndex("palestranteId");

                    b.ToTable("RedeSocials");
                });

            modelBuilder.Entity("ProAgil.Domain.Lote", b =>
                {
                    b.HasOne("ProAgil.Domain.Evento", "evento")
                        .WithMany("lotes")
                        .HasForeignKey("eventoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProAgil.Domain.PalestranteEvento", b =>
                {
                    b.HasOne("ProAgil.Domain.Evento", "evento")
                        .WithMany("palestranteEvento")
                        .HasForeignKey("eventoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProAgil.Domain.Palestrante", "palestrante")
                        .WithMany("palestranteEvento")
                        .HasForeignKey("palestranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProAgil.Domain.RedeSocial", b =>
                {
                    b.HasOne("ProAgil.Domain.Evento", "evento")
                        .WithMany("redesSociais")
                        .HasForeignKey("eventoId");

                    b.HasOne("ProAgil.Domain.Palestrante", "palestrante")
                        .WithMany("redesSociais")
                        .HasForeignKey("palestranteId");
                });
#pragma warning restore 612, 618
        }
    }
}
