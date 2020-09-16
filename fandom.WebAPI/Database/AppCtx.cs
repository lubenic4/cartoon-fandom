using fandom.WebAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public partial class AppCtx : DbContext
    {

        public AppCtx(DbContextOptions<AppCtx> options) : base(options) {


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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(k => new { k.UserId, k.RoleId });
            modelBuilder.Entity<UserEpisode>().HasKey(k => new { k.UserId, k.EpisodeId });
            modelBuilder.Entity<UserCharacter>().HasKey(k => new { k.UserId, k.CharacterId });
            modelBuilder.Entity<PostTag>().HasKey(k => new { k.PostId, k.TagId });

            modelBuilder.Entity<EpisodeCharacter>()
                    .HasKey(ec => new { ec.EpisodeId, ec.CharacterId });
            modelBuilder.Entity<EpisodeCharacter>()
                .HasOne(ec => ec.Episode)
                .WithMany(e => e.EpisodesCharacters)
                .HasForeignKey(ec => ec.EpisodeId);
            modelBuilder.Entity<EpisodeCharacter>()
                .HasOne(ec => ec.Character)
                .WithMany(c => c.EpisodesCharacters)
                .HasForeignKey(ec => ec.CharacterId);

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }

}
