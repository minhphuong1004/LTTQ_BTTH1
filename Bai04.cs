
using System;

namespace BTTH1_BT4
{
    class  Program
    {
        //Ham kiem tra nam nhuan
        static bool isLeapYear(int year)
        {
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                return true;
            return false;
        }

        //Ham in ra so ngay trong thang
        static int daysInMonth(int month, int year)
        {
            switch (month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    return 31;
                case 4: case 6: case 9: case 11:
                    return 30;
                case 2:
                    return isLeapYear(year) ? 29 : 28;
                default:
                    return 0;  //Thang khong hop le
            }
        }
        static void Main()
        {
            Console.Write("Nhap thang: ");
            int month = int.Parse(Console.ReadLine()!);

            Console.Write("Nhap nam: ");
            int year = int.Parse(Console.ReadLine()!);

            if (year <= 0)
            {
                Console.WriteLine("Nam khong hop le!");
                return;
            }

            int days = daysInMonth(month, year);

            if (days == 0)
                Console.WriteLine("Thang khong hop le!");
            else
                Console.WriteLine($"Thang {month}/{year} co {days} ngay.");
        }

    }
}