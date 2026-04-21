namespace NguyenHuuTu_BTMVC.Models
{
    public class SinhVien
    {
        public int SinhVienId { get; set; }
        public string tenSinhVien { get; set; }
        public ICollection<DangKyLopHoc> dangKyLopHocs { get; set; }
    }
}
