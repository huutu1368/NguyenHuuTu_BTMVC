namespace NguyenHuuTu_BTMVC.Models
{
    public class KhoaHoc
    {
        public int KhoaHocId { get; set; }
        public string tenKH { get; set; }
        public ICollection<LopHocPhan> lopHocPhans { get; set; }
    }
}
