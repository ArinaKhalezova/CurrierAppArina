using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrierApp
{
    internal class Company
    {
        public const double DefaultFootCurierSpeed = 6;
        public const double DefaultMobileCurierSpeed = 22;
        public const double PricePerDistance = 100;

        public static List<Curriers> CurrList { get; set; } = new List<Curriers>();

        public static Queue<Order> OrdersQueue { get; set; } = new Queue<Order>();

        public static List<Order> OrdersList { get; set; } = new List<Order>();

        public static void PrintOrders()
        {
            for (int i = 0; i < CurrList.Count; i++)
            {
                Console.WriteLine(OrdersList[i].GetInfo());
            }
        }

        public static void PrintCurriers()
        {
            for (int i = 0; i < CurrList.Count; i++)
            {
                Console.WriteLine(CurrList[i].GetInfo());
            }
        }

        public static void PrintSettedOrders()
        {
            for (int i = 0; i < CurrList.Count; i++)
            {
                Console.WriteLine(CurrList[i].GetOrderInfo());
            }

        }
        /*public static void StartPlaner()
        {
            PrepaireQueue();
            PlanningCycle();
        }*/
        private static void PrepaireQueue()
        {
            List<Order> sortedOrders = OrdersList.OrderBy(x => x.Weigth).ToList();
            //CurrList = CurrList.OrderBy(x => x.CarryingCapacity).ToList();

            foreach (var order in sortedOrders)
            {
                OrdersQueue.Enqueue(order);
            }
        }
        public static void setOrders()
        {
            PrepaireQueue();
            foreach (var currier in CurrList)
            {
                currier.findFittedOrder();
            }
        }
        
    }
}
