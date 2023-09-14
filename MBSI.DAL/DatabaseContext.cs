using MBSI.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MBSI.DAL
{
    public partial class DatabaseContext : DbContext
    {
        #region Constructors
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        #endregion

        #region DbSets
        public virtual DbSet<UserInfoModel>? UserInfos { get; set; }
        #endregion

        #region Response DbSets
        #endregion

        #region Mapping Functions
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //For UserInfo
            modelBuilder.Entity<UserInfoModel>(entity =>
            {
                entity.ToTable("UserInfos");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}
