
using System;

namespace BTTH1_BT6
{
    class Program
    {
        //Ham nhap so nguyen duong
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

        //Ham tao ma tran voi cac so nguyen ngau nhien
        static int[][] TaoMaTran(int n, int m, int minval = -100, int maxval = 100)
        {
            Random rnd = new Random();
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    matrix[i][j] = rnd.Next(minval, maxval + 1);
                }
            }
            return matrix;
        }

        //Ham xuat ma tran
        static void XuatMaTran(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j],5}");
                }
                Console.WriteLine();
            }
        }

        //Ham tim phan tu lon nhat
        static int TimMax(int[][] a)
        {
            int max = a[0][0];
            foreach (var row in a)
                foreach (var val in row)
                    if (val > max) max = val;
            return max;
        }

        //Ham tim phan tu nho nhat
        static int TimMin(int[][] a)
        {
            int min = a[0][0];
            foreach (var row in a)
                foreach (var val in row)
                    if (val < min) min = val;
            return min;
        }

        //Ham tim dong co tong lon nhat
        static int DongTongLonNhat(int[][] a)
        {
            int dongMax = 0;
            int tongMax = int.MinValue;

            for (int i = 0; i < a.Length; i++)
            {
                int tong = 0;
                for (int j = 0; j < a[i].Length; j++)
                    tong += a[i][j];

                if (tong > tongMax)
                {
                    tongMax = tong;
                    dongMax = i;
                }
            }
            return dongMax;
        }

        //Ham kiem tra so nguyen to
        static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        //Ham tinh tong cac so khong phai so nguyen to
        static int TongKhongPhaiNguyenTo(int[][] a)
        {
            int tong = 0;
            foreach (var row in a)
                foreach (var val in row)
                    if (!LaSoNguyenTo(val))
                        tong += val;
            return tong;
        }

        //Ham xoa dong thu k trong ma tran
        static int[][] XoaDong(int[][] a, int k)
        {
            if (k < 0 || k >= a.Length)
            {
                Console.WriteLine("Dòng không hợp lệ!");
                return a;
            }

            int[][] result = new int[a.Length - 1][];
            int idx = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i == k) continue;
                result[idx++] = a[i];
            }
            return result;
        }

        //Ham xoa cot chua phan tu lon nhat trong ma tran
        static int[][] XoaCotChuaMax(int[][] a)
        {
            int max = TimMax(a);
            int cotXoa = -1;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (a[i][j] == max)
                    {
                        cotXoa = j;
                        break;
                    }
                }
                if (cotXoa != -1) break;
            }

            if (cotXoa == -1)
            {
                Console.WriteLine("Khong tim thay phan tu lon nhat");
                return a;
            }

            int[][] result = new int[a.Length][];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = new int[a[i].Length - 1];
                int idx = 0;
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (j == cotXoa) continue;
                    result[i][idx++] = a[i][j];
                }
            }
            return result;
        }

        static void Main()
        {
            int n = NhapSoNguyenDuong("Nhap so dong: ");
            int m = NhapSoNguyenDuong("Nhap so cot: ");

            int[][] a = TaoMaTran(n, m);
            Console.WriteLine("\n=== MA TRAN BAN DAU ===");
            XuatMaTran(a);

            int choice;
            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Xuat ma tran");
                Console.WriteLine("2. Tim phan tu lon nhat");
                Console.WriteLine("3. Tim phan tu nho nhat");
                Console.WriteLine("4. Tim dong co tong lon nhat");
                Console.WriteLine("5. Tinh tong cac so KHONG phai la so nguyen to");
                Console.WriteLine("6. Xoa dong thu k");
                Console.WriteLine("7. Xoa cot chua phan tu lon nhat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        XuatMaTran(a);
                        break;
                    case 2:
                        Console.WriteLine($"Phan tu lon nhat: {TimMax(a)}");
                        break;
                    case 3:
                        Console.WriteLine($"Phan tu nho nhat: {TimMin(a)}");
                        break;
                    case 4:
                        int dong = DongTongLonNhat(a);
                        Console.WriteLine($"Dong co tong lon nhat: {dong + 1}");
                        break;
                    case 5:
                        Console.WriteLine($"Tong cac so KHONG phai so nguyen to: {TongKhongPhaiNguyenTo(a)}");
                        break;
                    case 6:
                        Console.Write("Nhap dong can xoa (1 → n): ");
                        int k = int.Parse(Console.ReadLine() ?? "0") - 1;
                        a = XoaDong(a, k);
                        Console.WriteLine("Ma tran sau khi xoa dong:");
                        XuatMaTran(a);
                        break;
                    case 7:
                        a = XoaCotChuaMax(a);
                        Console.WriteLine("Ma tran sau khi xoa cot chua phan tu lon nhat:");
                        XuatMaTran(a);
                        break;
                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            } while (choice != 0);
        }
    }
}
