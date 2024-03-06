using Microsoft.EntityFrameworkCore;
using SocialNet.Core.Domain.Common;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Infrastructure.Persistence.Context
{
    public class DbContex : DbContext
    {
        public DbContex(DbContextOptions<DbContex> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Comments> Comments { get; set; }

        //SaveChangesAsync Extension method
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreateBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent Api

            #region Tables
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Friends>().ToTable("Friends");
            modelBuilder.Entity<Comments>().ToTable("Comments");
            #endregion

            #region Primary key
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<Post>().HasKey(e => e.Id);
            modelBuilder.Entity<Friends>().HasKey(e => e.Id);
            modelBuilder.Entity<Comments>().HasKey(e => e.Id);
            modelBuilder.Entity<Friends>().HasKey(e => e.Id);
            #endregion

            #region Relations
            //User relations
            modelBuilder.Entity<User>()
                .HasMany<Post>(e => e.Posts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany<Comments>(e => e.Comments)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany<Friends>(e => e.FriendshipsAsUser1)
                .WithOne(e => e.User1)
                .HasForeignKey(e => e.IdFriend1)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
               .HasMany<Friends>(e => e.FriendshipsAsUser2)
               .WithOne(e => e.User2)
               .HasForeignKey(e => e.IdFriend2)
               .OnDelete(DeleteBehavior.Restrict);

            //Post relations
            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.Post)
                .HasForeignKey(e => e.IdPost)
                .OnDelete(DeleteBehavior.Cascade);
            //Comment relations

            modelBuilder.Entity<Comments>()
                .HasMany(e => e.ChildComments)
                .WithOne(e => e.ParentComment)
                .HasForeignKey(e => e.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Property Configurations

            #region Users
            modelBuilder.Entity<User>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.Phone).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.Email).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.Imagen).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.Password).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.Status).IsRequired();
            #endregion

            #region Post
            modelBuilder.Entity<Post>().Property(e => e.Caption).IsRequired();
            modelBuilder.Entity<Post>().Property(e => e.ImgPost).IsRequired(false);
            modelBuilder.Entity<Post>().Property(e => e.Date)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>()
                .IsRequired();
            modelBuilder.Entity<Post>().Property(e => e.Hour)
                .HasConversion<TimeOnlyConverter, TimeOnlyComparer>()
                .IsRequired();
            modelBuilder.Entity<Post>().Property(e => e.IdUser).IsRequired();

            #endregion

            #region Friends
            modelBuilder.Entity<Friends>().Property(e => e.IdFriend1).IsRequired();
            modelBuilder.Entity<Friends>().Property(e => e.IdFriend2).IsRequired();

            #endregion

            #region Comment
            modelBuilder.Entity<Comments>().Property(e => e.Comment).IsRequired();
            modelBuilder.Entity<Comments>().Property(e => e.Date)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>()
                .IsRequired();
            modelBuilder.Entity<Comments>().Property(e => e.Hour)
                .HasConversion<TimeOnlyConverter, TimeOnlyComparer>()
                .IsRequired();
            modelBuilder.Entity<Comments>().Property(e => e.ParentCommentId).IsRequired(false);
            modelBuilder.Entity<Comments>().Property(e => e.IdPost).IsRequired();
            modelBuilder.Entity<Comments>().Property(e => e.IdUser).IsRequired();

            #endregion
            #endregion
        }
    }
}
