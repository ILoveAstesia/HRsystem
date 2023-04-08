using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRsystem.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace HRsystem.Data
{
    public class HRsystemContext : DbContext
    {
        public HRsystemContext(DbContextOptions<HRsystemContext> options)
            : base(options)
        {
        }

        public DbSet<HRsystem.Models.PersonBasicInfo> PersonBasicInfo { get; set; } = default!;
        public DbSet<HRsystem.Models.SalaryInfo> SalaryInfo { get; set; } = default!;
        public DbSet<HRsystem.Models.AccountInfo> AccountInfo { get; set; } = default!;
        public DbSet<HRsystem.Models.DepartmentInfo> DepartmentInfo { get; set; } = default!;
        public DbSet<HRsystem.Models.RewardingAndPunishmentInfo> RewardingAndPunishmentInfo { get; set; } = default!;
        public DbSet<HRsystem.Models.TrainingInfo> TrainingInfo { get; set; } = default!;
        //public DbSet<Microsoft.AspNetCore.Identity.IdentityUser> IdentityUser { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*禁止自动生成自增id*/
            modelBuilder.Entity<PersonBasicInfo>()
                .Property(b => b.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<SalaryInfo>()
                .Property(b => b.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<AccountInfo>()
                .Property(b => b.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<DepartmentInfo>()
                .Property(b => b.Id)
                .ValueGeneratedNever();
            /*
             
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUser>()
                .Property(b => b.Id)
                .ValueGeneratedNever();
             */

        }
    }
}
