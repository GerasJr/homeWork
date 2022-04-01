using System;

namespace HomeWork6
{
    class HomeWork6
    {
        static void Main(string[] args)
        {
            int pictures = 52;
            int picturesRange = 3;

            int ranges = pictures / picturesRange;
            int pictureRemainders = pictures % picturesRange;
            Console.WriteLine("Картин - " + pictures);
            Console.WriteLine("Всего рядов - " + ranges);
            Console.WriteLine("Остаток - " + pictureRemainders);
        }
    }
}
