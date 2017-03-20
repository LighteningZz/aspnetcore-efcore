using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aspnetcore_efcore.Models.Database
{
    public partial class Db : DbContext
    {
        public virtual DbSet<MBranchs> MBranchs { get; set; }
        public virtual DbSet<MCorps> MCorps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(Startup.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MCorps>(entity =>
            {
                entity.HasKey(e => e.CorpId)
                    .HasName("PK_M_CUSTOMERs");
            });
        }
    }
}