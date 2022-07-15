using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Petfy.Data.Models;

namespace Petfy.Data
{
    public class PetfyDbContext : IdentityDbContext<
        AppUser, AppRole, int, 
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IConfiguration _configuration;

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Vaccine> Vaccines { get; set; }

        //public DbSet<AppUser> Users { get; set; }

        public PetfyDbContext(DbContextOptions<PetfyDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Petfy3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("BaseProjectDatabase"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Owner>()
            //    .Property(x => x.City)
            //    .IsRequired(false);

            //modelBuilder.Entity<Owner>().HasData(
            //        new Owner { ID = 1, Name = "Default", Address = "Address 123", DateOfBirth = DateTime.Parse("2000-01-10") });

            //modelBuilder.Entity<Pet>()
            //    .Property(x => x.Name)
            //    .HasMaxLength(50);

            //modelBuilder.Entity<PetVaccine>()
            //    .HasKey(x => new { x.PetID, x.VaccineID });

            //modelBuilder.Entity<Vaccine>().HasData(
            //       new Vaccine { ID = 1, Name = "Vaccine Demo", Lab = "Lab Demo" });

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<AppUser>()
            //    .HasMany(ur => ur.UserRoles)
            //    .WithOne(u => u.User)
            //    .HasForeignKey(u => u.UserId)
            //    .IsRequired();

            //modelBuilder.Entity<AppRole>()
            //    .HasMany(ur => ur.UserRoles)
            //    .WithOne(r => r.Role)
            //    .HasForeignKey(r => r.RoleId)
            //    .IsRequired();

            //modelBuilder.Entity<AppRole>().HasData(
            //     new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMINISTRATOR" },
            //     new AppRole { Id = 2, Name = "Moderator", NormalizedName = "MODERATOR" },
            //     new AppRole { Id = 3, Name = "Owner", NormalizedName = "OWNER" }
            //    );

            //var user = new AppUser()
            //{
            //    Id = 1,
            //    UserName = "Admin",
            //    NormalizedUserName = "ADMIN",
            //    Email = "admin@admin.com",
            //    NormalizedEmail = "ADMIN@ADMIN.COM"
            //};

            //modelBuilder.Entity<AppUser>().HasData(user);

            //var passwordHasher = new PasswordHasher<AppUser>();
            //user.PasswordHash = passwordHasher.HashPassword(user, "Admin123$.");

            //var userRole = new AppUserRole() { UserId = 1, RoleId = 1 };

            //modelBuilder.Entity<AppUserRole>().HasData(userRole);
        }
    }
}