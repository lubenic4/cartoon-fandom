using fandom.WebAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public partial class AppCtx
    {


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            List<string> Salt = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Salt.Add(HashHelper.GenerateSalt());
            }

            modelBuilder.Entity<User>()
                .HasData
                (
                    new User
                    {
                        Id = 1,
                        Username = "desktop",
                        Email = "desktop@gmail.com",
                        PasswordSalt = Salt[0],
                        PasswordHash = HashHelper.GenerateHash(Salt[0], "test")

                    },
                     new User
                     {
                         Id = 2,
                         Username = "mobile",
                         Email = "mobile@gmail.com",
                         PasswordSalt = Salt[1],
                         PasswordHash = HashHelper.GenerateHash(Salt[1], "test")

                     },
                      new User
                      {
                          Id = 3,
                          Username = "mobile1",
                          Email = "desktop@gmail.com",
                          PasswordSalt = Salt[2],
                          PasswordHash = HashHelper.GenerateHash(Salt[2], "test")

                      },
                       new User
                       {
                           Id = 4,
                           Username = "mobile2",
                           Email = "desktop@gmail.com",
                           PasswordSalt = Salt[3],
                           PasswordHash = HashHelper.GenerateHash(Salt[3], "test")

                       },
                        new User
                        {
                            Id = 5,
                            Username = "mobile3",
                            Email = "desktop@gmail.com",
                            PasswordSalt = Salt[4],
                            PasswordHash = HashHelper.GenerateHash(Salt[4], "test")

                        }
                );

            modelBuilder.Entity<Role>()
                .HasData
                (
                    new Role { Id = 1, Name = "Administrator" },
                    new Role { Id = 2, Name = "User" }
                );

            modelBuilder.Entity<UserRole>()
               .HasData
               (
                   new UserRole { UserId = 1, RoleId = 1 },
                   new UserRole { UserId = 2, RoleId = 2 },
                   new UserRole { UserId = 3, RoleId = 2 },
                   new UserRole { UserId = 4, RoleId = 2 },
                   new UserRole { UserId = 5, RoleId = 2 }
               );

            modelBuilder.Entity<Category>()
                .HasData
                (
                   new Category { Id = 1, CategoryColor = "#f0312e", Title = "Announcment" },
                   new Category { Id = 2, CategoryColor = "#ff8b1f", Title = "Funny" },
                   new Category { Id = 3, CategoryColor = "#5f5cbf", Title = "News" },
                   new Category { Id = 4, CategoryColor = "#32a852", Title = "Recommendation" }
                );



            modelBuilder.Entity<Character>()
                .HasData
                (
                new Character { Id = 1, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First1", LastName = "Last1", Occupation = "Student", FamilyId = 1 },
                new Character { Id = 2, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First2", LastName = "Last1", Occupation = "Student", FamilyId = 1 },
                new Character { Id = 3, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First3", LastName = "Last1", Occupation = "Student", FamilyId = 1 },
                new Character { Id = 4, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First4", LastName = "Last1", Occupation = "Student", FamilyId = 1 },
                new Character { Id = 5, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First5", LastName = "Last1", Occupation = "Student", FamilyId = 1 },
                new Character { Id = 6, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First6", LastName = "Last2", Occupation = "Student", FamilyId = 2 },
                new Character { Id = 7, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First7", LastName = "Last2", Occupation = "Student", FamilyId = 2 },
                new Character { Id = 8, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First8", LastName = "Last2", Occupation = "Student", FamilyId = 2 },
                new Character { Id = 9, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First9", LastName = "Last3", Occupation = "Student", FamilyId = 3 },
                new Character { Id = 10, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First10", LastName = "Last3", Occupation = "Student", FamilyId = 3 },
                new Character { Id = 11, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First11", LastName = "Last3", Occupation = "Student", FamilyId = 3 },
                new Character { Id = 12, Biography = "Some random biography text", BirthDate = DateTime.Now.Date, FirstName = "First12", LastName = "Last3", Occupation = "Student", FamilyId = 3 }
                );
            modelBuilder.Entity<Family>()
                .HasData
                (
                    new Family { Id = 1, Name = "Last1" },
                    new Family { Id = 2, Name = "Last2" },
                    new Family { Id = 3, Name = "Last3" }
                );

            modelBuilder.Entity<Season>()
               .HasData
               (
                    new Season { Id = 1, NoOfEpisodes = 3, Summary = "Random summary text", OrdinalNumber = 1, PremiereDate = DateTime.Now.Date },
                    new Season { Id = 2, NoOfEpisodes = 2, Summary = "Random summary text", OrdinalNumber = 2, PremiereDate = DateTime.Now.Date },
                    new Season { Id = 3, NoOfEpisodes = 2, Summary = "Random summary text", OrdinalNumber = 3, PremiereDate = DateTime.Now.Date },
                    new Season { Id = 4, NoOfEpisodes = 2, Summary = "Random summary text", OrdinalNumber = 4, PremiereDate = DateTime.Now.Date }


               );

            modelBuilder.Entity<Episode>()
                .HasData
                (
                    new Episode { Id = 1, AirDate = DateTime.Now.Date, OverallNumberOfEpisode = 1, Title = "Episode title 1", Viewcount = 13, Summary = "Summary random text", SeasonEpisodeNumber = 1, SeasonId = 1 },
                    new Episode { Id = 2, AirDate = DateTime.Now.Date, OverallNumberOfEpisode = 2, Title = "Episode title 2", Viewcount = 23, Summary = "Summary random text", SeasonEpisodeNumber = 2, SeasonId = 1 },
                    new Episode { Id = 3, AirDate = DateTime.Now.Date, OverallNumberOfEpisode = 3, Title = "Episode title 3", Viewcount = 33, Summary = "Summary random text", SeasonEpisodeNumber = 3, SeasonId = 1 },
                    new Episode { Id = 4, AirDate = DateTime.Now.Date, OverallNumberOfEpisode = 4, Title = "Episode title 4", Viewcount = 43, Summary = "Summary random text", SeasonEpisodeNumber = 1, SeasonId = 2 },
                    new Episode { Id = 5, AirDate = DateTime.Now.Date, OverallNumberOfEpisode = 5, Title = "Episode title 5", Viewcount = 120, Summary = "Summary random text", SeasonEpisodeNumber = 2, SeasonId = 2 },
                    new Episode { Id = 6, AirDate = DateTime.Now.Date, OverallNumberOfEpisode = 6, Title = "Episode title 6", Viewcount = 63, Summary = "Summary random text", SeasonEpisodeNumber = 1, SeasonId = 3 },
                    new Episode { Id = 7, AirDate = DateTime.Now.Date, OverallNumberOfEpisode = 7, Title = "Episode title 7", Viewcount = 73, Summary = "Summary random text", SeasonEpisodeNumber = 2, SeasonId = 3 },
                    new Episode { Id = 8, AirDate = DateTime.Now.Date, OverallNumberOfEpisode = 8, Title = "Episode title 8", Viewcount = 83, Summary = "Summary random text", SeasonEpisodeNumber = 1, SeasonId = 4 },
                    new Episode { Id = 9, AirDate = DateTime.Now.Date, OverallNumberOfEpisode = 9, Title = "Episode title 9", Viewcount = 93, Summary = "Summary random text", SeasonEpisodeNumber = 2, SeasonId = 4 }
                );



            modelBuilder.Entity<MediaFile>()
               .HasData
               (
                    new MediaFile { MediaFileId = 1, EpisodeId = 1, Thumbnail = FileHelper.ReadFile("Assets/thumbnail1.jpg"), Path = @"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4" },
                    new MediaFile { MediaFileId = 2, EpisodeId = 2, Thumbnail = FileHelper.ReadFile("Assets/thumbnail2.jpg"), Path = @"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4" },
                    new MediaFile { MediaFileId = 3, EpisodeId = 3, Thumbnail = FileHelper.ReadFile("Assets/thumbnail3.jpg"), Path = @"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4" },
                    new MediaFile { MediaFileId = 4, EpisodeId = 4, Thumbnail = FileHelper.ReadFile("Assets/thumbnail1.jpg"), Path = @"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4" },
                    new MediaFile { MediaFileId = 5, EpisodeId = 5, Thumbnail = FileHelper.ReadFile("Assets/thumbnail2.jpg"), Path = @"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerFun.mp4" },
                    new MediaFile { MediaFileId = 6, EpisodeId = 6, Thumbnail = FileHelper.ReadFile("Assets/thumbnail3.jpg"), Path = @"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4" },
                    new MediaFile { MediaFileId = 7, EpisodeId = 7, Thumbnail = FileHelper.ReadFile("Assets/thumbnail1.jpg"), Path = @"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"},
                    new MediaFile { MediaFileId = 8, EpisodeId = 8, Thumbnail = FileHelper.ReadFile("Assets/thumbnail2.jpg"), Path = @"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4" },
                    new MediaFile { MediaFileId = 9, EpisodeId = 9, Thumbnail = FileHelper.ReadFile("Assets/thumbnail3.jpg"), Path = @"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4" },
                    new MediaFile { MediaFileId = 13, FamilyId = 1, Thumbnail = FileHelper.ReadFile("Assets/thumbnail1.jpg") },
                    new MediaFile { MediaFileId = 14, FamilyId = 2, Thumbnail = FileHelper.ReadFile("Assets/thumbnail2.jpg") },
                    new MediaFile { MediaFileId = 15, FamilyId = 3, Thumbnail = FileHelper.ReadFile("Assets/thumbnail3.jpg") }

               );

            modelBuilder.Entity<CharacterMediaFile>()
               .HasData
               (
                    new CharacterMediaFile { Id = 1, CharacterId = 1, Thumbnail = FileHelper.ReadFile("Assets/eric.png") },
                    new CharacterMediaFile { Id = 2, CharacterId = 2, Thumbnail = FileHelper.ReadFile("Assets/stan.png") },
                    new CharacterMediaFile { Id = 3, CharacterId = 3, Thumbnail = FileHelper.ReadFile("Assets/kenny.png") },
                    new CharacterMediaFile { Id = 4, CharacterId = 4, Thumbnail = FileHelper.ReadFile("Assets/kyle.png") },
                     new CharacterMediaFile { Id = 5, CharacterId = 5, Thumbnail = FileHelper.ReadFile("Assets/eric.png") },
                    new CharacterMediaFile { Id = 6, CharacterId = 6, Thumbnail = FileHelper.ReadFile("Assets/stan.png") },
                    new CharacterMediaFile { Id = 7, CharacterId = 7, Thumbnail = FileHelper.ReadFile("Assets/kenny.png") },
                     new CharacterMediaFile { Id = 8, CharacterId = 8, Thumbnail = FileHelper.ReadFile("Assets/kyle.png") },
                    new CharacterMediaFile { Id = 9, CharacterId = 9, Thumbnail = FileHelper.ReadFile("Assets/eric.png") },
                    new CharacterMediaFile { Id = 10, CharacterId = 10, Thumbnail = FileHelper.ReadFile("Assets/stan.png") },
                     new CharacterMediaFile { Id = 11, CharacterId = 11, Thumbnail = FileHelper.ReadFile("Assets/kenny.png") },
                    new CharacterMediaFile { Id = 12, CharacterId = 12, Thumbnail = FileHelper.ReadFile("Assets/kyle.png") }


               );
            modelBuilder.Entity<EpisodeCharacter>()
                .HasData
                (
                    new EpisodeCharacter { CharacterId = 1, EpisodeId = 1 },
                    new EpisodeCharacter { CharacterId = 1, EpisodeId = 2 },
                    new EpisodeCharacter { CharacterId = 1, EpisodeId = 4 },
                    new EpisodeCharacter { CharacterId = 2, EpisodeId = 1 },
                    new EpisodeCharacter { CharacterId = 2, EpisodeId = 2 },
                    new EpisodeCharacter { CharacterId = 2, EpisodeId = 4 },
                    new EpisodeCharacter { CharacterId = 4, EpisodeId = 1 },
                    new EpisodeCharacter { CharacterId = 4, EpisodeId = 8 },
                    new EpisodeCharacter { CharacterId = 5, EpisodeId = 6 },
                    new EpisodeCharacter { CharacterId = 5, EpisodeId = 5 },
                    new EpisodeCharacter { CharacterId = 5, EpisodeId = 4 },
                    new EpisodeCharacter { CharacterId = 6, EpisodeId = 3 },
                    new EpisodeCharacter { CharacterId = 7, EpisodeId = 2 },
                    new EpisodeCharacter { CharacterId = 8, EpisodeId = 6 },
                    new EpisodeCharacter { CharacterId = 9, EpisodeId = 1 },
                    new EpisodeCharacter { CharacterId = 9, EpisodeId = 9 },
                    new EpisodeCharacter { CharacterId = 10, EpisodeId = 9 },
                    new EpisodeCharacter { CharacterId = 11, EpisodeId = 9 }

                );


            modelBuilder.Entity<Tag>()
                .HasData
                (
                    new Tag { Id = 1, Title = "Tag1" },
                    new Tag { Id = 2, Title = "Tag2" },
                    new Tag { Id = 3, Title = "Tag3" },
                    new Tag { Id = 4, Title = "Tag4" }
                );

            modelBuilder.Entity<Post>()
                .HasData
                (
                    new Post { Id = 1, Title = "Random post title 1", CategoryId = 1, UserId = 4, CreationDate = DateTime.Now.Date, Summary = "Just a random text summary" },
                    new Post { Id = 2, Title = "Random post title 2", CategoryId = 1, UserId = 4, CreationDate = DateTime.Now.Date, Summary = "Just a random text summary 2" },
                    new Post { Id = 3, Title = "Random post title 3", CategoryId = 1, UserId = 1, CreationDate = DateTime.Now.Date, Summary = "Just a random text summary 3" },
                    new Post { Id = 4, Title = "Random post title 4", CategoryId = 2, UserId = 1, CreationDate = DateTime.Now.Date, Summary = "Just a random text summary 4" },
                    new Post { Id = 5, Title = "Random post title 5", CategoryId = 3, UserId = 2, CreationDate = DateTime.Now.Date, Summary = "Just a random text summary 5" },
                    new Post { Id = 6, Title = "Random post title 6", CategoryId = 3, UserId = 3, CreationDate = DateTime.Now.Date, Summary = "Just a random text summary 6" }
                );

            modelBuilder.Entity<PostTag>()
                .HasData
                (
                    new PostTag { PostId = 1, TagId = 1 },
                    new PostTag { PostId = 1, TagId = 2 },
                    new PostTag { PostId = 2, TagId = 3 },
                    new PostTag { PostId = 3, TagId = 4 },
                    new PostTag { PostId = 4, TagId = 3 },
                    new PostTag { PostId = 4, TagId = 4 },
                    new PostTag { PostId = 4, TagId = 2 },
                    new PostTag { PostId = 5, TagId = 2 },
                    new PostTag { PostId = 6, TagId = 1 },
                    new PostTag { PostId = 6, TagId = 2 }
                );

            modelBuilder.Entity<UserCharacter>()
                .HasData
                (
                    new UserCharacter { UserId = 2, CharacterId = 1 },
                    new UserCharacter { UserId = 2, CharacterId = 3 },
                    new UserCharacter { UserId = 2, CharacterId = 6 },
                    new UserCharacter { UserId = 2, CharacterId = 9 }
                );

            modelBuilder.Entity<UserEpisode>()
               .HasData
               (
                   new UserEpisode { UserId = 2, EpisodeId = 1 },
                   new UserEpisode { UserId = 2, EpisodeId = 3 },
                   new UserEpisode { UserId = 2, EpisodeId = 6 },
                   new UserEpisode { UserId = 2, EpisodeId = 9 }

               );

        }

    }
}
