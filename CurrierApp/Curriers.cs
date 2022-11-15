using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CurrierApp
{

    internal abstract class Curriers //IComparable<Curriers>
    {
        public string Name { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public int Price { get; set; }
        public Order CurrentOrder { get; set; }
        // private bool isBusy { get; set; } = false;

        public double CarryingCapacity { get; set; }

        public double Speed { get;protected set; }
        public bool CanCarry(Order order)
        {
            if (CarryingCapacity >= order.Weigth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void findFittedOrder()
        {
            Order bestOrder = null;
            foreach (var order in Company.OrdersQueue)
            {
                if (CanCarry(order))
                {
                    bestOrder = order;
                }
            }

            if (bestOrder != null)
            {
                CurrentOrder = bestOrder;
                Company.OrdersQueue = new Queue<Order>(Company.OrdersQueue.Where(x => x != bestOrder));
            }
        }

        /*public int CompareTo(Curriers? other)
        {
           throw new NotImplementedException();
        }*/
        public string GetInfo()
        {
            return string.Format("Курьер: {0}|" +
                " Скорость: {1} |" +
                " Грузоподъмность {2} |" +
                " Находится в {3}, {4}", //+ " Цена доставки: {5}",
                Name, Speed, CarryingCapacity, XCoord, YCoord, Price);
        }

        public string GetOrderInfo()
        {
            if (CurrentOrder == null)
            {
                return string.Format("Заказов у {0} нет", Name);
            }
            return string.Format("{0} взял заказ весом {1} и ценой {2}", Name, CurrentOrder.Weigth, CurrentOrder.GetOrderPrice());
        }
    }
    
    internal class FootCurriers : Curriers
    {
        public FootCurriers()
        {
            Speed = Company.DefaultFootCurierSpeed;
            Price = 50;
        }
    }
    internal class MobileCurriers : Curriers
    {
        public MobileCurriers()
        {
            Speed = Company.DefaultMobileCurierSpeed;
            Price = 100;
        }
    }
    

}
