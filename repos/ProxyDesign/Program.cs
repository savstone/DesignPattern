using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesign
{
    /*
     *代理模式:为其他对象提供一种代理，以控制对这个对象的访问
     */
    class Program
    {
        static void Main(string[] args)
        {
            //SchoolGirl girl = new SchoolGirl("good girl");
            //Pursuit pursuit = new Pursuit(girl);
            //pursuit.SendChocklate();
            //pursuit.SendFlower();

            //Console.Read();


            Console.WriteLine("代理追女孩了。。");
            var girl = new SchoolGirl("lucy");
            var proxy = new Proxy(girl);
            proxy.SendChocolates();
            proxy.SendFlower();

            Console.Read();
        }
    }
    #region 以下是为了引入代理模式
    class SchoolGirl
    {
        private string Name;
        public SchoolGirl(string name)
        {
            Name = name;
        }

        public string Name1 { get => Name; set => Name = value; }
    }

    //class Pursuit
    //{
    //    SchoolGirl _girl;
    //    public Pursuit(SchoolGirl girl)
    //    {
    //        _girl = girl;
    //    }

    //    public void SendFlower()
    //    {
    //        Console.WriteLine($"给{_girl.Name1}送花");
    //    }

    //    public void SendChocklate()
    //    {
    //        Console.WriteLine($"给{_girl.Name1}送巧克力");
    //    }
    //}

    #endregion


    interface ISendGift
    {
        void SendFlower();
        void SendChocolates();
    }

    class Pursuit : ISendGift
    {
        SchoolGirl _girl;
        public Pursuit(SchoolGirl girl)
        {
            _girl = girl;
        }
        public void SendChocolates()
        {
            Console.WriteLine($"给{_girl.Name1}送花");
        }

        public void SendFlower()
        {
            Console.WriteLine($"给{_girl.Name1}送巧克力");
        }
    }

    class Proxy : ISendGift
    {
        Pursuit _pursuit;
        public Proxy(SchoolGirl girl)
        {
            _pursuit = new Pursuit(girl);
        }

        public void SendChocolates()
        {
            if (_pursuit != null)
            {
                _pursuit.SendChocolates();
            }
        }

        public void SendFlower()
        {
            if (_pursuit != null)
            {
                _pursuit.SendFlower();
            }
        }
    }
}
