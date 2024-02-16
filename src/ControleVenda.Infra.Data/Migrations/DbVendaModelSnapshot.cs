﻿// <auto-generated />
using ControleVenda.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleVenda.Infra.Data.Migrations
{
    [DbContext(typeof(DbVenda))]
    partial class DbVendaModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ControleVenda.Infra.Data.Tables.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("UK_Categoria_Nome");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("ControleVenda.Infra.Data.Tables.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("CategoriaId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<int>("Quntidade")
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("Quntidade");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(16,2)")
                        .HasColumnName("ValorUnitario");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("UK_Produto_Nome");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("ControleVenda.Infra.Data.Tables.Produto", b =>
                {
                    b.HasOne("ControleVenda.Infra.Data.Tables.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ControleVenda.Infra.Data.Tables.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
