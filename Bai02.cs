

using System;

namespace BTTH1_BT2
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

        //Ham xac dinh so nguyen to
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

        //Ham tinh tong cac so nguyen to <n
        static int TongCacSoNguyenToBeHonN(int n)
        {
            int tong = 0;
            if (n < 2)
                return tong;
            else
            {
                for (int i = 2; i < n; i++)
                {
                    if (LaSoNguyenTo(i))
                        tong += i;
                }
            }
                return tong;
        }

        static void Main()
        {
            int n = NhapSoNguyenDuong("Nhap so nguyen duong n : ");

            //Tinh tong cac so nguyen to nho hon n
            int tongsonguyento = TongCacSoNguyenToBeHonN(n);
            Console.WriteLine($"Tong cac so nguyen to nho hon {n} la: {tongsonguyento}");

        }
    }
}
