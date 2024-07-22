using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Models;
using System.Reflection.Emit;

namespace MyWebsite.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

            var Admin = new IdentityRole("Admin");
            Admin.NormalizedName= "Admin";

            var Client = new IdentityRole("Client");
            Client.NormalizedName= "Client";

            builder.Entity<IdentityRole>().HasData(Admin,Client);
        }

        #region DbSet
        public DbSet<DanhMuc> DanhMucs { get; set; }

        public DbSet<SanPham> SanPhams { get; set; }

        public DbSet<GioHang> GioHangs { get; set; }

        public DbSet<DonHang> DonHangs { get; set; }

        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }

        public DbSet<DanhGia> DanhGias { get; set; }

        #endregion
    }
}
