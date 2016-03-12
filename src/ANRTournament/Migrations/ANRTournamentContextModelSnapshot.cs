using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ANRTournament.Models;

namespace ANRTournament.Migrations
{
    [DbContext(typeof(ANRTournamentContext))]
    partial class ANRTournamentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ANRTournament.Models.Identity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ANRTournament.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CorpId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("MatchPoints");

                    b.Property<int?>("RunnerId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ANRTournament.Models.Player", b =>
                {
                    b.HasOne("ANRTournament.Models.Identity")
                        .WithMany()
                        .HasForeignKey("CorpId");

                    b.HasOne("ANRTournament.Models.Identity")
                        .WithMany()
                        .HasForeignKey("RunnerId");
                });
        }
    }
}
