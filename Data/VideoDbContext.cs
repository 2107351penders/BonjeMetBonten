using System;
using Microsoft.EntityFrameworkCore;
using BonjeMetBonten.Models;

namespace BonjeMetBonten.Data
{
    public class VideoDbContext : DbContext
    {
        public VideoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Video> Videos { get; set; } = default!;
        public DbSet<Onderwerp> Onderwerpen { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed database met standaard data gedefinieerd in SeedVideos() en SeedOnderwerpen()
            modelBuilder.Entity<Video>().HasData(SeedVideos());
            modelBuilder.Entity<Onderwerp>().HasData(SeedOnderwerpen());
            modelBuilder.Entity<Koppel>().HasData(SeedKoppels());
        }

        // Return lijst van de standaard Videos in de database t.b.v. database seed
        private List<Video> SeedVideos()
        {
            List<Video> Videos = new List<Video>();

            List<Onderwerp> Onderwerpen = SeedOnderwerpen();

            Videos.Add(new Video {
                Id = -1,
                Titel = "Spinning Back Fist",
                Link = "https://www.youtube.com/embed/gNd5c2C8Doc"
            });
            Videos.Add(new Video {
                Id = -2,
                Titel = "Shooting",
                Link = "https://www.youtube.com/embed/NMGFwBM7Uo4"
            });
            Videos.Add(new Video {
                Id = -3,
                Titel = "Side Kick 4.3",
                Link = "https://www.youtube.com/embed/Mgb8wujuit0"
            });
            Videos.Add(new Video {
                Id = -4,
                Titel = "Slipping and Evading 3.6",
                Link = "https://www.youtube.com/embed/Nz7mAvVysrI"
            });
            Videos.Add(new Video {
                Id = -5,
                Titel = "The Hook 3.2",
                Link = "https://www.youtube.com/embed/ocqFWvSVOLc"
            });
            Videos.Add(new Video {
                Id = -6,
                Titel = "The Jab 3.1",
                Link = "https://www.youtube.com/embed/uVsfBos88CI"
            });
            Videos.Add(new Video {
                Id = -7,
                Titel = "The Uppercut 3.3",
                Link = "https://www.youtube.com/embed/QoL2fQDCPas"
            });
            Videos.Add(new Video {
                Id = -8,
                Titel = "Deadly Combinations 3.4",
                Link = "https://www.youtube.com/embed/1Wzi6j1REWI"
            });
            Videos.Add(new Video {
                Id = -9,
                Titel = "Uithoudingsvermogen(NL) 1.4",
                Link = "https://www.youtube.com/embed/lDMZximoLmk"
            });
            Videos.Add(new Video {
                Id = -10,
                Titel = "Small series of different exercises for combat stamina",
                Link = "https://www.youtube.com/embed/G5mJKBT4HH4"
            });
            Videos.Add(new Video {
                Id = -11,
                Titel = "Voetenwerk (NL) 1.3",
                Link = "https://www.youtube.com/embed/vr4Mwf0Ymm8"
            });
            Videos.Add(new Video {
                Id = -12,
                Titel = "Flying Front Kick 4.8",
                Link = "https://www.youtube.com/embed/iygxaot9Vms"
            });
            Videos.Add(new Video {
                Id = -13,
                Titel = "Roundhouse kick 4.2",
                Link = "https://www.youtube.com/embed/cRX5-wS4M8s"
            });
            Videos.Add(new Video {
                Id = -14,
                Titel = "Vicious Combinations 4.6",
                Link = "https://www.youtube.com/embed/aRGVRt-i9ww"
            });
            Videos.Add(new Video {
                Id = -15,
                Titel = "Jo Bonten - Wat te doen bij een terroristische aanslag",
                Link = "https://www.youtube.com/embed/Sa3_tBJXSSg"
            });
            Videos.Add(new Video {
                Id = -16,
                Titel = "Zo SCHUIL je voor KOGELS | Man Bijt Hond | KIJK",
                Link = "https://www.youtube.com/embed/SJ6gUtVuMWE"
            });
            Videos.Add(new Video {
                Id = -17,
                Titel = "Headbutt",
                Link = "https://www.youtube.com/embed/EvJSNf75Ouw"
            });

            return Videos;
        }

