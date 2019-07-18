using System;

namespace FactoryMethodDesign
{
    /*工厂方法模式：定义一个用于创建对象的接口，让子类决定实例化哪一个类，工厂方法使一个类的初始化延迟到子类
    抽象工厂模式：定义一个用于创建一系列相互依赖或相关对象的接口，而无需指定他们具体的类。
         */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("工厂方法模式");
            IFactory factory = new AddFactory();
            IProduct product = factory.CreateProduct();
            product.NumberA = 10;
            product.NumberB = 20;

            Console.WriteLine($"结果为{product.GetResult()}");
            Console.ReadKey();
        }
    }

    interface IFactory
    {
        IProduct CreateProduct();
    }

    class AddFactory : IFactory
    {
        public IProduct CreateProduct()
        {
            return new Add();
        }
    }
    class MultiFactory : IFactory
    {
        public IProduct CreateProduct()
        {
            return new Multi();
        }
    }

    interface IProduct
    {
        decimal NumberA { get; set; }
        decimal NumberB { get; set; }

        decimal GetResult();
    }

    class Add : IProduct
    {
        public decimal NumberA { get; set; }
        public decimal NumberB { get; set; }

        public decimal GetResult()
        {
            return NumberA + NumberB;
        }
    }
    class Multi : IProduct
    {
        public decimal NumberA { get; set; }
        public decimal NumberB { get; set; }

        public decimal GetResult()
        {
            return NumberA + NumberB;
        }
    }


}
