using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesign
{
    /*观察者模式：定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个主题对象，这个主题对象在
     状态发生变化时，会通知所有观察者对象，使他们能够自动更新自己

    动机：将一个系统分割成一系列相互协作的类有一个不好的副作用，需要维护相关对象间的一致性。不希望为
    了维持一致性而使各类紧密耦合，这样会给维护，扩展及复用带来不便。
         
         */
    class Program
    {
        static void Main(string[] args)
        {
            Subject secretary = new Secretary();
            Observer stock1 = new StockObserver(secretary, "A君");
            Observer stock2 = new NBAObserver(secretary, "B君");
            secretary.Attach(stock1);
            secretary.Attach(stock2);

            secretary.NotifyState = "boss is coming";

            secretary.Notify();


            Subject boss = new BossSubject();
            Observer stock3 = new StockObserver(boss, "A君");
            Observer stock4 = new NBAObserver(boss, "B君");
            boss.Attach(stock3);
            boss.Attach(stock4);

            boss.NotifyState = "哈哈，，我来了";

            boss.Notify();

            //事件处理
            var sec = new SecteryPublisher();
            sec.Handler += new StockScriber(sec, "zhangsan").CloseStock;
            sec.Handler += new NBAScriber(sec, "lisi").CloseNBA;
            sec.NotifyState = "boss is coming";
            sec.Notify();
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 主题或者抽象通知者
    /// </summary>
    interface Subject
    {
        void Attach(Observer observer);
        void Detach(Observer observer);

        void Notify();

        string NotifyState { get; set; }

    }

    class BossSubject : Subject
    {
        public List<Observer> Observers = new List<Observer>();
        public string NotifyState { get; set; }
        public void Attach(Observer observer)
        {
            Observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var item in Observers)
            {
                item.Update();
            }
        }
    }

    class Secretary:Subject
    {
        string _name;

        List<Observer> Observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            Observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var item in Observers)
            {
                item.Update();
            }
        }
        public string NotifyState { get; set; }
    }

    abstract class Observer
    {
        protected Subject _secretary;
        protected string _name;
        public Observer(Subject secretary, string name)
        {
            _secretary = secretary;
            _name = name;
        }

        public abstract void Update();

    }
    class NBAObserver : Observer
    {
        public NBAObserver(Subject sec, string name) : base(sec, name)
        {

        }
        public override void Update()
        {
            Console.WriteLine($"{_secretary.NotifyState},{_name}，关闭NBA");
        }
    }
    class StockObserver : Observer
    {
        public StockObserver(Subject secretary, string name) : base(secretary, name)
        {
        }

        public override void Update()
        {
            Console.WriteLine($"{_secretary.NotifyState},{_name}，收起股票");
        }

    }
}

