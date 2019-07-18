using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesign
{

    interface Publisher
    {
        void Notify();
        string NotifyState { get; set; }
    }

    class SecteryPublisher : Publisher
    {
        public event NotifyHandler Handler;
        public string NotifyState { get; set; }
        public void Notify()
        {
            Handler?.Invoke();
        }
    }
    public delegate void NotifyHandler();
    class NBAScriber
    {
        protected Publisher _secretary;
        protected string _name;
        public NBAScriber(Publisher secretary, string name)
        {
            _secretary = secretary;
            _name = name;
        }
        
        public void CloseNBA()
        {
            Console.WriteLine($"{_secretary.NotifyState},{_name}，关闭NBA");
        }
    }
    class StockScriber
    {
        protected Publisher _secretary;
        protected string _name;
        public StockScriber(Publisher secretary, string name)
        {
            _secretary = secretary;
            _name = name;
        }

        public void CloseStock()
        {
            Console.WriteLine($"{_secretary.NotifyState},{_name}，关闭Stock");
        }
    }

}
