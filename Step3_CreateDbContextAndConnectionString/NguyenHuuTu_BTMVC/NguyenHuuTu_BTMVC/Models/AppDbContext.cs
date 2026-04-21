using Microsoft.EntityFrameworkCore;

namespace NguyenHuuTu_BTMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<KhoaHoc> khoaHocs { get; set; }
        public DbSet<GiaoVien> giaoViens { get; set; }
        public DbSet<LopHocPhan> lopHocPhans { get; set; }

        public DbSet<SinhVien> sinhViens { get; set; }
        public DbSet<DangKyLopHoc> dangKyLopHocs { get; set; }
    }
}
