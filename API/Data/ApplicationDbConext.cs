using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbConext : IdentityDbContext<AppUser, AppRole, string,
        IdentityUserClaim<string>, AppUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        
        public ApplicationDbConext(DbContextOptions<ApplicationDbConext> options) : base(options)
        {
        }

    //    public DbSet<Child> Children;
     public DbSet<Child> Children {get; set;}
     public DbSet<ChildPhotos> ChildPhotos {get; set;}
     public DbSet<ChildStudyReport> ChildStudyReports {get; set;}
     public DbSet<ChildMedicalReport> ChildMedicalReports {get; set;}
     public DbSet<ChildFamilyDetail> ChildFamilyDetails {get; set;}
     public DbSet<RegionsInGhana> RegionsInGhana {get; set;}
      public DbSet<Districts> Districts {get; set;}
      public DbSet<ApplicantProfile> ApplicantProfiles {get; set;}
      public DbSet<ApplicantAddress> ApplicantAddress {get; set;}
      public DbSet<ApplicationIdentification> ApplicationIdentification {get; set;}
      public DbSet<FosterApplications> FosterApplications {get; set;}
      public DbSet<ApplicantEmploymentHistory> ApplicantEmploymentHistories {get; set;}
      public DbSet<EducationalHistory> EducationalHistory {get; set;}
      public DbSet<ApplicantEducation> ApplicantEducations {get; set;}
      public DbSet<ApplicantReferences> ApplicantReferences {get; set;}
      public DbSet<ApplicantHousehold> ApplicantHouseholds { get; set;}
      public DbSet<Profession> Professions { get; set;}
      public DbSet<ReviewChild> ReviewChildren {get; set;}
      public DbSet<ChildApproval> ChildApprovals {get; set;}
      public DbSet<AssessApplication> AssessApplications {get; set;}
      public DbSet<ApplicantContact> ApplicantContacts {get; set;}
       public DbSet<ApplicantPhotos> ApplicantPhotos {get; set;}
       public DbSet<ApplicantHomeStudyReport> ApplicantHomeStudyReports {get; set;}
       public DbSet<ApplicationApproval> ApplicationApprovals {get; set;}

       protected override void OnModelCreating(ModelBuilder builder)
        {

          builder.HasSequence<int>("OrderNumbers");
          
         builder.Entity<Child>()
        .Property(c => c.SequenceNumbers)
        .HasDefaultValueSql("NEXT VALUE FOR OrderNumbers");

         builder.HasSequence<int>("OrderedNumber");

          builder.Entity<FosterApplications>()
        .Property(p => p.SequenceNumber)
        .HasDefaultValueSql("NEXT VALUE FOR OrderedNumber");
           
                builder.Entity<RegionsInGhana>()
                .HasMany(ur => ur.Districts)
                .WithOne(u => u.RegionsGhana)
                .HasForeignKey(ur => ur.RegionId)
                .IsRequired();

                  builder.Entity<RegionsInGhana>()
            .HasAlternateKey(c => c.RegionCode)
            .HasName("AlternateKey_RegionCode");

             builder.Entity<ApplicantHomeStudyReport>()
             .HasOne(b => b.FosterApplications)
            .WithOne(i => i.ApplicantHomeStudyReports)
             .HasForeignKey<ApplicantHomeStudyReport>(b => b.ApplyId);
                
            base.OnModelCreating(builder);
            
              builder.Entity<AppUserRole>().HasKey(a => new { a.UserId, a.RoleId });   
             builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

               builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        }
    }
}