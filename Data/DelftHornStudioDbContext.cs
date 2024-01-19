using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DelftHornStudio.Models;
using Microsoft.AspNetCore.Identity;

namespace DelftHornStudio.Data;
public class DelftHornStudioDbContext : IdentityDbContext<IdentityUser>
{
  private readonly IConfiguration _configuration;
  public DbSet<UserProfile> UserProfiles { get; set; }
  public DbSet<Lesson> Lessons { get; set; }
  public DbSet<LessonRepertoire> LessonRepertoires { get; set; }
  public DbSet<Repertoire> Repertoires { get; set; }
  public DbSet<Student> Students { get; set; }

  public DelftHornStudioDbContext(DbContextOptions<DelftHornStudioDbContext> context, IConfiguration config) : base(context)
  {
    _configuration = config;
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[]
    {
          new IdentityRole {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
          },
          new IdentityRole {
               Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b36",
            Name = "Student",
            NormalizedName = "student"
          }
    });

    modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
    {
      new IdentityUser {
      Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
      UserName = "Administrator",
      Email = "admina@strator.comx",
      PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
      },
      new IdentityUser {
        Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a6f",
        UserName = "abbycooper",
        Email = "abby@cooper.comx",
        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["TestPassword"])
      },
      new IdentityUser {
        Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a7f",
        UserName = "brandondrake",
        Email = "brandon@drake.comx",
        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["TestPassword"])
      },
      new IdentityUser {
        Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a8f",
        UserName = "timepps",
        Email = "tim@epps.comx",
        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["TestPassword"])
      }
    });

    modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
    {
      RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
      UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
    });

    modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
    {
      new UserProfile {
        Id = 1,
        IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
        FirstName = "Delft",
        LastName = "Admin",
        Address = "101 Main Street",
      },
      new UserProfile {
        Id = 2,
        IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a6f",
        FirstName = "Abby",
        LastName = "Cooper",
        Address = "4511 Fair Way",
      },
      new UserProfile {
        Id = 3,
        IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a7f",
        FirstName = "Brandon",
        LastName = "Drake",
        Address = "653 Turning Point",
      },
      new UserProfile {
        Id = 4,
        IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a8f",
        FirstName = "Tim",
        LastName = "Epps",
        Address = "1034 Reprise Circle",
      }
    });

    modelBuilder.Entity<Repertoire>().HasData(new Repertoire[]
    {
          new Repertoire {Id = 1, Title = "Rubank Elementary Method: French Horn", Author = "J. E. Skornicka", Image = "https://halleonard-coverimages.s3.amazonaws.com/wl/04470070-wl.jpg"},
          new Repertoire {Id = 2, Title = "Concertos for Horn", Author = "Mozart", Image = "https://m.media-amazon.com/images/I/51diWNOVxPL._AC_UF1000,1000_QL80_.jpg"},
          new Repertoire {Id = 3, Title = "Sixty Selected Studies for French Horn", Author = "Carl Kopprasch", Image = "https://www.ficksmusic.com/cdn/shop/files/O2791_1200x.jpg?v=1699226606"},
          new Repertoire {Id = 4, Title = "Maxime-Alphonse: 200 New Etudes - Volume 1", Author = "Jean Marie Maximin, François Alphonse", Image = "https://www.ficksmusic.com/cdn/shop/products/AL16857_vqkwpo_4f9a0c1d-dbd5-492d-bfbb-d800627a8ea9_1200x.jpg?v=1650813744"},
          new Repertoire {Id = 5, Title = "Pares Scales for French Horn", Author = "Gabriel Parès", Image = "https://www.ficksmusic.com/cdn/shop/products/04470550-wl_1200x.jpg?v=1677095340"},
          new Repertoire {Id = 6, Title = "Solos for the Horn Player", Author = "Mason Jones", Image = "https://www.ficksmusic.com/cdn/shop/files/50490438FCz_1200x.jpg?v=1682432322"},
          new Repertoire {Id = 7, Title = "The Art of French Horn Playing", Author = "Philip Farkas", Image = "https://static.alfred.com/cache/6d/ad/6dad2e08f20b03fd3f6cb03e713b8b24.jpg"},
          new Repertoire {Id = 8, Title = "335 Selected Melodious Progressive and Technical Studies for French Horn", Author = "Max P. Pottag", Image = "https://m.media-amazon.com/images/I/51Xoe86pAHL._AC_UF1000,1000_QL80_.jpg"}
    });

    modelBuilder.Entity<Student>().HasData(new Student[]
    {
      new Student {
        Id = 1, 
        UserProfileId = 2, 
        Grade = 7, 
        Phone = "615-888-8888", 
        ParentName = "Frank Cooper", 
        ParentEmail = "fCooper@gmail.comx", 
        ParentAddress = "4511 Fair Way",
        ParentPhone = "615-888-8888",
        isActive = true, 
      },
      new Student {
        Id = 2, 
        UserProfileId = 3, 
        Grade = 7, 
        Phone = "615-777-7777", 
        ParentName = "Thad Brooks", 
        ParentEmail = "tBrooks@gmail.comx", 
        ParentAddress = "4437 Presto Terrace",
        ParentPhone = "615-797-7979",
        isActive = true, 
      },
      new Student {
        Id = 3, 
        UserProfileId = 4, 
        Grade = 8, 
        Phone = "615-555-5555", 
        ParentName = "Letitia Epps", 
        ParentEmail = "lEpps@gmail.comx", 
        ParentAddress = "1034 Reprise Circle",
        ParentPhone = "615-555-5555",
        isActive = false, 
      }
    });

    modelBuilder.Entity<Lesson>().HasData(new Lesson[]
    {
      new Lesson {Id = 1, StudentId = 1, DateScheduled = new DateTime(2024, 1, 16, 10, 0, 0), isCompleted = true, isPaid = false, Price = 20.00M},
      new Lesson {Id = 2, StudentId = 1, DateScheduled = new DateTime(2024, 1, 23, 10, 0, 0), isCompleted = false, isPaid = false, Price = 20.00M},
      new Lesson {Id = 3, StudentId = 1, DateScheduled = new DateTime(2024, 2, 13, 10, 0, 0), isCompleted = false, isPaid = false, Price = 20.00M},
      new Lesson {Id = 4, StudentId = 2, DateScheduled = new DateTime(2024, 1, 16, 11, 0, 0), isCompleted = true, isPaid = true, Price = 20.00M},
      new Lesson {Id = 5, StudentId = 2, DateScheduled = new DateTime(2024, 1, 23, 11, 0, 0), isCompleted = false, isPaid = false, Price = 20.00M},
      new Lesson {Id = 6, StudentId = 3, DateScheduled = new DateTime(2024, 1, 17, 13, 0, 0), isCompleted = true, isPaid = false, Price = 40.00M},
      new Lesson {Id = 7, StudentId = 3, DateScheduled = new DateTime(2024, 2, 14, 13, 0, 0), isCompleted = false, isPaid = false, Price = 40.00M}
    });

    modelBuilder.Entity<LessonRepertoire>().HasData(new LessonRepertoire[]
    {
      new LessonRepertoire {Id = 1, LessonId = 1, RepertoireId = 1},
      new LessonRepertoire {Id = 2, LessonId = 1, RepertoireId = 5},
      new LessonRepertoire {Id = 3, LessonId = 2, RepertoireId = 1},
      new LessonRepertoire {Id = 4, LessonId = 2, RepertoireId = 7},
      new LessonRepertoire {Id = 5, LessonId = 4, RepertoireId = 5},
      new LessonRepertoire {Id = 6, LessonId = 4, RepertoireId = 8},
      new LessonRepertoire {Id = 7, LessonId = 4, RepertoireId = 2},
      new LessonRepertoire {Id = 8, LessonId = 5, RepertoireId = 4},
      new LessonRepertoire {Id = 9, LessonId = 5, RepertoireId = 6},
      new LessonRepertoire {Id = 10, LessonId = 6, RepertoireId = 1},
      new LessonRepertoire {Id = 11, LessonId = 6, RepertoireId = 3},
    });
  }
}
    
    
    
    
    // _userManager.CreateAsync(<user>,<password>);