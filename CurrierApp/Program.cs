using System;
using System.Security.Cryptography.X509Certificates;
using static CurrierApp.Curriers;

namespace CurrierApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
                      
            var Curr1 = new
                FootCurriers
            {
                Name = "Первый",
                XCoord = 5,
                YCoord = 3,
                CarryingCapacity = 9,
            };
            var Curr2 = new
                FootCurriers
            {
                Name = "Второй",
                XCoord = 1,
                YCoord = 1,
                CarryingCapacity = 4
            };
            var Curr3 = new
               MobileCurriers
            {
                Name = "Третий",
                XCoord = 7,
                YCoord = 4,
                CarryingCapacity = 25
            };
            Random rnd = new Random();
            var order1 = new Order
            {
                FromLocationX = rnd.Next(1, 10),
                FromLocationY = rnd.Next(1, 10),
                ToLocationX = rnd.Next(1, 10),
                ToLocationY = rnd.Next(1, 10),
                Weigth = rnd.Next(1, 20),
            };

            var order2 = new Order
            {
                FromLocationX = rnd.Next(1, 10),
                FromLocationY = rnd.Next(1, 10),
                ToLocationX = rnd.Next(1, 10),
                ToLocationY = rnd.Next(1, 10),
                Weigth = rnd.Next(1, 20),
            };

            var order3 = new Order
            {
                FromLocationX = rnd.Next(1, 10),
                FromLocationY = rnd.Next(1, 10),
                ToLocationX = rnd.Next(1, 10),
                ToLocationY = rnd.Next(1, 10),
                Weigth = rnd.Next(1, 20),
            };

            Company.CurrList.Add(Curr1);
            Company.CurrList.Add(Curr2);
            Company.CurrList.Add(Curr3);

            Company.OrdersList.Add(order1);
            Company.OrdersList.Add(order2);
            Company.OrdersList.Add(order3);

            Company.PrintOrders();
            Console.WriteLine();
            Company.PrintCurriers();

            Company.setOrders();
            Company.PrintSettedOrders();

        }
    }
}
