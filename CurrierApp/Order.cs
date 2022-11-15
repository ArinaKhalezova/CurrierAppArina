using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrierApp
{
    internal class Order
    {
        public int FromLocationX { get; set; }
        public int FromLocationY { get; set; }
        public int ToLocationX { get; set; }
        public int ToLocationY { get; set; }

        public double Weigth { get; set; }
        public double GetOrderPrice()
        {
            int DistX = Math.Abs(ToLocationX - FromLocationX);
            int DistY = Math.Abs(ToLocationY - FromLocationY);
            int Dist = DistX + DistY;
            return Dist * Company.PricePerDistance;
        }
        public string GetInfo()
        {
            return $"Заказ: {Weigth.ToString()}кг, {FromLocationX.ToString()}, " +
                $"{FromLocationY.ToString()} -> {ToLocationX.ToString()}, " +
                $"{ToLocationY.ToString()} ";
               // $" ({OrderDistance} км) | {OrderPrice}";
        }
        private static void PlanningCycle()
        {
            foreach (var order in Company.OrdersList)
            {
                Console.WriteLine(order.GetInfo());
            }
            Console.WriteLine();

        }


    }
}
