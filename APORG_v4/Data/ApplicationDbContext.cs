using APORG_v4.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APORG_v4.Model
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Object> Objects { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ObjectMerchType> ObjectMerchTypes { get; set; }
        public DbSet<MusicianMerchType> MusicianMerchTypes { get; set; }
        public DbSet<OrganizerMerchType> OrganizerMerchTypes { get; set; }
        public DbSet<ObjectSocialMedia> ObjectSocialMedias { get; set; }
        public DbSet<MusicianSocialMedia> MusicianSocialMedias { get; set; }
        public DbSet<OrganizerSocialMedia> OrganizerSocialMedias { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
