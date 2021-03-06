﻿// <auto-generated />
using EnglishVkBot.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EnglishVkBot.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190523151239_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EnglishVkBot.Domain.Models.LanguageDirection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direction");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("LanguageDirections");
                });

            modelBuilder.Entity("EnglishVkBot.Domain.Models.TranslateTextDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAutoTextRecognition");

                    b.Property<int>("TargetDirectionId");

                    b.Property<string>("Text");

                    b.Property<int>("TextDirectionId");

                    b.HasKey("Id");

                    b.HasIndex("TargetDirectionId");

                    b.HasIndex("TextDirectionId");

                    b.ToTable("TranslatedTexts");
                });

            modelBuilder.Entity("EnglishVkBot.Domain.Models.TranslateTextDto", b =>
                {
                    b.HasOne("EnglishVkBot.Domain.Models.LanguageDirection", "TargetDirection")
                        .WithMany()
                        .HasForeignKey("TargetDirectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnglishVkBot.Domain.Models.LanguageDirection", "TextDirection")
                        .WithMany()
                        .HasForeignKey("TextDirectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
