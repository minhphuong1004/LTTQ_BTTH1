
using System;

namespace BTTH1_BT1
{
    class Program
    {
        // Ham nhap so nguyen duong
        static int NhapSoNguyenDuong(string message)
        {
            int n;
            do
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out n) && n > 0)
                    return n;

                Console.WriteLine("Gia tri khong hop le. Vui long nhap lai!");
            } while (true);
        }

        // Ham tao mang ngau nhien n so
        static int[] TaoMang(int n, int minval = -100, int maxval = 100)
        {
            Random rnd = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(minval, maxval + 1);
            }
            return arr;
        }

        // Ham tinh tong cac so le
        static int TongSoLe(int[] arr)
        {
            int tong = 0;
            foreach (int i in arr)
            {
                if (i % 2 != 0)
                    tong += i;
            }
            return tong;
        }

        // Ham xac dinh so nguyen to
        static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        // Ham dem so nguyen to trong mang
        static int DemSoNguyenTo(int[] arr)
        {
            int dem = 0;
            foreach (int i in arr)
            {
                if (LaSoNguyenTo(i))
                    dem++;
            }
            return dem;
        }

        // Ham xac dinh so chinh phuong
        static bool LaSoChinhPhuong(int n)
        {
            if (n < 0) return false;
            int tmp = (int)Math.Sqrt(n);
            return tmp * tmp == n;
        }

        // Ham tim so chinh phuong nho nhat
        static int SoChinhPhuongNhoNhat(int[] arr)
        {
            int min = int.MaxValue;
            bool found = false;
            foreach (int i in arr)
            {
                if (LaSoChinhPhuong(i))
                {
                    if (i < min)
                        min = i;
                    found = true;
                }
            }
            return found ? min : -1;
        }

        // Ham xuat mang
        static void XuatMang(int[] arr)
        {
            Console.WriteLine("Mang hien tai:");
            Console.WriteLine(string.Join(" ", arr));
        }

        static void Main(string[] args)
        {
            int n = NhapSoNguyenDuong("Nhap so phan tu n (>0): ");
            int[] mang = TaoMang(n);

            Console.WriteLine("\n=== MANG NGau NHien ===");
            XuatMang(mang);

            int choice;
            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Xuat mang");
                Console.WriteLine("2. Tinh tong cac so le");
                Console.WriteLine("3. Dem so nguyen to trong mang");
                Console.WriteLine("4. Tim so chinh phuong nho nhat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        XuatMang(mang);
                        break;
                    case 2:
                        Console.WriteLine($"Tong cac so le trong mang: {TongSoLe(mang)}");
                        break;
                    case 3:
                        Console.WriteLine($"So luong so nguyen to trong mang: {DemSoNguyenTo(mang)}");
                        break;
                    case 4:
                        int scp = SoChinhPhuongNhoNhat(mang);
                        if (scp == -1)
                            Console.WriteLine("Mang khong co so chinh phuong nao!");
                        else
                            Console.WriteLine($"So chinh phuong nho nhat trong mang: {scp}");
                        break;
                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le! Vui long chon lai.");
                        break;
                }
            } while (choice != 0);
        }
    }
}