        // Return lijst van de standaard Onderwerpen in de database t.b.v. database seed
        private List<Onderwerp> SeedOnderwerpen()
        {
            List<Onderwerp> Onderwerpen = new List<Onderwerp>();

            Onderwerpen.Add(new Onderwerp { Id = -1, Omschrijving = "Stamina" });
            Onderwerpen.Add(new Onderwerp { Id = -2, Omschrijving = "Side Kick" });
            Onderwerpen.Add(new Onderwerp { Id = -3, Omschrijving = "Ontwijking van gevaar" });
            Onderwerpen.Add(new Onderwerp { Id = -4, Omschrijving = "Back Fist" });
            Onderwerpen.Add(new Onderwerp { Id = -5, Omschrijving = "Back Kick" });
            Onderwerpen.Add(new Onderwerp { Id = -6, Omschrijving = "Front Kick" });
            Onderwerpen.Add(new Onderwerp { Id = -7, Omschrijving = "RoundHouse Kick" });
            Onderwerpen.Add(new Onderwerp { Id = -8, Omschrijving = "Uppercut" });
            Onderwerpen.Add(new Onderwerp { Id = -9, Omschrijving = "The Jab" });
            Onderwerpen.Add(new Onderwerp { Id = -10, Omschrijving = "The Hook" });

            return Onderwerpen;
        }

        private List<Koppel> SeedKoppels()
        {
            List<Koppel> Koppels = new List<Koppel>();

            Koppels.Add(new Koppel { Id = -1, VideoId = -1, OnderwerpId = -4 });
            Koppels.Add(new Koppel { Id = -2, VideoId = -2, OnderwerpId = -3 });
            Koppels.Add(new Koppel { Id = -3, VideoId = -3, OnderwerpId = -2 });
            Koppels.Add(new Koppel { Id = -4, VideoId = -3, OnderwerpId = -7 });
            Koppels.Add(new Koppel { Id = -5, VideoId = -4, OnderwerpId = -3 });
            Koppels.Add(new Koppel { Id = -6, VideoId = -5, OnderwerpId = -10 });
            Koppels.Add(new Koppel { Id = -7, VideoId = -6, OnderwerpId = -8 });
            Koppels.Add(new Koppel { Id = -8, VideoId = -6, OnderwerpId = -9 });
            Koppels.Add(new Koppel { Id = -9, VideoId = -7, OnderwerpId = -8 });
            Koppels.Add(new Koppel { Id = -10, VideoId = -8, OnderwerpId = -8 });
            Koppels.Add(new Koppel { Id = -11, VideoId = -8, OnderwerpId = -9 });
            Koppels.Add(new Koppel { Id = -12, VideoId = -8, OnderwerpId = -10 });
            Koppels.Add(new Koppel { Id = -13, VideoId = -9, OnderwerpId = -1 });
            Koppels.Add(new Koppel { Id = -14, VideoId = -10, OnderwerpId = -1 });
            Koppels.Add(new Koppel { Id = -15, VideoId = -11, OnderwerpId = -3 });
            Koppels.Add(new Koppel { Id = -16, VideoId = -11, OnderwerpId = -6 });
            Koppels.Add(new Koppel { Id = -17, VideoId = -12, OnderwerpId = -6 });
            Koppels.Add(new Koppel { Id = -18, VideoId = -13, OnderwerpId = -7 });
            Koppels.Add(new Koppel { Id = -19, VideoId = -14, OnderwerpId = -2 });
            Koppels.Add(new Koppel { Id = -20, VideoId = -14, OnderwerpId = -5 });
            Koppels.Add(new Koppel { Id = -21, VideoId = -14, OnderwerpId = -6 });
            Koppels.Add(new Koppel { Id = -22, VideoId = -14, OnderwerpId = -7 });
            Koppels.Add(new Koppel { Id = -23, VideoId = -15, OnderwerpId = -3 });
            Koppels.Add(new Koppel { Id = -24, VideoId = -16, OnderwerpId = -3 });
            Koppels.Add(new Koppel { Id = -25, VideoId = -17, OnderwerpId = -3 });

            return Koppels;
        }
    }
}
