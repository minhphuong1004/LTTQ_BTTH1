

using System;

namespace BTTH1_BT5
{
    class Date
    {
        public int day;
        public int month;
        public int year;

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public Date()
        {
            day = 1;
            month = 1;
            year = 1;
        }

        //Ham nhap ngay
        public static void input(Date d)
        {
            do
            {
                Console.Write("Nhap ngay thang nam (dd mm yyyy): ");
                string? line = Console.ReadLine();

                if (line != null)
                {
                    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3
                        && int.TryParse(parts[0], out int day)
                        && int.TryParse(parts[1], out int month)
                        && int.TryParse(parts[2], out int year))
                    {
                        d.day = day;
                        d.month = month;
                        d.year = year;
                        return; // ✅ Thoát khi nhập đúng
                    }
                }

                Console.WriteLine("Dinh dang nhap sai! Vi du: 01 01 2001");
            } while (true);
        }

        public static bool isLeapYear(Date d)
        {
            if (d.year % 4 == 0 && d.year % 100 != 0 || d.year % 400 == 0)
                return true;
            return false;
        }

        public static bool suitableDate(Date d)
        {
            if (d.year <= 0) return false;

            if (d.month < 1 || d.month > 12) return false;

            int daysInMonth;
            switch (d.month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    daysInMonth = 31;
                    break;
                case 4: case 6: case 9: case 11:
                    daysInMonth = 30;
                    break;
                case 2:
                    daysInMonth = isLeapYear(d) ? 29 : 28;
                    break;
                default:
                    return false;
            }
            if (d.day < 1 || d.day > daysInMonth) return false;

            return true;
        }
        public void DayInWeek()
        {
            int d = day;
            int m = month;
            int y = year;

            if (m < 3)
            {
                m += 12;
                y -= 1;
            }

            int k = y % 100;   //2 so cuoi nam   
            int j = y / 100;   // the ky

            int h = (d + (13 * (m + 1)) / 5 + k + (k / 4) + (j / 4) + 5 * j) % 7;

            string[] thu = { "Thu bay", "Chu nhat", "Thu hai", "Thu ba", "Thu tu", "Thu nam", "Thu sau" };
            Console.WriteLine($"Ngay {day:D2}/{month:D2}/{year} la {thu[h]}");
        }
    }
    class Program
    {
        static void Main()
        {
            Date d = new Date();
            Date.input(d);

            if (Date.suitableDate(d))
                d.DayInWeek();
            else
                Console.WriteLine("Ngay khong hop le!");
        }
    }
}
