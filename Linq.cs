using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
// Linq là gì?
// Linq = Language integrated query
// ngôn ngữ truy vấn tích hợp

// nó được viết bằng class IEnumerable, IEnumerable<T>

// nguồn dữ liệu: Array, List, Stack, Queue

using System;
using System.Linq;

namespace Hoc_Linq{
    public class Product {
        public int ID {set; get;}
        public string Name {set; get;}         // tên
        public double Price {set; get;}        // giá
        public string[] Colors {set; get;}     // các màu sắc
        public int id_Brand {set; get;}           // ID Nhãn hiệu, hãng
        
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; id_Brand = brand;
        }
        
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        // dùng -3, -15, -6, -2 để căn lề bên trái
        // dùng 3, 15, 6, 2 để căn lề bên phải
        public override string ToString()
        => $"[{ID, -3} {Name, -15} {Price, -6} {id_Brand, -2} ({string.Join(", ", Colors)})]";
    }

    // tạo lớp thương hiệu
    public class Brand {
        public string Name {set; get;}
        public int ID {set; get;}

        public override string ToString()
        => $"[{ID, -1}, {Name, -10}]";
    }

    public class Linq{
        public static void Main(string[] args){
            // xóa màn hình console cũ
            Console.Clear();

            // tạo đối tượng
            List<Brand> ds_ThuongHieu = new List<Brand>() {
                new Brand{ID = 1, Name = "Cong ty AAA"},
                new Brand{ID = 2, Name = "Cong ty BBB"},
                new Brand{ID = 4, Name = "Cong ty CCC"},
            };

            List<Product> ds_SanPham = new List<Product>(){
                new Product(1, "Ban tra",    400, new string[] {"Xam", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vang", "Xanh"},        1),
                new Product(3, "Den chum",   500, new string[] {"Trang"},               3),
                new Product(4, "Ban hoc",    200, new string[] {"Trang", "Xanh"},       1),
                new Product(5, "Tui da",     300, new string[] {"Do", "Den", "Vang"},   2),
                new Product(6, "Giuong ngu", 500, new string[] {"Trang"},               2),
                new Product(7, "Tu ao",      600, new string[] {"Trang"},               3),
            };
            
            // cú pháp của Linq thì nó như sau
            // tối thiểu thì nó phải có 2 phần

            /*
                Phần 1:
                --> phải xác định nguồn dữ liệu
                --> IEnumerable, mảng, danh sách,...
                --> from TÊN_PHẦN_TỬ in ĐỐI_TƯỢNG_DANH_SÁCH

                Phần 2:
                --> kết nối các nguồn dữ liệu
                --> sử dụng join TÊN_PHẦN_TỬ in ĐỐI_TƯỢNG_DANH_SÁCH on ... equals ...
                cái chỗ equals là điều kiện kết nối đấy
                cái equals là dùng thay cho toán tử ==

                Phần 3:
                --> những biểu thức điều kiện
                --> where
                
                Phần 4:
                --> có tác dụng sắp xếp
                --> orderby ... ascending
                --> orderby ... descending

                Phần 5:
                --> những chỉ thị để lấy dữ liệu ra
                --> dùng select
                --> group ... by ...

                Phần 6:
                --> dùng select
                --> để trả về các bản ghi

                có các kiểu select sau
                1. string
                2. int
                3. long
                4. float
                5. new {}
                6. đối_tượng do người dùng định nghĩa từ class
                ...
                vân vân, nó còn nhiều kiểu mà
            */

            
            // dịch ra là
            // với mỗi đối tượng item ở trong đối tượng ds_SanPham
            // thì chúng ta sẽ lấy ra dữ liệu gì
            // lấy ra dữ liệu thì dùng select
            var dt_query1 = from item in ds_SanPham
                            select item.Name;

            Console.WriteLine($"In ra danh sach ten san pham:");
            for(int i = 0; i < dt_query1.Count(); i++){
                Console.WriteLine($"{i + 1}. {dt_query1.ToList()[i]}");
            }


            // chúng ta có thể trả về các biểu thức phức tạp
            // ví dụ chúng ta trả về 1 chuỗi
            // dùng select nha
            var dt_query2 = from item in ds_SanPham
                            select $"{item.Name}: {item.Price}";
                        
            Console.WriteLine($"\nIn ra danh sach ten san pham, gia san pham:");
            for(int i = 0; i < dt_query2.Count(); i++){
                Console.WriteLine($"{i + 1}. {dt_query2.ToList()[i]}");
            }


            // trong kết quả
            // được select trả về
            // thì cũng có trường hợp chứa dữ liệu phức tạp
            // đó là trường hợp trả về đối tượng có kiểu vô danh
            // bằng cách sử dụng toán tử new
            var dt_query3 = from item in ds_SanPham
                            select new {
                                Ten = item.Name,
                                Gia = item.Price,
                                MauSac = string.Join(", ", item.Colors)
                            };
                
            Console.WriteLine("\nIn ra doi tuong kieu vo danh:");
            foreach(var item in dt_query3){
                Console.WriteLine(item);
            }


            // sử dụng where
            var dt_query4 = from item in ds_SanPham
                            where item.Price == 400
                            select new {
                                DuLieu = $"{item.Name}: {item.Price}"
                            };
            
            Console.WriteLine($"\nDanh sach san pham co gia 400:");
            foreach(var item in dt_query4){
                Console.WriteLine(item);
            }


            var dt_query5 = from item in ds_SanPham
                            where item.Price < 600
                            select new {
                                DuLieu = $"{item.Name}: {item.Price}"
                            };
            
            Console.WriteLine($"\nDanh sach san pham co gia nho hon 600:");
            foreach(var item in dt_query5){
                Console.WriteLine(item);
            }


            // sử dụng từ khóa from 2 lần
            var dt_query6 = from item in ds_SanPham
                            from mau_sac in item.Colors

                            where item.Price < 500 && mau_sac == "Xanh"

                            select new {
                                Ten = item.Name,
                                Gia = item.Price,
                                MauSac = string.Join(", ", item.Colors)
                            };

            Console.WriteLine($"\nDanh sach san pham co gia nho hon 500, co mau Xanh la:");
            foreach(var item in dt_query6){
                Console.WriteLine(item);
            }


            // sử dụng from 2 lần
            // và sử dụng orderby
            var dt_query7 = from item in ds_SanPham
                            from mau_sac in item.Colors

                            where item.Price < 700 && mau_sac == "Trang"

                            orderby item.Price ascending

                            select new {
                                Ten = item.Name,
                                Gia = item.Price,
                                MauSac = string.Join(", ", item.Colors)
                            };

            Console.WriteLine($"\nDanh sach san pham co gia nho hon 700, co mau Trang");
            Console.WriteLine($"sap xep tang dan (Ascending) theo gia la:");
            foreach(var item in dt_query7){
                Console.WriteLine(item);
            }


            // sử dụng from 2 lần
            // và sử dụng orderby
            var dt_query8 = from item in ds_SanPham
                            from mau_sac in item.Colors

                            where item.Price < 700 && mau_sac == "Trang"

                            orderby item.Price descending

                            select new {
                                Ten = item.Name,
                                Gia = item.Price,
                                MauSac = string.Join(", ", item.Colors)
                            };

            Console.WriteLine($"\nDanh sach san pham co gia nho hon 700, co mau Trang");
            Console.WriteLine($"sap xep giam dan (Descending) theo gia la:");
            foreach(var item in dt_query8){
                Console.WriteLine(item);
            }


            // hướng dẫn sử dụng group ... by ...
            // dùng để tạo ra các nhóm từ N bản ghi
            
            // Key trong code là thuộc tính
            // Key chứa tập hợp các giá trị khác nhau

            // ví dụ:
            // nhóm sản phẩm theo giá
            // dùng từ khóa group để nhóm các phần tử
            // dùng từ khóa by để nhóm các phần tử theo 1 trường dữ liệu nào đó
            var dt_query9 = from item in ds_SanPham
                            group item by item.Price;

            // kết quả của dt_query9
            // trả về tập hợp các item
            // trong mỗi đối tượng item thì có thuộc tính Key
            Console.WriteLine("\nIN RA NHOM SAN PHAM:");
            foreach(var item in dt_query9){
                Console.WriteLine($"_____________ Nhom san pham gia {item.Key} _____________");

                foreach(var san_pham in item){
                    Console.WriteLine(san_pham);
                }

                Console.Write("\n");
            }


            // ví dụ:
            // nhóm sản phẩm theo giá
            // dùng từ khóa group để nhóm các phần tử
            // dùng từ khóa by để nhóm các phần tử theo 1 trường dữ liệu nào đó
            var dt_query10 = from item in ds_SanPham

                            // sử dụng từ khóa into để trả về biến tạm thời
                            // temp_data hứng dữ liệu sau khi nhóm bằng group by
                            group item by item.Price into temp_data
                            
                            // dùng temp_data để sắp xếp
                            orderby temp_data.Key ascending
                            
                            // sử dụng select để lấy ra tập hợp temp_data
                            select temp_data;

            Console.WriteLine("\nIN RA NHOM SAN PHAM (sap xep TANG DAN):");
            foreach(var item in dt_query10){
                Console.WriteLine($"_____________ Nhom san pham gia {item.Key} _____________");

                foreach(var san_pham in item){
                    Console.WriteLine(san_pham);
                }

                Console.Write("\n");
            }


            // sử dụng từ khóa let
            // từ khóa let có tác dụng tạo ra biến
            // let cũng hứng được đủ các loại kiểu dữ liệu
            
            // tôi thấy let giống var

            // ví dụ sử dụng let
            var dt_query11 = from item in ds_SanPham

                            // sử dụng từ khóa into để trả về biến tạm thời
                            // temp_data hứng dữ liệu sau khi nhóm bằng group by
                            group item by item.Price into temp_data
                            
                            // dùng temp_data để sắp xếp
                            orderby temp_data.Key descending
                            
                            // sử dụng let để tạo ra biến so_luong
                            // biến số_lượng có tác dụng 
                            // đếm các bản ghi trong 1 nhóm
                            let so_luong = temp_data.Count()

                            select new {
                                Nhom_Gia = temp_data.Key,
                                Nhieu_SanPham = temp_data.ToList(),
                                SoLuong = so_luong
                            };

            Console.WriteLine("\nIN RA NHOM SAN PHAM (sap xep GIAM DAN):");
            foreach(var item in dt_query11){
                Console.WriteLine($"_____________ Nhom san pham gia {item.Nhom_Gia} _____________");

                Console.WriteLine($"So luong: {item.SoLuong}");

                foreach(var san_pham in item.Nhieu_SanPham){
                    Console.WriteLine(san_pham);
                }

                Console.Write("\n");
            }


            // sử dụng join
            // có tác dụng kết hợp các nguồn dữ liệu
            // cú pháp khi sử dụng join
            // join ... in ... on ... equals ...
            var dt_query12 =    from item_sp in ds_SanPham
                                
                                join item_th in ds_ThuongHieu on item_sp.id_Brand equals item_th.ID
                                
                                select new {
                                    Ten_SanPham = item_sp.Name,
                                    Gia_SanPham = item_sp.Price,
                                    Ten_ThuongHieu = item_th.Name
                                };

            Console.WriteLine("In ra TEN_SAN_PHAM va TEN_THUONG_HIEU tuong ung:");
            foreach(var item in dt_query12){
                Console.WriteLine($"{item.Ten_SanPham, -15} {item.Gia_SanPham, -8} {item.Ten_ThuongHieu}");
            }


            // trường hợp đặc biệt
            // chúng ta thấy rằng, danh sách sản phẩm có 7 sản phẩm
            // tuy nhiên khi kết hợp 2 nguồn dữ liệu
            // danh sách sản phẩm và danh sách thương hiệu
            // thì nó chỉ lấy ra 5 sản phẩm thôi
            // bởi vì trong cái bảng danh sách thương hiệu không có cái id vào bằng 3
            // do đó sản phẩm có id = 3 sẽ không được in ra
            
            // trong trường hợp chúng ta muốn lấy tất cả sản phẩm
            // kể cả những sản phẩm đấy không xác định được id
            // thì chúng ta có thể làm như sau

            // chúng ta sẽ sử dụng biến tạm
            // đó là dùng into
            // cụ thể:
            // into temp_data
            
            // cái temp_data sẽ hứng dữ liệu tất cả bản ghi

            var dt_query13 =    from item_sp in ds_SanPham
                                
                                join item_th in ds_ThuongHieu on item_sp.id_Brand equals item_th.ID into temp_data

                                // nếu ban_ghi không có trong temp_data
                                // thì trả về null
                                // để trả về null thì dùng DefaultIfEmpty
                                from ban_ghi in temp_data.DefaultIfEmpty()

                                select new {
                                    Ten_SanPham = item_sp.Name,
                                    Gia_SanPham = item_sp.Price,
                                    Ten_ThuongHieu = (ban_ghi != null) ? ban_ghi.Name : "NULL"
                                };

            Console.WriteLine("\nIn ra TEN_SAN_PHAM va TEN_THUONG_HIEU tuong ung:");
            foreach(var item in dt_query13){
                Console.WriteLine($"{item.Ten_SanPham, -15} {item.Gia_SanPham, -8} {item.Ten_ThuongHieu}");
            }
        }
    }
}