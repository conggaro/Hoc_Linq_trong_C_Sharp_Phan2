using System;

namespace MyApp
{
    public class SanPham
    {
        public int Id { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }


        // hàm khởi tạo không tham số
        public SanPham() { }


        // ghi đè phương thức ToString()
        public override string ToString()
        {
            return $"{Id}, {MaSP}, {TenSP}";
        }
    }
}
