using Microsoft.EntityFrameworkCore;
using MusicAPIV1.Models;
using static System.Net.WebRequestMethods;

namespace MusicAPIV1.Data
{
    public class MusicDBContext:DbContext
    {
        public MusicDBContext(DbContextOptions<MusicDBContext> options) : base(options) 
        {
        }

        public DbSet<Group> groups { get; set; }
        public DbSet<Song> songs { get; set; }
        public DbSet<Genre> genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define Relation Rules
            modelBuilder.Entity<Group>()
                .HasMany(s => s.Songs)
                .WithOne(g => g.Group)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
           //Seed Data bto DataTables
           modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1000, GroupName = "Deep Purple", Description = "Hard Rock", GroupGenreID = 101 },
                new Group { Id = 1001, GroupName = "Rainbow", Description = "Hard Rock", GroupGenreID = 101 },
                new Group { Id = 1002, GroupName = "Accept", Description = "Heavy Metal", GroupGenreID = 100 },
                new Group { Id = 1003, GroupName = "Helloween", Description = "Heavy Metal", GroupGenreID = 100 },
                new Group { Id = 1004, GroupName = "Nightwish", Description = "Heavy Metal", GroupGenreID = 103 },
                new Group { Id = 1005, GroupName = "AC/DC", Description = "Heavy Metal", GroupGenreID = 101 },
                new Group { Id = 1006, GroupName = "Metallica", Description = "Heavy Metal", GroupGenreID = 100 }
           );

            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1000,
                    GroupId = 1000,
                    SongName = "Child in Time",
                    songURL = "https://www.youtube.com/watch?v=OorZcOzNcgE" },
                new Song
                {
                    Id = 1001,
                    GroupId = 1000,
                    SongName = "Smoke on the water",
                    songURL = "https://www.youtube.com/watch?v=zUwEIt9ez7M" },
                new Song
                {
                    Id = 1002,
                    GroupId = 1000,
                    SongName = "Highway Star",
                    songURL = "https://www.youtube.com/watch?v=Wr9ie2J2690" },

                new Song
                {
                    Id = 1003,
                    GroupId = 1001,
                    SongName = "Temple of the King",
                    songURL = "https://www.youtube.com/watch?v=B7nKzCRL_oo" },
                new Song
                {
                    Id = 1004,
                    GroupId = 1001,
                    SongName = "Stargazer",
                    songURL = "https://www.youtube.com/watch?v=YmJIccPWnEk" },

                new Song
                {
                    Id = 1005,
                    GroupId = 1004,
                    SongName = "The Phantom Of The Opera",
                    songURL = "https://www.youtube.com/watch?v=tL25rbnvM4o" },
                new Song
                {
                    Id = 1006,
                    GroupId = 1004,
                    SongName = "Wish I Had An Angel",
                    songURL = "https://www.youtube.com/watch?v=wEERFBI9eCg" },

                new Song
                {
                    Id = 1007,
                    GroupId = 1002,
                    SongName = "Can't Stand the Night",
                    songURL = "https://www.youtube.com/watch?v=cnwr0xsAMTo" },
                new Song
                {
                    Id = 1008,
                    GroupId = 1002,
                    SongName = "Princess of the Dawn",
                    songURL = "https://www.youtube.com/watch?v=K8C-DP18-6g" },

               new Song
               {
                   Id = 1009,
                   GroupId = 1006,
                   SongName = "Master of Puppets",
                   songURL = "https://www.youtube.com/watch?v=E0ozmU9cJDg" },
                new Song
                {
                    Id = 1010,
                    GroupId = 1006,
                    SongName = "The Unforgiven",
                    songURL = "https://www.youtube.com/watch?v=DDGhKS6bSAE" },
                new Song
                {
                    Id = 1011,
                    GroupId = 1006,
                    SongName = "Enter Sandman",
                    songURL = "https://www.youtube.com/watch?v=CD-E-LDc384" },

                new Song
                {
                    Id = 1012,
                    GroupId = 1003,
                    SongName = "I Want Out",
                    songURL = "https://www.youtube.com/watch?v=FjV8SHjHvHk"},
                new Song
                {
                    Id = 1013,
                    GroupId = 1003,
                    SongName = "A Tale That Wasn't Right",
                    songURL = "https://www.youtube.com/watch?v=wbGjYQsx3c8" },

                new Song
                {
                    Id = 1016,
                    GroupId = 1005,
                    SongName = "T.N.T.",
                    songURL = "https://www.youtube.com/watch?v=NhsK5WExrnE" },
                new Song
                {
                    Id = 1017,
                    GroupId = 1005,
                    SongName = "Thunderstruck",
                    songURL = "https://www.youtube.com/watch?v=v2AC41dglnM" },
                new Song
                {
                    Id = 1018,
                    GroupId = 1005,
                    SongName = "Highway to Hell",
                    songURL = "https://www.youtube.com/watch?v=UCskpE9KGQU" }
                );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 100, GenreName = "Heavy metal" },
                new Genre { Id = 101, GenreName = "Hard Rock" },
                new Genre { Id = 102, GenreName = "Punk Rock" },
                new Genre { Id = 103, GenreName = "Symphonic rock" },
                new Genre { Id = 104, GenreName = "Blues-Rock" },
                new Genre { Id = 105, GenreName = "Rock & Roll" },
                new Genre { Id = 106, GenreName = "Rockabilly " }
            );



        }
    }
}