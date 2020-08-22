using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class AppCtx : DbContext
    {

        public AppCtx(DbContextOptions<AppCtx> options) : base(options) {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(k => new { k.UserId, k.RoleId });
            modelBuilder.Entity<UserEpisode>().HasKey(k => new { k.UserId, k.EpisodeId });
            modelBuilder.Entity<UserCharacter>().HasKey(k => new { k.UserId, k.CharacterId });
            modelBuilder.Entity<PostTag>().HasKey(k => new { k.PostId, k.TagId });
            modelBuilder.Entity<EpisodeCharacter>().HasKey(k => new { k.EpisodeId, k.CharacterId });
            modelBuilder.Entity<UserSeason>().HasKey(k => new { k.UserId, k.SeasonId });




        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<EpisodeCharacter> EpisodeCharacters { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<CharacterMediaFile> CharacterMediaFiles {get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCharacter> UserCharacters { get; set; }
        public DbSet<UserEpisode> UserEpisodes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserSeason> UserSeasons { get; set; }

    }

}
