namespace NguyenHuuTu_BTMVC.Models
{
    public class LopHocPhan
    {
        public int LopHocPhanId { get; set; }
        public string tenLop { get; set; }
        public int GiaoVienId { get; set; }
        public GiaoVien GiaoVien { get; set; }
        public int KhoaHocId { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
        public ICollection<DangKyLopHoc> dangKyLopHocs { get; set; }
    }
}
