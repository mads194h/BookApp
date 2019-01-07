﻿// <auto-generated />
using System;
using BookAPI.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookAPI.Migrations
{
    [DbContext(typeof(GiftDataContext))]
    partial class GiftDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookAPI.Models.GiftItem", b =>
                {
                    b.Property<int>("GiftNumber");

                    b.Property<bool>("BoyGift");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("GiftNumber");

                    b.ToTable("GiftItem");
                });
#pragma warning restore 612, 618
        }
    }
}