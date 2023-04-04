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
        public HRsystemContext (DbContextOptions<HRsystemContext> options)
            : base(options)
        {
        }

        public DbSet<HRsystem.Models.PersonBasicInfo> PersonBasicInfo { get; set; } = default!;

        public DbSet<HRsystem.Models.SalaryInfo>? SalaryInfo { get; set; }
        public DbSet<HRsystem.Models.AccountInfo>? AccountInfo { get; set; }
        /**/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonBasicInfo>()
                .Property(b => b.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<SalaryInfo>()
                .Property(b => b.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<AccountInfo>()
                .Property(b => b.AccountInfoId)
                .ValueGeneratedNever();
        }
    }
}
