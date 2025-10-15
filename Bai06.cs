
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

        //a. Ham xuat ma tran
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

        // b. Tìm phần tử lớn nhất/nhỏ nhất
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

        //c. Ham tim dong co tong lon nhat
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

        //d. Ham tinh tong cac so khong phai so nguyen to
        static int TongKhongPhaiNguyenTo(int[][] a)
        {
            int tong = 0;
            foreach (var row in a)
                foreach (var val in row)
                    if (!LaSoNguyenTo(val))
                        tong += val;
            return tong;
        }

        //e. Ham xoa dong thu k trong ma tran
        static int[][] XoaDong(int[][] a, int k)
        {
            if (k < 0 || k >= a.Length)
            {
                Console.WriteLine("Dong khong hop le!");
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

        //f. Ham xoa cot chua phan tu lon nhat trong ma tran
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

            Console.WriteLine("\nMa tran ban dau la : ");
            XuatMaTran(a);

            Console.WriteLine($"\nPhan tu lon nhat: {TimMax(a)}");
            Console.WriteLine($"\nPhan tu nho nhat: {TimMin(a)}");

            int dong = DongTongLonNhat(a);
            Console.WriteLine($"\nDong co tong lon nhat: {dong + 1}");

            Console.WriteLine($"\nTong cac so khong phai so nguyen to: {TongKhongPhaiNguyenTo(a)}");

            Console.Write("\nNhap dong can xoa: ");
            int k = int.Parse(Console.ReadLine() ?? "0") - 1;
            a = XoaDong(a, k);
            Console.WriteLine("\nMa tran sau khi xoa dong:");
            XuatMaTran(a);

            a = XoaCotChuaMax(a);
            Console.WriteLine("\nMa tran sau khi xoa cot chua phan tu lon nhat:");
            XuatMaTran(a);
        }
    }
}
