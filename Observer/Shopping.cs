using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal interface IEventItem
    {
        void SendMessage(int sale);
    }

    internal interface IEventHall
    {
        void Add(IEventItem eventItem);
        void Remove(IEventItem eventItem);
        void Notify(int sale);
    }

    internal class SinSaeGaeMall : IEventHall
    {
        private List<IEventItem> EventItems { get; set; }
        public SinSaeGaeMall()
        {
            EventItems = new List<IEventItem>();
        }

        public void Add(IEventItem eventItem) => EventItems.Add(eventItem);

        public void Notify(int sale) => EventItems.ForEach(eventItem => eventItem.SendMessage(sale));

        public void Remove(IEventItem eventItem) => EventItems.Remove(eventItem);
    }

    internal class NIKE : IEventItem
    {
        public void SendMessage(int sale) => Console.WriteLine($"NIKE 전 품목 {sale}% SALE!!!");
    }
    internal class NBA : IEventItem
    {
        public void SendMessage(int sale) => Console.WriteLine($"NBA 모자 품목 {sale}% SALE!!!");
    }
}
