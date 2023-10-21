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
            var truy_van_1 = ds.Select(x => x.MaSP).Distinct();


            // in ra danh sách
            Console.WriteLine("\n\nSU DUNG PHUONG THUC Distinct():");
            foreach (var item in truy_van_1)
            {
                Console.WriteLine(item);
            }


            // truy vấn linq
            // để lấy ra các bản ghi khác nhau
            var truy_van_2 = (from item in ds
                              select item).DistinctBy(x => x.MaSP);


            // in ra danh sách
            Console.WriteLine("\n\nSU DUNG PHUONG THUC DistinctBy():");
            foreach (var item in truy_van_2)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}