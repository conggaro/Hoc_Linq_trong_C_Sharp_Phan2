using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo danh sách
            List<SanPham> ds = new List<SanPham>();


            // thêm phần tử cho danh sách
            ds.Add(new SanPham() { Id = 1, MaSP = "SP01", TenSP = "May tinh" });
            ds.Add(new SanPham() { Id = 2, MaSP = "SP01", TenSP = "May tinh" });
            ds.Add(new SanPham() { Id = 3, MaSP = "SP02", TenSP = "Dien thoai" });
            ds.Add(new SanPham() { Id = 4, MaSP = "SP02", TenSP = "Dien thoai" });
            ds.Add(new SanPham() { Id = 5, MaSP = "SP03", TenSP = "Ti vi" });
            ds.Add(new SanPham() { Id = 6, MaSP = "SP03", TenSP = "Ti vi" });


            // in ra danh sách ban đầu
            Console.WriteLine("DANH SACH BAN DAU:");
            foreach (var item in ds)
            {
                Console.WriteLine(item.ToString());
            }


            // truy vấn linq
            // để lấy ra các giá trị khác nhau
            // theo "mã sản phẩm"
            var query = from item in ds
                        group item by item.MaSP into temp_data
                        select new SanPham
                        {
                            Id = temp_data.First().Id,
                            MaSP = temp_data.First().MaSP,
                            TenSP = temp_data.First().TenSP
                        };


            // danh sách sau khi truy vấn
            Console.WriteLine("\n\nDANH SACH SAU KHI SU DUNG (group... by... into...):");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}