using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(x => new { x.FirstPersonId, x.SecondPersonId });

            modelBuilder.Entity<Contact>()
                .HasOne(x => x.FirstPerson)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.FirstPersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>()
                .HasOne(x => x.SecondPerson)
                .WithMany()
                .HasForeignKey(x => x.SecondPersonId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EnterpriseOffice>().HasKey(x => new { x.EnterpriseId, x.OfficeId });
            
            modelBuilder.Entity<PersonEnterprise>().HasKey(x => new { x.PersonId, x.EnterpriseId });
            
            modelBuilder.Entity<Person>().HasOne(x => x.Address).WithMany().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasIndex(x => x.Mail).IsUnique();
            
            modelBuilder.Entity<EmploymentStatus>().HasIndex(x => x.StatusName).IsUnique();
            
            modelBuilder.Entity<EmploymentStatus>().HasData(
                new EmploymentStatus() { Id = Guid.Parse("B070B9BD-FBF2-486C-8C2C-0042BDC959B5"), StatusName = "Indépendant" },
                new EmploymentStatus() { Id = Guid.Parse("C2F1B8D0-C661-4D6F-8BF4-07DA4A9719EA"), StatusName = "Employé" }
                );
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<EmploymentStatus> EmploymentStatus { get; set; }
        public DbSet<Enterprise> Enterprise { get; set; }
        public DbSet<EnterpriseOffice> EnterpriseOffice { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonEnterprise> PersonEnterprises { get; set; }
        public DbSet<User> User { get; set; }
    }
}
