namespace NguyenHuuTu_BTMVC.Models
{
    public class DangKyLopHoc
    {
        public int DangKyLopHocId { get; set; }
        public DateTime ngaydk { get; set; }
        public int SinhVienId { get; set; }
        public SinhVien SinhVien { get; set; }
        public int LopHocPhanId { get; set; }
        public LopHocPhan LopHocPhan { get; set; }
    }
}
